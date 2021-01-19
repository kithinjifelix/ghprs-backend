using GHPRS.Core.Entities;
using GHPRS.Core.Models;
using System.Threading.Tasks;

namespace GHPRS.Core.Interfaces
{
    public interface ITemplateService
    {
        Task<Template> Initialize(TemplateModel templateModel);
        void CreateTemplateTable(Template template);
    }
}
