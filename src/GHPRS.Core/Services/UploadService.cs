using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using GHPRS.Core.Entities;
using GHPRS.Core.Interfaces;
using GHPRS.Core.Models;
using GHPRS.Core.Utilities;
using Hangfire;
using Microsoft.Extensions.Logging;

namespace GHPRS.Core.Services
{
    public class UploadService : IUploadService
    {
        private readonly IExcelService _excelService;
        private readonly ILogger<UploadService> _logger;
        private readonly ITemplateRepository _templateRepository;
        private readonly IUploadRepository _uploadRepository;
        private readonly IWorkSheetRepository _worksheetRepository;

        public UploadService(IUploadRepository uploadRepository, ITemplateRepository templateRepository,
            ILogger<UploadService> logger, IWorkSheetRepository workSheetRepository, IExcelService excelService)
        {
            _uploadRepository = uploadRepository;
            _templateRepository = templateRepository;
            _worksheetRepository = workSheetRepository;
            _excelService = excelService;
            _logger = logger;
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
                        _uploadRepository.InsertToTable(worksheet, data, upload.UploadBatch);
                }
                catch (Exception e)
                {
                    _logger.LogError(e.Message, e);
                    throw;
                }
            }
        }

        public List<object> ReadUploadData(int uploadId)
        {
            var result = new List<object>();
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

        public async Task<Upload> Upload(UploadModel upload, User user)
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
                Template = template
            };
            initializedUpload.GenerateUploadBatch();

            await using (var target = new MemoryStream())
            {
                await upload.File.CopyToAsync(target);
                initializedUpload.File = target.ToArray();
            }

            var result = _uploadRepository.Insert(initializedUpload);
            return result;
        }

        public void Review(Upload upload, Review review)
        {
            //change status to overWritten if existing and approved
            var overWrite = _uploadRepository.GetFullUploads().SingleOrDefault(x =>
                x.UploadBatch == upload.UploadBatch && x.Status == UploadStatus.Approved);

            if (overWrite != null) BackgroundJob.Enqueue<IUploadService>(x => x.OverWriteApproved(overWrite.Id));

            upload.Status = (UploadStatus)review.Status;
            upload.Comments = review.Comments;

            _uploadRepository.Update(upload);

            

            //Extract data from approved templates
            if ((UploadStatus)review.Status == UploadStatus.Approved)
                BackgroundJob.Enqueue<IUploadService>(x => x.InsertUploadData(upload.Id));
        }

        public void OverWriteApproved(int uploadId)
        {
            var overWrite = _uploadRepository.GetFullUploadById(uploadId);
            _uploadRepository.UpdateStatus(overWrite.Id, UploadStatus.OverWritten);
            var workSheets = _worksheetRepository.GetFullWorkSheetsByTemplateId(overWrite.Template.Id);
            foreach (var workSheet in workSheets)
            {
                _uploadRepository.DeleteFromTable(workSheet.TableName, overWrite.UploadBatch);
            }
        }
    }
}