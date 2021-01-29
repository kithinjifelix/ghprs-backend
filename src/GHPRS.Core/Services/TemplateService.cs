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
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using static GHPRS.Core.Entities.Template;

namespace GHPRS.Core.Services
{
    public class TemplateService : ITemplateService
    {
        private readonly IExcelService _excelService;
        private readonly ILogger<TemplateService> _logger;
        private readonly ITemplateRepository _templateRepository;
        private readonly IWorkSheetRepository _workSheetRepository;

        public TemplateService(ITemplateRepository templateRepository, IExcelService excelService,
            ILogger<TemplateService> logger, IWorkSheetRepository workSheetRepository)
        {
            _templateRepository = templateRepository;
            _workSheetRepository = workSheetRepository;
            _excelService = excelService;
            _logger = logger;
        }

        public List<WorkSheet> CreateWorkSheetDefinitions(Template template)
        {
            var createdWorksheets = new List<WorkSheet>();
            try
            {
                var configuration = ReadConfigurationFile(template.File);
                foreach (var worksheet in configuration)
                {
                    var range = worksheet.Range;
                    var startIndex = range.IndexOf(":", StringComparison.Ordinal);
                    var startAddress = range.Substring(0, startIndex);
                    var rowColumn = Utility.ExcelRowAndColumn(startAddress);
                    var memoryStream = new MemoryStream(template.File);
                    var data = _excelService.ReadExcelWorkSheet(memoryStream, worksheet.Name, rowColumn.Item1,
                        rowColumn.Item2);
                    var sheet = SaveWorkSheetDetails(worksheet, data, template);
                    createdWorksheets.Add(sheet);
                    //_templateRepository.CreateTemplateTable(sheet.TableName, data);
                }

                return createdWorksheets;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                throw;
            }
        }

        public async Task<List<WorkSheet>> Initialize(TemplateModel templateModel)
        {
            //Getting FileName
            var fileName = Path.GetFileName(templateModel.File.FileName);
            //Getting file Extension
            var fileExtension = Path.GetExtension(fileName);

            var initializedTemplate = new Template
            {
                Name = templateModel.Name,
                FileExtension = fileExtension,
                Description = templateModel.Description,
                Frequency = (ReportingFrequency) templateModel.Frequency,
                Version = templateModel.Version,
                ContentType = templateModel.File.ContentType,
                Status = TemplateStatus.Active
            };

            using (var target = new MemoryStream())
            {
                await templateModel.File.CopyToAsync(target);
                initializedTemplate.File = target.ToArray();
            }

            var template = _templateRepository.Insert(initializedTemplate);

            var worksheets = CreateWorkSheetDefinitions(template);

            return worksheets;
        }

        private IEnumerable<WorkSheet> ReadConfigurationFile(byte[] file)
        {
            try
            {
                var memoryStream = new MemoryStream(file);
                var configuration = _excelService.ReadExcelWorkSheet(memoryStream, "Configuration", 4, 1);
                var generatedType =
                    JsonConvert.DeserializeObject<IEnumerable<WorkSheet>>(JsonConvert.SerializeObject(configuration));
                var result = generatedType.Where(x => x.Name != "");
                return result;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                throw;
            }
        }

        private WorkSheet SaveWorkSheetDetails(WorkSheet workSheet, DataTable dataTable, Template template)
        {
            var columns = new List<Column>();
            foreach (var item in dataTable.Columns)
            {
                var columnName = item.ToString();
                // Max table name length is 63 characters therefore truncate if longer
                if (columnName.Length > 63) columnName = columnName.TruncateLongString(63);

                var column = new Column
                {
                    Name = columnName,
                    Type = "TEXT"
                };
                columns.Add(column);
            }

            var newWorkSheet = new WorkSheet
            {
                Name = workSheet.Name,
                Range = workSheet.Range,
                TemplateId = template.Id,
                Columns = columns
            };
            newWorkSheet.GenerateDatabaseTableName(workSheet.Name, template.Name, template.Version);
            _workSheetRepository.Insert(newWorkSheet);
            return newWorkSheet;
        }
    }
}