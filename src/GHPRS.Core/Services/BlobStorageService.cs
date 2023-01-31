using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using GHPRS.Core.Entities;
using GHPRS.Core.Interfaces;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace GHPRS.Core.Services;

public class BlobStorageService : IBlobStorageService
{
    private readonly CloudBlobContainer _container;
    private readonly IMerDataRepository _merDataRepository;
    private readonly IFileUploadRepository _fileUploadRepository;
    private readonly IPLHIVDataRepository _plhivDataRepository;
    
    public BlobStorageService(
        IConfiguration configuration,
        IMerDataRepository merDataRepository,
        IPLHIVDataRepository plhivDataRepository,
        IFileUploadRepository fileUploadRepository)
    {
        _merDataRepository = merDataRepository;
        _fileUploadRepository = fileUploadRepository;
        _plhivDataRepository = plhivDataRepository;
        
        var connectionString = configuration.GetConnectionString("AzureStorage");
        var account = CloudStorageAccount.Parse(connectionString);
        var client = account.CreateCloudBlobClient();
        _container = client.GetContainerReference("merplhiv");
    }
    
    public async Task<DataTable> GetTextAsync(string blobName, int uploadTypeId)
    {
        if (uploadTypeId == 1)
        {
            var merData = new FileUploads
            {
                Name = blobName,
                ContentType = "text/plain",
                // User = user,
                UploadDate = DateTime.Now,
                Status = "Processing",
                UploadType = "MER Data"
            };
            _fileUploadRepository.Insert(merData);
            var blob = _container.GetBlockBlobReference(blobName);
            using (var memoryStream = new MemoryStream())
            {
                await blob.DownloadToStreamAsync(memoryStream);
                memoryStream.Seek(0, SeekOrigin.Begin);
                using (var streamReader = new StreamReader(memoryStream))
                {
                    List<MerData> listMerData = new List<MerData>();
                    var dataTable = new DataTable();
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
                            row[i] = values[i];
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
                    return dataTable;
                }
            }
        }
        
        var plHIVData = new FileUploads
        {
            Name = blobName,
            ContentType = "text/plain",
            // User = user,
            UploadDate = DateTime.Now,
            Status = "Processing",
            UploadType = "PLHIV Data"
        };
        _fileUploadRepository.Insert(plHIVData);
        var blobPLHIV = _container.GetBlockBlobReference(blobName);
        using (var memoryStream = new MemoryStream())
        {
            await blobPLHIV.DownloadToStreamAsync(memoryStream);
            memoryStream.Seek(0, SeekOrigin.Begin);
            using (var streamReader = new StreamReader(memoryStream))
            {
                List<PLHIVData> listPLHIVData = new List<PLHIVData>();
                var dataTable = new DataTable();
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
                        row[i] = values[i];
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
                return dataTable;
            }
        }
    }
}