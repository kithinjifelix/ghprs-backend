using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        public IActionResult GetAgeDisaggregates(string type)
        {
            try
            {
                var ageDisaggregates = _etlAgeDisaggregateRepository.GetAll().ToList();
                if (type != null && type.ToLower() == "csv")
                {
                    return File(Encoding.UTF8.GetBytes(getEntityStringBuilder<AgeDisaggregate>(ageDisaggregates).ToString()), "text/csv", "AgeDisaggregates.csv");
                }
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
        public IActionResult GetCouncils(string type)
        {
            try
            {
                var councils = _etlCouncilsRepository.GetAll().ToList();
                if (type != null && type.ToLower() == "csv")
                {
                    return File(Encoding.UTF8.GetBytes(getEntityStringBuilder<Council>(councils).ToString()), "text/csv", "Councils.csv");
                }
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
        public IActionResult GetCxStatus(string type)
        {
            try
            {
                var cxStatus = _etlCxStatusRepository.GetAll().ToList();
                if (type != null && type.ToLower() == "csv")
                {
                    return File(Encoding.UTF8.GetBytes(getEntityStringBuilder<CxStatus>(cxStatus).ToString()), "text/csv", "CXStatus.csv");
                }
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
        public IActionResult GetDataSource(string type)
        {
            try
            {
                var dataSources = _etlDataSourceRepository.GetAll().ToList();
                if (type != null && type.ToLower() == "csv")
                {
                    return File(Encoding.UTF8.GetBytes(getEntityStringBuilder<DataSource>(dataSources).ToString()), "text/csv", "DataSources.csv");
                }
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
        public IActionResult GetHivStatus(string type)
        {
            try
            {
                var hivStatus = _etlHivStatusRepository.GetAll().ToList();
                if (type != null && type.ToLower() == "csv")
                {
                    return File(Encoding.UTF8.GetBytes(getEntityStringBuilder<HivStatus>(hivStatus).ToString()), "text/csv", "HIVStatus.csv");
                }
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
        public IActionResult GetHivTreatmentStatus(string type)
        {
            try
            {
                var hivTreatmentStatus = _etlHivTreatmentStatusRepository.GetAll().ToList();
                if (type != null && type.ToLower() == "csv")
                {
                    return File(Encoding.UTF8.GetBytes(getEntityStringBuilder<HivTreatmentStatus>(hivTreatmentStatus).ToString()), "text/csv", "HIVTreatmentStatus.csv");
                }
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
                if (ownerParameters.type != null && ownerParameters.type.ToLower() == "csv")
                {
                    var allMeasures = _etlMeasureRepository.GetAll(ownerParameters);
                    return File(Encoding.UTF8.GetBytes(getEntityStringBuilder<Measure>(allMeasures.ToList()).ToString()), "text/csv", "Measures.csv");
                }
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
        public IActionResult GetMechanisms(string type)
        {
            try
            {
                var mechanisms = _etlMechanismRepository.GetAll().ToList();
                if (type != null && type.ToLower() == "csv")
                {
                    return File(Encoding.UTF8.GetBytes(getEntityStringBuilder<Mechanism>(mechanisms).ToString()), "text/csv", "Mechanisms.csv");
                }
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
        public IActionResult GetModalities(string type)
        {
            try
            {
                var modalities = _etlModalityRepository.GetAll().ToList();
                if (type != null && type.ToLower() == "csv")
                {
                    return File(Encoding.UTF8.GetBytes(getEntityStringBuilder<Modality>(modalities).ToString()), "text/csv", "Modalities.csv");
                }
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
        public IActionResult GetPeriods(string type)
        {
            try
            {
                var periods = _etlPeriodRepository.GetAll().ToList();
                if (type != null && type.ToLower() == "csv")
                {
                    return File(Encoding.UTF8.GetBytes(getEntityStringBuilder<Period>(periods).ToString()), "text/csv", "Periods.csv");
                }
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
        public IActionResult GetRegions(string type)
        {
            try
            {
                var regions = _etlRegionRepository.GetAll().ToList();
                if (type != null && type.ToLower() == "csv")
                {
                    return File(Encoding.UTF8.GetBytes(getEntityStringBuilder<Region>(regions).ToString()), "text/csv", "Regions.csv");
                }
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
        public IActionResult GetSexDisaggregates(string type)
        {
            try
            {
                var sexDisaggregates = _etlSexDisaggregatesRepository.GetAll().ToList();
                if (type != null && type.ToLower() == "csv")
                {
                    return File(Encoding.UTF8.GetBytes(getEntityStringBuilder<SexDisaggregates>(sexDisaggregates).ToString()), "text/csv", "SexDisaggregates.csv");
                }
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
        public IActionResult GetSites(string type)
        {
            try
            {
                var sites = _etlSiteRepository.GetAll().ToList();
                if (type != null && type.ToLower() == "csv")
                {
                    return File(Encoding.UTF8.GetBytes(getEntityStringBuilder<Site>(sites).ToString()), "text/csv", "Sites.csv");
                }
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
        public IActionResult GetTbStatus(string type)
        {
            try
            {
                var tbStatus = _etlTbStatusRepository.GetAll().ToList();
                if (type != null && type.ToLower() == "csv")
                {
                    return File(Encoding.UTF8.GetBytes(getEntityStringBuilder<TbStatus>(tbStatus).ToString()), "text/csv", "TbStatus.csv");
                }
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
        public IActionResult GetWards(string type)
        {
            try
            {
                var wards = _etlWardRepository.GetAll().ToList();
                if (type != null && type.ToLower() == "csv")
                {
                    return File(Encoding.UTF8.GetBytes(getEntityStringBuilder<Ward>(wards).ToString()), "text/csv", "Wards.csv");
                }
                return Ok(wards);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        private StringBuilder getEntityStringBuilder<T>(List<T> result)
        {
            var columnNamesAppended = false;
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < result.Count; i++)
            {
                var stringPropertyNamesAndValues = result[i].GetType()
                    .GetProperties()
                    .Select(pi => new
                    {
                        pi.Name,
                        Value = pi.GetGetMethod().Invoke(result[i], null)
                    });
                if (!columnNamesAppended)
                {
                    var names = stringPropertyNamesAndValues.Select(x => x.Name).ToArray();
                    sb.Append(String.Join(",", names));
                    columnNamesAppended = true;
                    sb.Append("\r\n");
                }
                foreach (var pair in stringPropertyNamesAndValues)
                {
                    if(pair.Value == null)
                    {
                        sb.Append("" + ',');
                    }
                    else
                    {
                        sb.Append(pair.Value.ToString() + ',');
                    }
                }
                sb.Append("\r\n");
            }
            return sb;
        }
    }
}
