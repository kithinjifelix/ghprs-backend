using System;
using System.Collections.Generic;
using GHPRS.Core.Entities;
using GHPRS.Core.Interfaces;
using GHPRS.Core.Models;
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

        [HttpPost]
        public IActionResult Add([FromBody] LinkModel model)
        {
            try
            {
                var link = new Link()
                {
                    Name = model.Name,
                    Url = model.Url,
                    LinkType = (LinkType)model.LinkType,
                    Number = model.Number,
                    Key = model.Key,
                };
                var result = _linkRepository.Insert(link);
                return Ok(result);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpGet]
        public IEnumerable<Link> GetList()
        {
            return _linkRepository.GetAll();
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = _linkRepository.GetById(id);
            return Ok(result);
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
                _logger.LogError(e.Message, e);
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromBody] Link link)
        {
            try
            {
                _linkRepository.Update(link);
                return Ok(link);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}
