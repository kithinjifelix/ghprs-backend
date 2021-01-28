using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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
using System.Security.Claims;

namespace GHPRS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrganisationsController : ControllerBase
    {
        private readonly ILogger<OrganisationsController> _logger;
        private readonly IOrganisationRepository _organisationRepository;
        private readonly UserManager<User> _userManager;

        public OrganisationsController(ILogger<OrganisationsController> logger, IOrganisationRepository organisationRepository, UserManager<User> userManager)
        {
            _logger = logger;
            _organisationRepository = organisationRepository;
            _userManager = userManager;
        }
        [HttpGet("{id}")]
        public object GetbyId(int id)
        {
            return _organisationRepository.GetById(id);
        }
        [HttpGet]
        public IEnumerable<object> GetList()
        {
            return _organisationRepository.GetAll();
        }

        [HttpPost]
        public IActionResult newOrganisation([FromBody] Organisation organisation)
        {
            try
            {
                _organisationRepository.Insert(organisation);
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
