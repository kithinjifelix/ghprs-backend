using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GHPRS.Core.Entities.ETL;
using GHPRS.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GHPRS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DownloadsController : ControllerBase
    {
        private readonly IEtlDataRepository<AgeDisaggregate> _etlAgeDisaggregateRepository;
        
        public DownloadsController(IEtlDataRepository<AgeDisaggregate> etlAgeDisaggregateRepository)
        {
            _etlAgeDisaggregateRepository = etlAgeDisaggregateRepository;
        }

        [HttpGet("GetAgeDisaggregates")]
        [AllowAnonymous]
        public IActionResult GetAgeDisaggregates()
        {
            var ageDisaggregates = _etlAgeDisaggregateRepository.GetAll().ToList();
            return Ok(ageDisaggregates);
        }
    }
}
