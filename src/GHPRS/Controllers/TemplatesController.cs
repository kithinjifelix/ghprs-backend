using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using GHPRS.Core.Entities;
using GHPRS.Core.Interfaces;
using GHPRS.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Hangfire;
using static GHPRS.Core.Entities.Template;
using System.Linq;

namespace GHPRS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TemplatesController : ControllerBase
    {

        private readonly ILogger<TemplatesController> _logger;
        private readonly ITemplateService _templateService;
        private readonly ITemplateRepository _templateRepository;
        private readonly IWorkSheetRepository _workSheetRepository;
        private readonly UserManager<User> _userManager;

        public TemplatesController(ILogger<TemplatesController> logger, ITemplateService templateService, ITemplateRepository templateRepository, IWorkSheetRepository workSheetRepository, UserManager<User> userManager)
        {
            _logger = logger;
            _templateService = templateService;
            _templateRepository = templateRepository;
            _workSheetRepository = workSheetRepository;
            _userManager = userManager;
        }

        [HttpGet("{id}")]
        public object GetById(int id)
        {
            return _templateRepository.GetDetailsById(id);
        }

        [HttpGet]
        public IEnumerable<object> GetList()
        {
            var role = this.User.FindFirstValue(ClaimTypes.Role);
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
                var result = new List<WorkSheet>();
                if (template.File != null)
                {
                    if (template.File.Length > 0)
                    {
                        result = await _templateService.Initialize(template);
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
                return Ok(result);
            }
            catch(Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpPost("WORKSHEETS/UPDATE")]
        public IActionResult UpdateWorkSheetTables([FromBody] WorkSheetModel workSheetModel)
        {
            try
            {
                var workSheet = _workSheetRepository.GetFullWorkSheetById(workSheetModel.Id);
                foreach (var column in workSheet.Columns)
                {
                    var columnModel = workSheetModel.Columns.FirstOrDefault(w => w.Name == column.Name);
                    column.Type = columnModel.Type;
                }
                _workSheetRepository.Update(workSheet);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpPost("TABLES")]
        public  IActionResult CreateWorkSheetTables([FromBody] List<WorkSheetModel> workSheetModels)
        {
            try
            {
                foreach (var worksheetModel in workSheetModels)
                {
                    var workSheet = _workSheetRepository.GetFullWorkSheetById(worksheetModel.Id);
                    _templateRepository.CreateTemplateTable(workSheet);
                }
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpPut("{id}/STATUS/{status}")]
        public IActionResult Review(int id, int status)
        {
            try
            {
                var template = _templateRepository.GetById(id);

                template.Status = (TemplateStatus)status;

                _templateRepository.Update(template);
                return Ok(template);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}
