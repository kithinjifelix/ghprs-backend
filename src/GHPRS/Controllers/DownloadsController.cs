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
        private readonly IEtlDataRepository<Council> _etlCouncilsRepository;
        private readonly IEtlDataRepository<CxStatus> _etlCxStatusRepository;
        private readonly IEtlDataRepository<DataSource> _etlDataSourceRepository;
        private readonly IEtlDataRepository<HivStatus> _etlHivStatusRepository;
        private readonly IEtlDataRepository<HivTreatmentStatus> _etlHivTreatmentStatusRepository;
        private readonly IEtlDataRepository<Measure> _etlMeasureRepository;
        private readonly IEtlDataRepository<Mechanism> _etlMechanismRepository;
        private readonly IEtlDataRepository<Modality> _etlModalityRepository;
        private readonly IEtlDataRepository<Period> _etlPeriodRepository;
        private readonly IEtlDataRepository<PlhivEstimate> _etlPlhivEstimateRepository;
        private readonly IEtlDataRepository<Region> _etlRegionRepository;
        private readonly IEtlDataRepository<SexDisaggregates> _etlSexDisaggregatesRepository;
        private readonly IEtlDataRepository<Site> _etlSiteRepository;
        private readonly IEtlDataRepository<TbStatus> _etlTbStatusRepository;
        private readonly IEtlDataRepository<Ward> _etlWardRepository;

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
            IEtlDataRepository<PlhivEstimate> etlPlhivEstimateRepository,
            IEtlDataRepository<Region> etlRegionRepository,
            IEtlDataRepository<SexDisaggregates> etlSexDisaggregatesRepository,
            IEtlDataRepository<Site> etlSiteRepository,
            IEtlDataRepository<TbStatus> etlTbStatusRepository,
            IEtlDataRepository<Ward> etlWardRepository)
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
            _etlPlhivEstimateRepository = etlPlhivEstimateRepository;
            _etlRegionRepository = etlRegionRepository;
            _etlSexDisaggregatesRepository = etlSexDisaggregatesRepository;
            _etlSiteRepository = etlSiteRepository;
            _etlTbStatusRepository = etlTbStatusRepository;
            _etlWardRepository = etlWardRepository;
        }

        [HttpGet("GetAgeDisaggregates")]
        [AllowAnonymous]
        public IActionResult GetAgeDisaggregates()
        {
            var ageDisaggregates = _etlAgeDisaggregateRepository.GetAll().ToList();
            return Ok(ageDisaggregates);
        }
        
        [HttpGet("GetCouncils")]
        [AllowAnonymous]
        public IActionResult GetCouncils()
        {
            var councils = _etlCouncilsRepository.GetAll().ToList();
            return Ok(councils);
        }
        
        [HttpGet("GetCxStatus")]
        [AllowAnonymous]
        public IActionResult GetCxStatus()
        {
            var cxStatus = _etlCxStatusRepository.GetAll().ToList();
            return Ok(cxStatus);
        }
        
        [HttpGet("GetDataSource")]
        [AllowAnonymous]
        public IActionResult GetDataSource()
        {
            var dataSources = _etlDataSourceRepository.GetAll().ToList();
            return Ok(dataSources);
        }
        
        [HttpGet("GetHivStatus")]
        [AllowAnonymous]
        public IActionResult GetHivStatus()
        {
            var hivStatus = _etlHivStatusRepository.GetAll().ToList();
            return Ok(hivStatus);
        }
        
        [HttpGet("GetHivTreatmentStatus")]
        [AllowAnonymous]
        public IActionResult GetHivTreatmentStatus()
        {
            var hivTreatmentStatus = _etlHivTreatmentStatusRepository.GetAll().ToList();
            return Ok(hivTreatmentStatus);
        }
        
        [HttpGet("GetMeasures")]
        [AllowAnonymous]
        public IActionResult GetMeasures()
        {
            var measures = _etlMeasureRepository.GetAll().ToList();
            return Ok(measures);
        }
        
        [HttpGet("GetMechanisms")]
        [AllowAnonymous]
        public IActionResult GetMechanisms()
        {
            var mechanisms = _etlMechanismRepository.GetAll().ToList();
            return Ok(mechanisms);
        }
        
        [HttpGet("GetModalities")]
        [AllowAnonymous]
        public IActionResult GetModalities()
        {
            var modalities = _etlModalityRepository.GetAll().ToList();
            return Ok(modalities);
        }
        
        [HttpGet("GetPeriods")]
        [AllowAnonymous]
        public IActionResult GetPeriods()
        {
            var periods = _etlPeriodRepository.GetAll().ToList();
            return Ok(periods);
        }
        
        [HttpGet("GetPlhivEstimates")]
        [AllowAnonymous]
        public IActionResult GetPlhivEstimates()
        {
            var plhivEstimates = _etlPlhivEstimateRepository.GetAll().ToList();
            return Ok(plhivEstimates);
        }
        
        [HttpGet("GetRegions")]
        [AllowAnonymous]
        public IActionResult GetRegions()
        {
            var regions = _etlRegionRepository.GetAll().ToList();
            return Ok(regions);
        }
        
        [HttpGet("GetSexDisaggregates")]
        [AllowAnonymous]
        public IActionResult GetSexDisaggregates()
        {
            var sexDisaggregates = _etlSexDisaggregatesRepository.GetAll().ToList();
            return Ok(sexDisaggregates);
        }
        
        [HttpGet("GetSites")]
        [AllowAnonymous]
        public IActionResult GetSites()
        {
            var sites = _etlSiteRepository.GetAll().ToList();
            return Ok(sites);
        }
        
        [HttpGet("GetTbStatus")]
        [AllowAnonymous]
        public IActionResult GetTbStatus()
        {
            var tbStatus = _etlTbStatusRepository.GetAll().ToList();
            return Ok(tbStatus);
        }
        
        [HttpGet("GetWards")]
        [AllowAnonymous]
        public IActionResult GetWards()
        {
            var wards = _etlWardRepository.GetAll().ToList();
            return Ok(wards);
        }
    }
}
