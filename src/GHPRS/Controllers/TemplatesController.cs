using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using GHPRS.Core.Entities;
using GHPRS.Core.Entities.ETL;
using GHPRS.Core.Interfaces;
using GHPRS.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using static GHPRS.Core.Entities.Template;

namespace GHPRS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TemplatesController : ControllerBase
    {
        private readonly IColumnRepository _columnRepository;

        private readonly ILogger<TemplatesController> _logger;
        private readonly ITemplateRepository _templateRepository;
        private readonly ITemplateService _templateService;
        private readonly IWorkSheetRepository _workSheetRepository;
        private readonly IEtlDataRepository<Measure> _etlMeasureRepository;

        public TemplatesController(ILogger<TemplatesController> logger, 
            ITemplateService templateService,
            ITemplateRepository templateRepository, 
            IWorkSheetRepository workSheetRepository,
            IEtlDataRepository<Measure> etlMeasureRepository,
            IColumnRepository columnRepository)
        {
            _logger = logger;
            _templateService = templateService;
            _templateRepository = templateRepository;
            _workSheetRepository = workSheetRepository;
            _columnRepository = columnRepository;
            _etlMeasureRepository = etlMeasureRepository;
        }

        [HttpGet("{id}")]
        public object GetById(int id)
        {
            return _templateRepository.GetDetailsById(id);
        }

        [HttpGet]
        public IEnumerable<object> GetList()
        {
            var role = User.FindFirstValue(ClaimTypes.Role);
            return _templateRepository.GetList(role);
        }

        [HttpGet("DOWNLOAD/{id}")]
        [AllowAnonymous]
        public FileResult Download(int id)
        {
            var fileDetails = _templateRepository.GetById(id);
            return File(fileDetails.File, fileDetails.ContentType, fileDetails.Name + fileDetails.FileExtension);
        }

        [HttpPost("INITIALIZE")]
        public async Task<IActionResult> Initialize([FromForm] TemplateModel template)
        {
            try
            {
                List<WorkSheetModel> result;
                if (template.File != null)
                {
                    if (template.File.Length > 0)
                        result = await _templateService.Initialize(template);
                    else
                        return StatusCode(StatusCodes.Status500InternalServerError, "File contains no data");
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "No File selected");
                }

                return Ok(result);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpPost("UPDATETEMPLATE/{id}")]
        public async Task<IActionResult> UpdateTemplate(int id, [FromForm] TemplateModelUpdated templateModelUpdated)
        {
            try
            {
                if (templateModelUpdated.File != null)
                {
                    if (templateModelUpdated.File.Length > 0)
                    {
                        await _templateService.UpdateTemplate(id, templateModelUpdated);
                        return Ok("Successfully updated template");
                    }
                    else
                    {
                        return StatusCode(StatusCodes.Status500InternalServerError, "File contains no data");
                    }
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "No File selected");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpPut("WORKSHEET/UPDATE/{workSheetId}")]
        public IActionResult UpdateWorkSheetTables(int workSheetId, [FromBody] List<ColumnModel> columnModels)
        {
            try
            {
                var workSheet = _workSheetRepository.GetFullWorkSheetById(workSheetId);
                foreach (var columnModel in columnModels)
                {
                    var column = _columnRepository.GetById(columnModel.Id);
                    column.Type = columnModel.Type;
                    _columnRepository.Update(column);
                }

                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpPost("TABLES")]
        public IActionResult CreateWorkSheetTables([FromBody] List<WorkSheetModel> workSheetModels)
        {
            try
            {
                var workSheet = new WorkSheet();
                foreach (var worksheetModel in workSheetModels)
                {
                    workSheet = _workSheetRepository.GetFullWorkSheetById(worksheetModel.Id);
                    if (workSheet.Name != "Community Data" && workSheet.Name != "Facility Data" && workSheet.Name != "TB")
                    {
                        _templateRepository.CreateTemplateTable(workSheet);
                    }
                    else if (workSheet.Name == "Community Data")
                    {
                        var additionalColumns = new List<string>();
                        var columns = _etlMeasureRepository.ExecQuery<InformationSchema>(
                            "SELECT column_name, data_type FROM information_schema.columns WHERE table_name = 'StagingCommunityData'");

                        var worksheetColumns = workSheet.Columns;
                        foreach (var column in worksheetColumns)
                        {
                            var columnNotInDB = columns.Where(x => x.column_name == column.Name);
                            if (!columnNotInDB.Any())
                            {
                                additionalColumns.Add(column.Name);
                            }
                        }

                        if (additionalColumns.Any())
                        {
                            _templateRepository.UpdateStaticTable("StagingCommunityData", additionalColumns);
                        }
                    } 
                    else if (workSheet.Name == "Facility Data")
                    {
                        var additionalColumns = new List<string>();
                        var columns = _etlMeasureRepository.ExecQuery<InformationSchema>(
                            "SELECT column_name, data_type FROM information_schema.columns WHERE table_name = 'StagingFacilityData'");

                        var worksheetColumns = workSheet.Columns;
                        foreach (var column in worksheetColumns)
                        {
                            var columnNotInDB = columns.Where(x => x.column_name.Trim() == column.Name.Trim());
                            if (!columnNotInDB.Any())
                            {
                                additionalColumns.Add(column.Name);
                            }
                        }

                        if (additionalColumns.Any())
                        {
                            _templateRepository.UpdateStaticTable("StagingFacilityData", additionalColumns);
                        }
                    }
                    else if (workSheet.Name == "TB")
                    {
                        var additionalColumns = new List<string>();
                        var columns = _etlMeasureRepository.ExecQuery<InformationSchema>(
                            "SELECT column_name, data_type FROM information_schema.columns WHERE table_name = 'StagingTBData'");

                        var worksheetColumns = workSheet.Columns;
                        foreach (var column in worksheetColumns)
                        {
                            var columnNotInDB = columns.Where(x => x.column_name == column.Name);
                            if (!columnNotInDB.Any())
                            {
                                additionalColumns.Add(column.Name);
                            }
                        }

                        if (additionalColumns.Any())
                        {
                            _templateRepository.UpdateStaticTable("StagingTBData", additionalColumns);
                        }
                    }
                }
                _templateRepository.UpdateStatus(workSheet.TemplateId, TemplateStatus.Active);
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpPut("{id}/STATUS/{status}")]
        public IActionResult Review(int id, int status)
        {
            try
            {
                var template = _templateRepository.GetById(id);

                template.Status = (TemplateStatus) status;

                _templateRepository.Update(template);
                return Ok(template);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpGet("CONFIGURE/{id}")]
        public IActionResult Configure(int id)
        {
            var result = new List<WorkSheetModel>();
            var workSheets = _workSheetRepository.GetFullWorkSheetsByTemplateId(id);
            foreach (var workSheet in workSheets)
            {
                var columns = new List<ColumnModel>();
                foreach (var col in workSheet.Columns)
                {
                    var column = new ColumnModel
                    {
                        Id = col.Id,
                        Name = col.Name,
                        Type = col.Type
                    };
                    columns.Add(column);
                }

                var item = new WorkSheetModel
                {
                    Id = workSheet.Id,
                    Name = workSheet.Name,
                    Columns = columns
                };
                result.Add(item);
            }

            return Ok(result);
        }

        [HttpGet("EXISTS")]
        public IActionResult CheckExistingTemplate([FromQuery]string template)
        {
            try
            {
                if (template == null)
                    return BadRequest();
                var exists = _templateService.ExistingTemplateAndLatestVersion(template);
                return Ok(exists);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }

    public class InformationSchema
    {
        public string column_name { get; set; }
        public string data_type { get; set; }
    }
}