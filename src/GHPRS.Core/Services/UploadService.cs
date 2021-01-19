using GHPRS.Core.Entities;
using GHPRS.Core.Interfaces;
using GHPRS.Core.Models;
using System;
using System.IO;
using System.Threading.Tasks;

namespace GHPRS.Core.Services
{
    public class UploadService : IUploadService
    {
        private readonly IUploadRepository _uploadRepository;
        private readonly ITemplateRepository _templateRepository;
        public UploadService(IUploadRepository uploadRepository, ITemplateRepository templateRepository)
        {
            _uploadRepository = uploadRepository;
            _templateRepository = templateRepository;
        }

        public void InsertUploadData(Upload upload)
        {
            throw new NotImplementedException();
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
