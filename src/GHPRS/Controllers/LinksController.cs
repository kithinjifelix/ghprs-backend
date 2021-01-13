using System;
using System.Collections.Generic;
using GHPRS.Core.Entities;
using GHPRS.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GHPRS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class LinksController : ControllerBase
    {
        private readonly ILogger<LinksController> _logger;
        private readonly ILinkRepository _linkRepository;

        public LinksController(ILogger<LinksController> logger, ILinkRepository linkRepository)
        {
            _logger = logger;
            _linkRepository = linkRepository;
        }

        [HttpGet]
        public IEnumerable<Link> GetList()
        {
            return _linkRepository.GetAll();
        }

        [HttpGet("TYPE/{type}")]
        public IEnumerable<Link> GetByType(int type)
        {
            LinkType linkType = (LinkType)type;
            return _linkRepository.GetByType(linkType);
        }

        [HttpGet("EXTERNAL")]
        public IEnumerable<Link> GetExternalLinks()
        {
            return _linkRepository.GetByType(LinkType.External);
        }

        [HttpGet("DASHBOARD")]
        public IEnumerable<Link> GetDashboardLinks()
        {
            return _linkRepository.GetByType(LinkType.Dashboard);
        }

        [HttpGet("REPORT")]
        public IEnumerable<Link> GetReportLinks()
        {
            return _linkRepository.GetByType(LinkType.Report);
        }

        [HttpGet("TABLE")]
        public IEnumerable<Link> GetTableLinks()
        {
            return _linkRepository.GetByType(LinkType.Table);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _linkRepository.Delete(id);
                return Ok();
            }
            catch(Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
         }

        [HttpPut("{id}")]
        public IActionResult Review([FromBody] Link link)
        {
            try
            {
                _linkRepository.Update(link);
                return Ok(link);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}
