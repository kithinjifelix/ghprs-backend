using System;
using System.IO;
using System.Threading.Tasks;
using GHPRS.Core.Entities;
using GHPRS.Core.Interfaces;
using GHPRS.Core.Models;

namespace GHPRS.Core.Services
{
    public class TemplateService : ITemplateService
    {
        private readonly ITemplateRepository _templateRepository;
        public TemplateService(ITemplateRepository templateRepository)
        {
            _templateRepository = templateRepository;
        }
        public async Task<Template> Initialize(TemplateModel templateModel)
        {
            //Getting FileName
            var fileName = Path.GetFileName(templateModel.File.FileName);
            //Getting file Extension
            var fileExtension = Path.GetExtension(fileName);
            // fileName to save
            var newFileName = String.Concat(templateModel.Name, fileExtension);

            var initializedTemplate = new Template()
            {
                Name = newFileName,
                Description = templateModel.Description,
                ContentType = templateModel.File.ContentType,
            };

            using (var target = new MemoryStream())
            {
                await templateModel.File.CopyToAsync(target);
                initializedTemplate.File = target.ToArray();
            }

            var result = _templateRepository.Insert(initializedTemplate);
            return result;
        }


    }
}
