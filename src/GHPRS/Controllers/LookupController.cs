using System;
using System.Collections.Generic;
using System.Linq;
using GHPRS.Core.Entities;
using GHPRS.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GHPRS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class LookupController : ControllerBase
    {
        private readonly ILogger<LookupController> _logger;
        private readonly ILookupRepository _lookupRepository;

        public LookupController(ILogger<LookupController> logger, ILookupRepository lookupRepository)
        {
            _logger = logger;
            _lookupRepository = lookupRepository;
        }

        [HttpGet("TYPE/{type}")]
        public IEnumerable<Lookup> GetByType(int type)
        {
            LookupType lookupType = (LookupType)type;
            return _lookupRepository.GetByType(lookupType);
        }

        [HttpGet("GENDER")]
        public IEnumerable<Lookup> GetGender()
        {
            return _lookupRepository.GetByType(LookupType.Gender);
        }

        [HttpGet("MARITALSTATUS")]
        public IEnumerable<Lookup> GetMaritalStatus()
        {
            return _lookupRepository.GetByType(LookupType.MaritalStatus);
        }
    }
}
