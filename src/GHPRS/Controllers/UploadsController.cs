using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;
using Microsoft.Extensions.Configuration;
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
        private readonly CloudBlobContainer _container;
        private readonly IBlobStorageService _blobStorageService;

        public UploadsController(ILogger<UploadsController> logger, 
            IUploadService uploadService,
            IUploadRepository uploadRepository,
            IFileUploadRepository fileRepository,
            UserManager<User> userManager,
            IConfiguration configuration,
            IBlobStorageService blobStorageService)
        {
            _logger = logger;
            _uploadService = uploadService;
            _uploadRepository = uploadRepository;
            _fileRepository = fileRepository;
            _userManager = userManager;
            _blobStorageService = blobStorageService;
            
            //blob storage
            var connectionString = configuration.GetConnectionString("AzureStorage");
            var account = CloudStorageAccount.Parse(connectionString);
            var client = account.CreateCloudBlobClient();
            _container = client.GetContainerReference("merplhiv");
            _container.CreateIfNotExistsAsync().GetAwaiter().GetResult();
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
                        Review review = new Review() { Status = 1 };
                        _uploadService.Review(result, review);
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

        [HttpGet("MER_UPLOAD")]
        public async Task<IActionResult> Mer_Upload()
        {
            try
            {
                var files = _uploadService.GetDirectoryFiles();
                return Ok(files);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
        
        [HttpPost("ProcessBlob/{uploadType}")]
        public async Task<IActionResult> ProcessBlob([FromForm]BlobFile blobFile, int uploadType)
        {
            await _uploadService.GetTextFileDataAsync(blobFile.name, uploadType);
            return Ok();
        }

        [HttpGet("GetAllFileUploads/{status}")]
        public IActionResult GetAllFileUploads(string status)
        {
            try
            {
                return Ok(_fileRepository.GetAllFileUploads(status));
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
            return await _userManager.FindByNameAsync(User.Identity?.Name);
            // var userName = User.FindFirstValue(ClaimTypes.Name);
            // return await _userManager.FindByNameAsync(userName);
        }
    }

    public class BlobFile
    {
        public string name { get; set; }
    }
}