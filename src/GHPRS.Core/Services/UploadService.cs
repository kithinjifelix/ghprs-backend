using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using GHPRS.Core.Entities;
using GHPRS.Core.Interfaces;
using GHPRS.Core.Models;
using GHPRS.Core.UnitOfWork;
using GHPRS.Core.Utilities;
using Hangfire;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using OfficeOpenXml;

namespace GHPRS.Core.Services
{
    public class UploadService : IUploadService
    {
        private readonly IExcelService _excelService;
        private readonly ILogger<UploadService> _logger;
        private readonly ITemplateRepository _templateRepository;
        private readonly IUploadRepository _uploadRepository;
        private readonly IWorkSheetRepository _worksheetRepository;
        private readonly IDataUnitOfWork _dataUnitOfWork;
        private readonly IOrganizationRepository _organizationRepository;
        private readonly IFileUploadRepository _fileUploadRepository;
        private readonly IMerDataRepository _merDataRepository;
        private readonly IFacilityDataRepository _facilityDataRepository;

        public UploadService(IUploadRepository uploadRepository, 
            ITemplateRepository templateRepository,
            ILogger<UploadService> logger, 
            IWorkSheetRepository workSheetRepository, 
            IExcelService excelService,
            IDataUnitOfWork dataUnitOfWork,
            IOrganizationRepository organizationRepository,
            IFileUploadRepository fileUploadRepository,
            IMerDataRepository merDataRepository,
            IFacilityDataRepository facilityDataRepository
            )
        {
            _uploadRepository = uploadRepository;
            _templateRepository = templateRepository;
            _worksheetRepository = workSheetRepository;
            _excelService = excelService;
            _logger = logger;
            _dataUnitOfWork = dataUnitOfWork;
            _organizationRepository = organizationRepository;
            _fileUploadRepository = fileUploadRepository;
            _merDataRepository = merDataRepository;
            _facilityDataRepository = facilityDataRepository;
        }

        public void InsertUploadData(int uploadId)
        {
            var upload = _uploadRepository.GetFullUploadById(uploadId);
            var worksheets = _worksheetRepository.GetFullWorkSheetsByTemplateId(upload.Template.Id);
            foreach (var worksheet in worksheets)
            {
                var range = worksheet.Range;
                var startIndex = range.IndexOf(":", StringComparison.Ordinal);
                var startAddress = range.Substring(0, startIndex);
                var rowColumn = Utility.ExcelRowAndColumn(startAddress);
                var memoryStream = new MemoryStream(upload.File);
                try
                {
                    //read uploaded data
                    var data = _excelService.ReadExcelWorkSheet(memoryStream, worksheet.Name, rowColumn.Item1,
                        rowColumn.Item2);

                    //remove all rows with columns containing either nothing or white space
                    var rows = data.Rows.Cast<DataRow>().Where(row => !row.ItemArray.All(field => field is DBNull
                        || string.CompareOrdinal(((string) field).Trim(), string.Empty) == 0));
                    var dataRows = rows.ToList();
                    if (dataRows.Count > 0)
                        data = dataRows.CopyToDataTable();
                    else
                        data.Rows.Clear();

                    if (data.Rows.Count > 0)
                        _uploadRepository.InsertToTable(worksheet, data, upload.UploadBatch, upload.UploadBatchGuid);
                }
                catch (Exception e)
                {
                    var uploadedTemplateFailed = _uploadRepository.GetById(uploadId);
                    uploadedTemplateFailed.IsProcessed = true;
                    uploadedTemplateFailed.UploadStatus = "Failed";
                    _uploadRepository.Update(uploadedTemplateFailed);
                    _logger.LogError(e.Message, e);
                    throw;
                }
            }

            // set the upload has been processed to prevent re-processing
            var uploadedTemplate = _uploadRepository.GetById(uploadId);
            uploadedTemplate.IsProcessed = true;
            uploadedTemplate.UploadStatus = "Successful";
            _uploadRepository.Update(uploadedTemplate);
        }

        public List<object> ReadUploadData(int uploadId)
        {
            var result = new List<object>();
            var upload = _uploadRepository.GetFullUploadById(uploadId);
            if (upload == null)
            {
                return new List<object>();
            }
            var worksheets = _worksheetRepository.GetFullWorkSheetsByTemplateId(upload.Template.Id);
            foreach (var worksheet in worksheets)
            {
                var range = worksheet.Range;
                var startIndex = range.IndexOf(":", StringComparison.Ordinal);
                var startAddress = range.Substring(0, startIndex);
                var rowColumn = Utility.ExcelRowAndColumn(startAddress);
                var memoryStream = new MemoryStream(upload.File);
                try
                {
                    //read uploaded data
                    var data = _excelService.ReadExcelWorkSheet(memoryStream, worksheet.Name, rowColumn.Item1,
                        rowColumn.Item2);

                    //remove all rows with columns containing either nothing or white space
                    var rows = data.Rows.Cast<DataRow>().Where(row => !row.ItemArray.All(field => field is DBNull
                        || string.CompareOrdinal(((string) field).Trim(), string.Empty) == 0));
                    var dataRows = rows.ToList();
                    if (dataRows.Count > 0) data = dataRows.CopyToDataTable();

                    var resultData = new
                    {
                        WorkSheet = worksheet.Name,
                        Data = data
                    };
                    result.Add(resultData);
                }
                catch (Exception e)
                {
                    _logger.LogError(e.Message, e);
                    throw;
                }
            }

            return result;
        }

        public async Task<Upload> Upload(UploadModel upload, User user, int organizationId)
        {
            try
            {
                // fileName to save
                var template = _templateRepository.GetById(upload.TemplateId);

                //overwrite if existing and still pending and similar period
                var existing = _uploadRepository.GetFullUploads().SingleOrDefault(x =>
                    x.Name == template.Name && x.Status == UploadStatus.Pending && x.User.Id == user.Id && x.StartDate == upload.StartDate && x.EndDate == upload.EndDate);
                if (existing != null) _uploadRepository.Delete(existing.Id);

                var initializedUpload = new Upload
                {
                    Name = template.Name,
                    FileExtension = template.FileExtension,
                    ContentType = upload.File.ContentType,
                    Status = UploadStatus.Pending,
                    StartDate = upload.StartDate,
                    EndDate = upload.EndDate,
                    User = user,
                    Template = template,
                    UploadBatchGuid = Guid.NewGuid(),
                    OrganizationId = organizationId
                };
                initializedUpload.GenerateUploadBatch();

                await using (var target = new MemoryStream())
                {
                    await upload.File.CopyToAsync(target);
                    initializedUpload.File = target.ToArray();
                }

                initializedUpload.UploadStatus = "Pending";
                var result = _uploadRepository.Insert(initializedUpload);
                return result;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                throw;
            }
            
        }

        public async Task<FileUploads> UploadMER(MERUploadModel merUploadModel, User user)
        {
            try
            {
                var merData = new FileUploads
                {
                    Name = merUploadModel.File.FileName,
                    ContentType = merUploadModel.File.ContentType,
                    User = user,
                    UploadDate = DateTime.Now,
                    Status = "Processing",
                    UploadType = "MER Data"
                };
                await using (var target = new MemoryStream())
                {
                    await merUploadModel.File.CopyToAsync(target);
                    merData.File = target.ToArray();
                }
                var result = _fileUploadRepository.Insert(merData);
                BackgroundJob.Enqueue<IUploadService>(x => x.InsertMerData());
                return result;
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public async Task<FileUploads> UploadFacilityData(MERUploadModel merUploadModel, User user)
        {
            try
            {
                var facilityData = new FileUploads()
                {
                    Name = merUploadModel.File.Name,
                    ContentType = merUploadModel.File.ContentType,
                    User = user,
                    UploadDate = DateTime.Now,
                    Status = "Processing",
                    UploadType = "Facility Data"
                };
                await using (var target = new MemoryStream())
                {
                    await merUploadModel.File.CopyToAsync(target);
                    facilityData.File = target.ToArray();
                }

                var result = _fileUploadRepository.Insert(facilityData);
                BackgroundJob.Enqueue<IUploadService>(x => x.InsertFacilityData());
                return result;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Review(Upload upload, Review review)
        {
            using (var transaction = _dataUnitOfWork.BeginTransaction(IsolationLevel.Snapshot))
            {
                try
                {
                    // change status to overWritten if existing and approved
                    var overWrite = _uploadRepository.GetFullUploads().FirstOrDefault(x =>
                        x.UploadBatch == upload.UploadBatch && x.Status == UploadStatus.Approved);

                    upload.Status = (UploadStatus)review.Status;
                    upload.Comments = review.Comments;

                    _uploadRepository.Update(upload);


                    // Extract data from approved templates
                    if ((UploadStatus)review.Status == UploadStatus.Approved)
                        BackgroundJob.Enqueue<IUploadService>(x => x.InsertUploadData(upload.Id));
                    
                    // Overwrite after insert of previous data
                    if (overWrite != null) BackgroundJob.Enqueue<IUploadService>(x => x.OverWriteApproved(overWrite.Id));
                    
                    transaction.Commit();
                    _dataUnitOfWork.Dispose();
                }
                catch (Exception e)
                {
                    transaction.RollbackAsync();
                    _dataUnitOfWork.Dispose();
                    _logger.LogError(e.Message, e);
                    throw e;
                }
            }
        }

        public void OverWriteApproved(int uploadId)
        {
            var overWrite = _uploadRepository.GetFullUploadById(uploadId);
            _uploadRepository.UpdateStatus(overWrite.Id, UploadStatus.OverWritten);
            var workSheets = _worksheetRepository.GetFullWorkSheetsByTemplateId(overWrite.Template.Id);
            foreach (var workSheet in workSheets)
            {
                _uploadRepository.DeleteFromTable(workSheet.TableName, overWrite.UploadBatch, overWrite.UploadBatchGuid);
            }
        }

        public async void InsertMerData()
        {
            try
            {
                DataTable datatable = new DataTable();
                char[] delimiter = new char[] { '\t' };
                List<MerData> merData = new List<MerData>();
                var pendingUpload = _fileUploadRepository.GetPendingUploads("MER Data");
                if (pendingUpload != null)
                {
                    using (var reader = new StreamReader(new MemoryStream(pendingUpload.File)))
                    {
                        string[] columnheaders = reader.ReadLine().Split(delimiter);
                        foreach (string columnheader in columnheaders)
                        {
                            datatable.Columns.Add(columnheader); // I've added the column headers here.
                        }
                        while (reader.Peek() >= 0)
                        {
                            DataRow datarow = datatable.NewRow();
                            datarow.ItemArray = reader.ReadLine().Split(delimiter);
                            datatable.Rows.Add(datarow);
                        }
                    }

                    pendingUpload.Status = "Completed";
                    _fileUploadRepository.Update(pendingUpload);

                    string json = JsonConvert.SerializeObject(datatable, Formatting.Indented);
                    var deserializedData = JsonConvert.DeserializeObject<MerData[]>(json);
                    merData.AddRange(deserializedData.ToList());
                    _merDataRepository.Insert(merData);
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                throw e;
            }
        }
        
        public void InsertFacilityData()
        {
            try
            {
                var pendingUpload = _fileUploadRepository.GetPendingUploads("Facility Data");
                if (pendingUpload != null)
                {
                    using (var memoryStream = new MemoryStream(pendingUpload.File))
                    {
                        using var excelPack = new ExcelPackage();
                        //Load excel stream
                        excelPack.Load(memoryStream);

                        //select worksheet
                        var worksheet = excelPack.Workbook.Worksheets.FirstOrDefault(x => x.Name == "Facility Data");
                        //Validate worksheet
                        if (worksheet != null)
                        {
                            var excelAsTable = new DataTable();
                            List<FacilityData> facilityData = new List<FacilityData>();
                            foreach (var firstRowCell in worksheet.Cells[5, 1, 5,
                                         worksheet.Dimension.End.Column])
                                //Get column details
                                if (!string.IsNullOrEmpty(firstRowCell.Text))
                                    excelAsTable.Columns.Add(firstRowCell.Text);

                            //Get row details
                            for (var rowNum = 6; rowNum <= worksheet.Dimension.End.Row; rowNum++)
                            {
                                var wsRow = worksheet.Cells[rowNum, 1, rowNum, excelAsTable.Columns.Count];
                                var row = excelAsTable.Rows.Add();
                                foreach (var cell in wsRow) row[cell.Start.Column - 1] = cell.Text;
                            }
                            
                            pendingUpload.Status = "Completed";
                            _fileUploadRepository.Update(pendingUpload);

                            string json = JsonConvert.SerializeObject(excelAsTable, Formatting.Indented);
                            var deserializedData = JsonConvert.DeserializeObject<FacilityData[]>(json);
                            facilityData.AddRange(deserializedData.ToList());
                            _facilityDataRepository.Insert(facilityData);
                        }
                        else
                        {
                            // Facility Data not provided
                        }
                    }
                }
                
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}