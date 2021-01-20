using GHPRS.Core.Entities;
using System.Collections.Generic;

namespace GHPRS.Core.Interfaces
{
    public interface IWorkSheetRepository : IRepository<WorkSheet>
    {
        WorkSheet GetFullWorkSheetById(int id);
        IEnumerable<WorkSheet> GetFullWorkSheetsByTemplateId(int templateId);
    }
}
