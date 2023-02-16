using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using GHPRS.Core.Entities;
using GHPRS.Core.Hubs;
using GHPRS.Core.Interfaces;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace GHPRS.Core.Services;

public class BlobStorageService : IBlobStorageService
{
    private readonly CloudBlobContainer _container;
    private readonly IMerDataRepository _merDataRepository;
    private readonly IFileUploadRepository _fileUploadRepository;
    private readonly IPLHIVDataRepository _plhivDataRepository;
    private readonly IConfiguration _configuration;
    private readonly IHubContext<ExtractProgressHub> _progressHubContext;
    private readonly ILogger<BlobStorageService> _logger;
    
    public BlobStorageService(
        IConfiguration configuration,
        IMerDataRepository merDataRepository,
        IPLHIVDataRepository plhivDataRepository,
        IFileUploadRepository fileUploadRepository,
        ILogger<BlobStorageService> logger,
        IHubContext<ExtractProgressHub> progressHubContext)
    {
        _configuration = configuration;
        _merDataRepository = merDataRepository;
        _fileUploadRepository = fileUploadRepository;
        _plhivDataRepository = plhivDataRepository;
        _progressHubContext = progressHubContext;
        _logger = logger;
        
        var connectionString = configuration.GetConnectionString("AzureStorage");
        var account = CloudStorageAccount.Parse(connectionString);
        var client = account.CreateCloudBlobClient();
        _container = client.GetContainerReference("merplhiv");
    }
    
    public async Task<DataTable> GetTextAsync(string blobName, int uploadTypeId)
    {
        var merData = new FileUploads
        {
            Name = blobName,
            ContentType = "text/plain",
            // User = user,
            UploadDate = DateTime.Now,
            Status = "Processing",
            UploadType = uploadTypeId == 1 ? "MER Data" : "PLHIV Data"
        };
        _fileUploadRepository.Insert(merData);
        try
        {
            var extractProgress = new ExtractProgress { name = blobName, Value = 0.1 };
            await _progressHubContext.Clients.All.SendAsync("Progress", extractProgress);
            if (uploadTypeId == 1)
            {
                var blob = _container.GetBlockBlobReference(blobName);
                // Get the size of the blob
                await blob.FetchAttributesAsync();
                long blobSize = blob.Properties.Length;
                
                // Set the chunk size to 100MB
                int chunkSize = 50 * 1024 * 1024;

                var dataTable = new DataTable();
                // Loop through the blob in chunks of 100MB
                for (long offset = 0; offset < blobSize; offset += chunkSize)
                {
                    if (offset == 0)
                    {
                        extractProgress.Value = 0.1;
                    }
                    else
                    {
                        extractProgress.Value = offset/blobSize;
                    }
                    await _progressHubContext.Clients.All.SendAsync("Progress", extractProgress);
                    long bytesToRead = Math.Min(chunkSize, blobSize - offset);
                    using (var memoryStream = new MemoryStream())
                    {
                        // Download the chunk to memory stream
                        await blob.DownloadRangeToStreamAsync(memoryStream, offset, bytesToRead);
                        // Seek to the beginning of the memory stream
                        memoryStream.Seek(0, SeekOrigin.Begin);
                        using (var streamReader = new StreamReader(memoryStream))
                        {
                            List<MerData> listMerData = new List<MerData>();
                            char[] delimiter = new char[] { '\t' };
                            var headers = streamReader.ReadLine().Split(delimiter);
                            foreach (var header in headers)
                            {
                                dataTable.Columns.Add(header);
                            }

                            while (!streamReader.EndOfStream)
                            {
                                var line = streamReader.ReadLine();
                                var values = line.Split(delimiter);

                                var row = dataTable.NewRow();
                                for (int i = 0; i < headers.Length; i++)
                                {
                                    if (values.ElementAtOrDefault(i) != null)
                                    {
                                        row[i] = values[i];
                                    }
                                }
                                dataTable.Rows.Add(row);
                            }
                            
                            var pendingUpload = _fileUploadRepository.GetPendingUploads("MER Data");
                            pendingUpload.Status = "Completed";
                            _fileUploadRepository.UpdateFile(pendingUpload);

                            string json = JsonConvert.SerializeObject(dataTable, Formatting.Indented);
                            var deserializedData = JsonConvert.DeserializeObject<MerData[]>(json);
                            listMerData.AddRange(deserializedData.ToList());
                            listMerData.ForEach(z => z.FileUploadsId = pendingUpload.Id);
                            if (listMerData.Any())
                            {
                                _merDataRepository.Insert(listMerData);
                            }
                        }
                    }
                }
                await blob.DeleteIfExistsAsync();
                await _progressHubContext.Clients.All.SendAsync("Completed", extractProgress);
                return dataTable;
            }

            if (uploadTypeId == 2)
            {
                // var plHIVData = new FileUploads
                // {
                //     Name = blobName,
                //     ContentType = "text/plain",
                //     // User = user,
                //     UploadDate = DateTime.Now,
                //     Status = "Processing",
                //     UploadType = "PLHIV Data"
                // };
                // _fileUploadRepository.Insert(plHIVData);
                var blob = _container.GetBlockBlobReference(blobName);
                // Get the size of the blob
                await blob.FetchAttributesAsync();
                long blobSize = blob.Properties.Length;
                
                // Set the chunk size to 100MB
                int chunkSize = 50 * 1024 * 1024;

                var dataTable = new DataTable();
                // Loop through the blob in chunks of 100MB
                for (long offset = 0; offset < blobSize; offset += chunkSize)
                {
                    extractProgress.Value = offset/blobSize;
                    await _progressHubContext.Clients.All.SendAsync("Progress", extractProgress);
                    long bytesToRead = Math.Min(chunkSize, blobSize - offset);
                    using (var memoryStream = new MemoryStream())
                    {
                        // Download the chunk to memory stream
                        await blob.DownloadRangeToStreamAsync(memoryStream, offset, bytesToRead);
                        // Seek to the beginning of the memory stream
                        memoryStream.Seek(0, SeekOrigin.Begin);
                        using (var streamReader = new StreamReader(memoryStream))
                        {
                            List<PLHIVData> listPLHIVData = new List<PLHIVData>();
                            char[] delimiter = new char[] { '\t' };
                            var headers = streamReader.ReadLine().Split(delimiter);
                            foreach (var header in headers)
                            {
                                dataTable.Columns.Add(header);
                            }

                            while (!streamReader.EndOfStream)
                            {
                                var line = streamReader.ReadLine();
                                var values = line.Split(delimiter);

                                var row = dataTable.NewRow();
                                for (int i = 0; i < headers.Length; i++)
                                {
                                    if (values.ElementAtOrDefault(i) != null)
                                    {
                                        row[i] = values[i];
                                    }
                                }
                                dataTable.Rows.Add(row);
                            }
                            
                            var pendingUpload = _fileUploadRepository.GetPendingUploads("PLHIV Data");
                            pendingUpload.Status = "Completed";
                            _fileUploadRepository.UpdateFile(pendingUpload);

                            string json = JsonConvert.SerializeObject(dataTable, Formatting.Indented);
                            var deserializedData = JsonConvert.DeserializeObject<PLHIVData[]>(json);
                            listPLHIVData.AddRange(deserializedData.ToList());
                            listPLHIVData.ForEach(z => z.FileUploadsId = pendingUpload.Id);
                            if (listPLHIVData.Any())
                            {
                                _plhivDataRepository.Insert(listPLHIVData);
                            }
                        }
                    }
                }
                await blob.DeleteIfExistsAsync();
                await _progressHubContext.Clients.All.SendAsync("Completed", extractProgress);
                return dataTable;
            }

            return new DataTable();
        }
        catch (Exception e)
        {
            var pendingUpload = _fileUploadRepository.GetPendingUploads(uploadTypeId == 1 ? "MER Data" : "PLHIV Data");
            pendingUpload.Status = "Error";
            pendingUpload.ErrorMessage = $"{e.Message} {e}";
            _fileUploadRepository.UpdateFile(pendingUpload);
            _logger.LogError($"{e.Message} {e}");
            return new DataTable();
        }
    }

    public async Task<List<string>> GetBlobNameAsync()
    {
        try
        {
            List<string> blobNames = new List<string>();
            var connectionString = _configuration.GetConnectionString("AzureStorage");
            // Create a BlobServiceClient object
            BlobServiceClient blobServiceClient = new BlobServiceClient(connectionString);

            // Get a reference to the container
            BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient("merplhiv");

            // List all blobs in the container
            await foreach (BlobItem blobItem in containerClient.GetBlobsAsync())
            {
                if (!blobItem.Deleted)
                {
                    blobNames.Add(blobItem.Name);
                }
            }

            return blobNames;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}