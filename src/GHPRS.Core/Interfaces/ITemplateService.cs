using GHPRS.Core.Entities;
using GHPRS.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GHPRS.Core.Interfaces
{
    public interface ITemplateService
    {
        Task<List<WorkSheet>> Initialize(TemplateModel templateModel);
        List<WorkSheet> CreateWorkSheetDefinitions(Template template);
    }
}
