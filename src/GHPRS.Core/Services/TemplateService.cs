using System;
using System.IO;
using System.Threading.Tasks;
using GHPRS.Core.Entities;
using GHPRS.Core.Interfaces;
using GHPRS.Core.Models;
using static GHPRS.Core.Entities.Template;

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
            var initializedTemplate = new Template()
            {
                Name = templateModel.Name,
                Description = templateModel.Description,
                Version = templateModel.Version,
                ContentType = templateModel.File.ContentType,
                Status = TemplateStatus.Active
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
