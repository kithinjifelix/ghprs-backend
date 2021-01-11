using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GHPRS.Core.Entities;
using GHPRS.Core.Interfaces;
using GHPRS.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GHPRS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemplatesController : ControllerBase
    {

        private readonly ILogger<LookupController> _logger;
        private readonly ITemplateService _templateService;
        private readonly ITemplateRepository  _templateRepository;

        public TemplatesController(ILogger<LookupController> logger, ITemplateService templateService, ITemplateRepository templateRepository)
        {
            _logger = logger;
            _templateService = templateService;
            _templateRepository = templateRepository;
        }

        [HttpGet]
        public IEnumerable<object> GetList()
        {
            return _templateRepository.GetList();
        }

        [HttpGet("DOWNLOAD/{id}")]
        public FileResult Download(int id)
        {
            var fileDetails = _templateRepository.GetById(id);
            return File(fileDetails.File, fileDetails.ContentType, fileDetails.Name);
        }

        [HttpPost("INITIALIZE")]
        public async Task<IActionResult> Initialize([FromForm] TemplateModel template)
        {
            try
            {
                var result = new Template();
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
    }
}
