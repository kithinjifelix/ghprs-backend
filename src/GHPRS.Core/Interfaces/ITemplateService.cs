using System;
using GHPRS.Core.Entities;
using GHPRS.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GHPRS.Core.Interfaces
{
    public interface ITemplateService
    {
        Task<List<WorkSheetModel>> Initialize(TemplateModel templateModel);
        Task UpdateTemplate(int id, TemplateModelUpdated templateModelUpdated);
        List<WorkSheetModel> CreateWorkSheetDefinitions(Template template);
        Tuple<bool, decimal> ExistingTemplateAndLatestVersion(string name);
    }
}
