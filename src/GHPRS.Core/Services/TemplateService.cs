using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.Policy;
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

        public List<WorkSheetModel> CreateWorkSheetDefinitions(Template template)
        {
            var createdWorksheets = new List<WorkSheetModel>();
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
                    var columnModels = new List<ColumnModel>();
                    foreach (var column in sheet.Columns)
                    {
                        var columnModel = new ColumnModel
                        {
                            Id = column.Id,
                            Name = column.Name,
                            Type = column.Type
                        };
                        columnModels.Add(columnModel);
                    }

                    var model = new WorkSheetModel
                    {
                        Name = sheet.Name,
                        Id = sheet.Id,
                        Columns = columnModels
                    };
                    createdWorksheets.Add(model);
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

        public async Task<List<WorkSheetModel>> Initialize(TemplateModel templateModel)
        {
            //Getting FileName
            var fileName = Path.GetFileName(templateModel.File.FileName);
            //Getting file Extension
            var fileExtension = Path.GetExtension(fileName);

            var existingTemplate = ExistingTemplateAndLatestVersion(templateModel.Name);

            var initializedTemplate = new Template
            {
                Name = templateModel.Name,
                FileExtension = fileExtension,
                Description = templateModel.Description,
                Frequency = (ReportingFrequency) templateModel.Frequency,
                Version = existingTemplate.Item2 + 1,
                ContentType = templateModel.File.ContentType,
                Status = TemplateStatus.NotConfigured
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

        public Tuple<bool, decimal> ExistingTemplateAndLatestVersion(string name)
        {
            var existingTemplates = _templateRepository.GetAll()
                .Where(x => String.Equals(x.Name, name, StringComparison.CurrentCultureIgnoreCase)).ToList();
            decimal latestVersion = 0;
            if(existingTemplates.Any())
                latestVersion = existingTemplates.Max(x => x.Version);
            return Tuple.Create(existingTemplates.Any(), latestVersion);
        }

        private IEnumerable<WorkSheet> ReadConfigurationFile(byte[] file)
        {
            try
            {
                var memoryStream = new MemoryStream(file);
                var configuration = _excelService.ReadExcelWorkSheet(memoryStream, "Configuration", 4, 1);
                var generatedType =
                    JsonConvert.DeserializeObject<IEnumerable<WorkSheet>>(JsonConvert.SerializeObject(configuration));
                var result = generatedType.Where(x => x.Name.Trim() != "");
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