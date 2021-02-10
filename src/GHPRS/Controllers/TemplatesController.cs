using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using GHPRS.Core.Entities;
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

        public TemplatesController(ILogger<TemplatesController> logger, ITemplateService templateService,
            ITemplateRepository templateRepository, IWorkSheetRepository workSheetRepository,
            IColumnRepository columnRepository)
        {
            _logger = logger;
            _templateService = templateService;
            _templateRepository = templateRepository;
            _workSheetRepository = workSheetRepository;
            _columnRepository = columnRepository;
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
                    _templateRepository.CreateTemplateTable(workSheet);
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
    }
}