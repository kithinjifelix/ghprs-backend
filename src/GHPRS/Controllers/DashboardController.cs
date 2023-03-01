using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GHPRS.Core.Entities.ETL;
using GHPRS.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GHPRS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly IEtlDataRepository<Measure> _etlMeasureRepository;
        
        private readonly ILogger<DashboardController> _logger;

        public DashboardController(
            IEtlDataRepository<Measure> etlMeasureRepository,
            ILogger<DashboardController> logger)
        {
            _etlMeasureRepository = etlMeasureRepository;
            _logger = logger;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetFacilitiesReporting([FromQuery]QueryParameters queryParameters)
        {
            try
            {
                var sql = "SELECT COUNT(M.id) as count, P.fiscal_year as fiscal_year FROM data.\"Measures\" M INNER JOIN data.\"Periods\" P ON P.period_id = M.period_id WHERE is_target = 'N' AND plhiv_estimate = 'N' ";
                if (!string.IsNullOrEmpty(queryParameters.mechanism) && queryParameters.mechanism != "undefined")
                {
                    sql += $" AND M.mechanism_id = '{queryParameters.mechanism}'";
                }

                if (!string.IsNullOrEmpty(queryParameters.periodId) && queryParameters.periodId != "undefined")
                {
                    sql += $" AND M.period_id = '{queryParameters.periodId}'";
                }

                if (!string.IsNullOrEmpty(queryParameters.regionId) && queryParameters.regionId != "undefined")
                {
                    sql += $" AND M.org_unit_id = '{queryParameters.regionId}'";
                }

                if (!string.IsNullOrEmpty(queryParameters.indicatorId) && queryParameters.indicatorId != "undefined")
                {
                    sql += $" AND M.indicator = '{queryParameters.indicatorId}'";
                }
                sql += " GROUP BY P.fiscal_year ORDER BY P.fiscal_year;";
                var results = _etlMeasureRepository.ExecQuery<DataResult>(sql);
                return Ok(results);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpGet("GetMeasureIndicators")]
        public IActionResult GetMeasureIndicators()
        {
            try
            {
                var results = _etlMeasureRepository.ExecQuery<Indicator>("SELECT indicator FROM data.\"Measures\" GROUP BY indicator;");
                return Ok(results);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
            
    }

    public class DataResult
    {
        public int count { get; set; }
        public string fiscal_year { get; set; }
    }
    
    public class Indicator
    {
        public string indicator { get; set; }
    }

    public class QueryParameters
    {
        public string mechanism { get; set; }

        public string periodId { get; set; }

        public string regionId { get; set; }

        public string indicatorId { get; set; }
        // mechanism, periodId, regionId, indicatorId
    }
}
