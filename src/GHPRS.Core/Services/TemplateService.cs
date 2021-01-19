using System;
using System.IO;
using System.Threading.Tasks;
using GHPRS.Core.Entities;
using GHPRS.Core.Interfaces;
using GHPRS.Core.Models;
using static GHPRS.Core.Entities.Template;
using Hangfire;

namespace GHPRS.Core.Services
{
    public class TemplateService : ITemplateService
    {
        private readonly ITemplateRepository _templateRepository;
        public TemplateService(ITemplateRepository templateRepository)
        {
            _templateRepository = templateRepository;
        }

        public void CreateTemplateTable(Template template)
        {
            throw new NotImplementedException();
        }

        public async Task<Template> Initialize(TemplateModel templateModel)
        {
            //Getting FileName
            var fileName = Path.GetFileName(templateModel.File.FileName);
            //Getting file Extension
            var fileExtension = Path.GetExtension(fileName);

            var initializedTemplate = new Template()
            {
                Name = templateModel.Name,
                FileExtension = fileExtension,
                Description = templateModel.Description,
                Frequency = (ReportingFrequency)templateModel.Frequency,
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

            // extract template schema in the background
            //BackgroundJob.Enqueue(() => CreateTemplateTable(result));

            return result;
        }


    }
}
