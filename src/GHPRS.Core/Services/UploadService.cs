﻿using GHPRS.Core.Entities;
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

        public async Task<Upload> Upload(UploadModel upload)
        {
            //Getting FileName
            var fileName = Path.GetFileName(upload.File.FileName);
            //Getting file Extension
            var fileExtension = Path.GetExtension(fileName);
            // fileName to save
            var template = _templateRepository.GetById(upload.TemplateId);
            var Name = $"{template.Name}-{upload.currentUser}-{DateTime.Today.Date}";
            var newFileName = String.Concat(Name, fileExtension);

            var initializedUpload = new Upload()
            {
                Name = newFileName,
                ContentType = upload.File.ContentType,
                Status = UploadStatus.pending
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
