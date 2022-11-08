using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GHPRS.Core.Entities.ETL;
using GHPRS.Core.Interfaces;
using GHPRS.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace GHPRS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DownloadsController : ControllerBase
    {
        private readonly IEtlDataRepository<AgeDisaggregate> _etlAgeDisaggregateRepository;
        private readonly IEtlDataRepository<Council> _etlCouncilsRepository;
        private readonly IEtlDataRepository<CxStatus> _etlCxStatusRepository;
        private readonly IEtlDataRepository<DataSource> _etlDataSourceRepository;
        private readonly IEtlDataRepository<HivStatus> _etlHivStatusRepository;
        private readonly IEtlDataRepository<HivTreatmentStatus> _etlHivTreatmentStatusRepository;
        private readonly IEtlDataRepository<Measure> _etlMeasureRepository;
        private readonly IEtlDataRepository<Mechanism> _etlMechanismRepository;
        private readonly IEtlDataRepository<Modality> _etlModalityRepository;
        private readonly IEtlDataRepository<Period> _etlPeriodRepository;
        private readonly IEtlDataRepository<Region> _etlRegionRepository;
        private readonly IEtlDataRepository<SexDisaggregates> _etlSexDisaggregatesRepository;
        private readonly IEtlDataRepository<Site> _etlSiteRepository;
        private readonly IEtlDataRepository<TbStatus> _etlTbStatusRepository;
        private readonly IEtlDataRepository<Ward> _etlWardRepository;
        
        private readonly ILogger<DownloadsController> _logger;

        public DownloadsController(
            IEtlDataRepository<AgeDisaggregate> etlAgeDisaggregateRepository,
            IEtlDataRepository<Council> etlCouncilsRepository,
            IEtlDataRepository<CxStatus> etlCxStatusRepository,
            IEtlDataRepository<DataSource> etlDataSourceRepository,
            IEtlDataRepository<HivStatus> etlHivStatusRepository,
            IEtlDataRepository<HivTreatmentStatus> etlHivTreatmentStatusRepository,
            IEtlDataRepository<Measure> etlMeasureRepository,
            IEtlDataRepository<Mechanism> etlMechanismRepository,
            IEtlDataRepository<Modality> etlModalityRepository,
            IEtlDataRepository<Period> etlPeriodRepository,
            IEtlDataRepository<Region> etlRegionRepository,
            IEtlDataRepository<SexDisaggregates> etlSexDisaggregatesRepository,
            IEtlDataRepository<Site> etlSiteRepository,
            IEtlDataRepository<TbStatus> etlTbStatusRepository,
            IEtlDataRepository<Ward> etlWardRepository,
            ILogger<DownloadsController> logger)
        {
            _etlAgeDisaggregateRepository = etlAgeDisaggregateRepository;
            _etlCouncilsRepository = etlCouncilsRepository;
            _etlCxStatusRepository = etlCxStatusRepository;
            _etlDataSourceRepository = etlDataSourceRepository;
            _etlHivStatusRepository = etlHivStatusRepository;
            _etlHivTreatmentStatusRepository = etlHivTreatmentStatusRepository;
            _etlMeasureRepository = etlMeasureRepository;
            _etlMechanismRepository = etlMechanismRepository;
            _etlModalityRepository = etlModalityRepository;
            _etlPeriodRepository = etlPeriodRepository;
            _etlRegionRepository = etlRegionRepository;
            _etlSexDisaggregatesRepository = etlSexDisaggregatesRepository;
            _etlSiteRepository = etlSiteRepository;
            _etlTbStatusRepository = etlTbStatusRepository;
            _etlWardRepository = etlWardRepository;
            _logger = logger;
        }

        [HttpGet("GetAgeDisaggregates")]
        [AllowAnonymous]
        public IActionResult GetAgeDisaggregates()
        {
            try
            {
                var ageDisaggregates = _etlAgeDisaggregateRepository.GetAll().ToList();
                return Ok(ageDisaggregates);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
        
        [HttpGet("GetCouncils")]
        [AllowAnonymous]
        public IActionResult GetCouncils()
        {
            try
            {
                var councils = _etlCouncilsRepository.GetAll().ToList();
                return Ok(councils);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
        
        [HttpGet("GetCxStatus")]
        [AllowAnonymous]
        public IActionResult GetCxStatus()
        {
            try
            {
                var cxStatus = _etlCxStatusRepository.GetAll().ToList();
                return Ok(cxStatus);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
        
        [HttpGet("GetDataSource")]
        [AllowAnonymous]
        public IActionResult GetDataSource()
        {
            try
            {
                var dataSources = _etlDataSourceRepository.GetAll().ToList();
                return Ok(dataSources);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
        
        [HttpGet("GetHivStatus")]
        [AllowAnonymous]
        public IActionResult GetHivStatus()
        {
            try
            {
                var hivStatus = _etlHivStatusRepository.GetAll().ToList();
                return Ok(hivStatus);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
        
        [HttpGet("GetHivTreatmentStatus")]
        [AllowAnonymous]
        public IActionResult GetHivTreatmentStatus()
        {
            try
            {
                var hivTreatmentStatus = _etlHivTreatmentStatusRepository.GetAll().ToList();
                return Ok(hivTreatmentStatus);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
        
        [HttpGet("GetMeasures")]
        [AllowAnonymous]
        public IActionResult GetMeasures([FromQuery] ETLParameters ownerParameters)
        {
            try
            {
                var measures = _etlMeasureRepository.GetAll(ownerParameters);
                var metadata = new
                {
                    measures.TotalCount,
                    measures.PageSize,
                    measures.CurrentPage,
                    measures.TotalPages,
                    measures.HasNext,
                    measures.HasPrevious
                };
                Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
                // _logger.LogInfo($"Returned {accounts.TotalCount} owners from database.");
                return Ok(measures);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
        
        [HttpGet("GetMechanisms")]
        [AllowAnonymous]
        public IActionResult GetMechanisms()
        {
            try
            {
                var mechanisms = _etlMechanismRepository.GetAll().ToList();
                return Ok(mechanisms);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
        
        [HttpGet("GetModalities")]
        [AllowAnonymous]
        public IActionResult GetModalities()
        {
            try
            {
                var modalities = _etlModalityRepository.GetAll().ToList();
                return Ok(modalities);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
        
        [HttpGet("GetPeriods")]
        [AllowAnonymous]
        public IActionResult GetPeriods()
        {
            try
            {
                var periods = _etlPeriodRepository.GetAll().ToList();
                return Ok(periods);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpGet("GetRegions")]
        [AllowAnonymous]
        public IActionResult GetRegions()
        {
            try
            {
                var regions = _etlRegionRepository.GetAll().ToList();
                return Ok(regions);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
        
        [HttpGet("GetSexDisaggregates")]
        [AllowAnonymous]
        public IActionResult GetSexDisaggregates()
        {
            try
            {
                var sexDisaggregates = _etlSexDisaggregatesRepository.GetAll().ToList();
                return Ok(sexDisaggregates);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
        
        [HttpGet("GetSites")]
        [AllowAnonymous]
        public IActionResult GetSites()
        {
            try
            {
                var sites = _etlSiteRepository.GetAll().ToList();
                return Ok(sites);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
        
        [HttpGet("GetTbStatus")]
        [AllowAnonymous]
        public IActionResult GetTbStatus()
        {
            try
            {
                var tbStatus = _etlTbStatusRepository.GetAll().ToList();
                return Ok(tbStatus);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
        
        [HttpGet("GetWards")]
        [AllowAnonymous]
        public IActionResult GetWards()
        {
            try
            {
                var wards = _etlWardRepository.GetAll().ToList();
                return Ok(wards);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}
