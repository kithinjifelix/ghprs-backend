using System;
using System.Collections.Generic;
using GHPRS.Core.Entities;
using GHPRS.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<User> _userManager;

        public OrganizationsController(ILogger<OrganizationsController> logger,
            IOrganizationRepository organizationRepository, UserManager<User> userManager)
        {
            _logger = logger;
            _organizationRepository = organizationRepository;
            _userManager = userManager;
        }

        [HttpGet("{id}")]
        public object GetbyId(int id)
        {
            return _organizationRepository.GetById(id);
        }

        [HttpGet]
        public IEnumerable<object> GetList()
        {
            return _organizationRepository.GetAll();
        }

        [HttpPost]
        public IActionResult newOrganisation([FromBody] Organization organisation)
        {
            try
            {
                _organizationRepository.Insert(organisation);
                return Ok(organisation);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);

                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}