using GHPRS.Core.Entities;
using GHPRS.Core.Interfaces;
using GHPRS.Core.Models;
using GHPRS.Core.Utilities;
using Microsoft.Extensions.Logging;
using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GHPRS.Core.Services
{
    public class UploadService : IUploadService
    {
        private readonly IUploadRepository _uploadRepository;
        private readonly ITemplateRepository _templateRepository;
        private readonly IWorkSheetRepository _worksheetRepository;
        private readonly IExcelService _excelService;
        private readonly ILogger<UploadService> _logger;
        public UploadService(IUploadRepository uploadRepository, ITemplateRepository templateRepository, ILogger<UploadService> logger, IWorkSheetRepository workSheetRepository, IExcelService excelService)
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
                int startIndex = range.IndexOf(":");
                var startAddress = range.Substring(0, startIndex);
                var rowColumn = Utility.ExcelRowAndColumn(startAddress);
                MemoryStream memoryStream = new MemoryStream(upload.File);
                try
                {
                    //read uploaded data
                    var data = _excelService.ReadExcelWorkSheet(memoryStream, worksheet.Name, rowColumn.Item1, rowColumn.Item2);

                    //remove all rows with columns containing either nothing or white space
                    data = data.Rows.Cast<DataRow>().Where(row => !row.ItemArray.All(field => field is DBNull 
                           || string.Compare((field as string).Trim(), string.Empty) == 0)).CopyToDataTable();

                    _uploadRepository.InsertToTable(worksheet, data);
                }
                catch (Exception e)
                {
                    _logger.LogError(e.Message, e);
                    throw e;
                }
            }
        }

        public async Task<Upload> Upload(UploadModel upload, User user)
        {
            // fileName to save
            var template = _templateRepository.GetById(upload.TemplateId);

            var initializedUpload = new Upload()
            {
                Name = template.Name,
                FileExtension = template.FileExtension,
                ContentType = upload.File.ContentType,
                Status = UploadStatus.pending,
                StartDate = upload.StartDate,
                EndDate = upload.EndDate,
                User = user,
                Template = template
            };

            using (var target = new MemoryStream())
            {
                await upload.File.CopyToAsync(target);
                initializedUpload.File = target.ToArray();
            }

            var result = _uploadRepository.Insert(initializedUpload);
            return result;
        }
    }
}
