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
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrganizationsController : ControllerBase
    {
        private readonly ILogger<OrganizationsController> _logger;
        private readonly IOrganizationRepository _organizationRepository;

        public OrganizationsController(ILogger<OrganizationsController> logger,
            IOrganizationRepository organizationRepository)
        {
            _logger = logger;
            _organizationRepository = organizationRepository;
        }

        [HttpGet("{id}")]
        public object GetById(int id)
        {
            return _organizationRepository.GetById(id);
        }

        [HttpGet]
        public IEnumerable<object> GetList()
        {
            return _organizationRepository.GetAll();
        }

        [HttpPost]
        public IActionResult RegisterOrganization([FromBody] Organization organization)
        {
            try
            {
                _organizationRepository.Insert(organization);
                return Ok(organization);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);

                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}