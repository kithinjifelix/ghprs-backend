using GHPRS.Core.Entities;
using GHPRS.Core.Interfaces;
using GHPRS.Core.Models;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Threading.Tasks;

namespace GHPRS.Core.Services
{
    public class UploadService : IUploadService
    {
        private readonly IUploadRepository _uploadRepository;
        private readonly ITemplateRepository _templateRepository;
        private readonly ILogger<UploadService> _logger;
        public UploadService(IUploadRepository uploadRepository, ITemplateRepository templateRepository, ILogger<UploadService> logger)
        {
            _uploadRepository = uploadRepository;
            _templateRepository = templateRepository;
            _logger = logger;
        }

        public void InsertUploadData(Upload upload)
        {
            
        }

        public async Task<Upload> Upload(UploadModel upload, User user)
        {
            // fileName to save
            var template = _templateRepository.GetById(upload.TemplateId);

            var initializedUpload = new Upload()
            {
                Name = template.Name,
                FileExtension = template.FileExtension,
                ContentType = upload.File.ContentType,
                Status = UploadStatus.pending,
                StartDate = upload.StartDate,
                EndDate = upload.EndDate,
                User = user,
                Template = template
            };

            using (var target = new MemoryStream())
            {
                await upload.File.CopyToAsync(target);
                initializedUpload.File = target.ToArray();
            }

            var result = _uploadRepository.Insert(initializedUpload);
            return result;
        }
    }
}
