using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using GHPRS.Core.Entities;
using GHPRS.Core.Interfaces;
using GHPRS.Core.Models;
using Hangfire;
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
    public class UploadsController : ControllerBase
    {
        private const long MaxFileSize = 10L * 1024L * 1024L * 1024L;
        private readonly ILogger<UploadsController> _logger;
        private readonly IUploadRepository _uploadRepository;
        private readonly IFileUploadRepository _fileRepository;
        private readonly IUploadService _uploadService;
        private readonly UserManager<User> _userManager;

        public UploadsController(ILogger<UploadsController> logger, 
            IUploadService uploadService,
            IUploadRepository uploadRepository,
            IFileUploadRepository fileRepository,
            UserManager<User> userManager)
        {
            _logger = logger;
            _uploadService = uploadService;
            _uploadRepository = uploadRepository;
            _fileRepository = fileRepository;
            _userManager = userManager;
        }

        [HttpGet]
        public IEnumerable<object> GetList()
        {
            return _uploadRepository.GetList();
        }

        [HttpGet("USER")]
        public async Task<IEnumerable<object>> GetListByUser()
        {
            var user = await GetUser();
            return _uploadRepository.GetListByUser(user);
        }

        [HttpGet("STATUS/{status}")]
        public IEnumerable<object> GetListByStatus(int status)
        {
            return _uploadRepository.GetListByStatus((UploadStatus) status);
        }

        [HttpGet("{id}")]
        public object GetById(int id)
        {
            return _uploadRepository.GetDetailsById(id);
        }

        [HttpGet("DOWNLOAD/{id}")]
        [AllowAnonymous]
        public FileResult Download(int id)
        {
            var fileDetails = _uploadRepository.GetById(id);
            return File(fileDetails.File, fileDetails.ContentType, fileDetails.Name + fileDetails.FileExtension);
        }

        [HttpGet("VIEW/{id}")]
        [AllowAnonymous]
        public IActionResult View(int id)
        {
            var result = _uploadService.ReadUploadData(id);
            return Ok(result);
        }

        [HttpPost("UPLOAD/{organizationId}")]
        public async Task<IActionResult> Upload(int organizationId, [FromForm] UploadModel template)
        {
            try
            {
                Upload result;
                if (template.File != null)
                {
                    if (template.File.Length > 0)
                    {
                        var user = await GetUser();
                        result = await _uploadService.Upload(template, user, organizationId);
                    }
                    else
                    {
                        return StatusCode(StatusCodes.Status500InternalServerError, "File contains no data");
                    }
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "No File selected");
                }

                return Ok(result);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpPost("MER_UPLOAD")]
        [RequestSizeLimit(MaxFileSize)]
        [RequestFormLimits(MultipartBodyLengthLimit = MaxFileSize)]
        public async Task<IActionResult> Mer_Upload([FromForm] MERUploadModel merUploadModel)
        {
            try
            {
                if (merUploadModel != null && merUploadModel.File != null)
                {
                    if (merUploadModel.File.Length > 0)
                    {
                        var user = await GetUser();
                        if (merUploadModel.UploadTypeId == 1)
                        {
                            await _uploadService.UploadMER(merUploadModel, user);
                        }
                        else if (merUploadModel.UploadTypeId == 2)
                        {
                            await _uploadService.UploadFacilityData(merUploadModel, user);
                        }
                        
                        return StatusCode(StatusCodes.Status200OK, "Successfully Uploaded");
                    } 
                    else
                    {
                        return StatusCode(StatusCodes.Status500InternalServerError, "File contains no data");
                    }
                }
                return StatusCode(StatusCodes.Status500InternalServerError, "No File selected");
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpGet("GetAllFileUploads")]
        public IActionResult GetAllFileUploads()
        {
            try
            {
                return Ok(_fileRepository.GetAllFileUploads());
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpPut("REVIEW/{id}")]
        public IActionResult Review(int id, [FromBody] Review review)
        {
            try
            {
                var upload = _uploadRepository.GetById(id);
                _uploadService.Review(upload, review);
                return Ok(upload);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        private async Task<User> GetUser()
        {
            var userName = User.FindFirstValue(ClaimTypes.Name);
            return await _userManager.FindByNameAsync(userName);
        }
    }
}