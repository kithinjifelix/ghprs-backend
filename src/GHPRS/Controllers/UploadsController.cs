using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Claims;
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

namespace GHPRS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UploadsController : ControllerBase
    {
        private readonly ILogger<UploadsController> _logger;
        private readonly IUploadService _uploadService;
        private readonly IUploadRepository _uploadRepository;
        private readonly UserManager<User> _userManager;

        public UploadsController(ILogger<UploadsController> logger, IUploadService uploadService, IUploadRepository uploadRepository, UserManager<User> userManager)
        {
            _logger = logger;
            _uploadService = uploadService;
            _uploadRepository = uploadRepository;
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
            return _uploadRepository.GetListByStatus((UploadStatus)status);
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

        [HttpPost("UPLOAD")]
        public async Task<IActionResult> Upload([FromForm] UploadModel template)
        {
            try
            {
                var result = new Upload();
                if (template.File != null)
                {
                    if (template.File.Length > 0)
                    {
                        var user = await GetUser();
                        result = await _uploadService.Upload(template, user);
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
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpPut("REVIEW/{id}")]
        public IActionResult Review(int id, [FromBody] Review review)
        {
            try
            {
                var upload = _uploadRepository.GetById(id);

                upload.Status = (UploadStatus)review.Status;
                upload.Comments = review.Comments;

                _uploadRepository.Update(upload);

                //Extract data from aproved Tempalates
                if ((UploadStatus)review.Status == UploadStatus.Approved)
                {
                    BackgroundJob.Enqueue<IUploadService>(x => x.InsertUploadData(upload.Id));
                }

                return Ok(upload);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        private async Task<User> GetUser()
        {
            var userName = this.User.FindFirstValue(ClaimTypes.Name);
            return await _userManager.FindByNameAsync(userName);
        }
    }
}
