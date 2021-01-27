using GHPRS.Core.Entities;
using GHPRS.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace GHPRS.Persistence.Repositories
{
    public class WorkSheetRepository : Repository<WorkSheet>, IWorkSheetRepository
    {
        private readonly IQueryable<WorkSheet> _entities;
        public WorkSheetRepository(GhprsContext context) : base(context)
        {
            _entities = context.WorkSheets
                 .Include(i => i.Columns)
                 .Include(i => i.Template)
                 .AsNoTracking();
        }

        public WorkSheet GetFullWorkSheetById(int id)
        {
            return _entities.SingleOrDefault(s => s.Id == id);
        }

        public IEnumerable<WorkSheet> GetFullWorkSheetsByTemplateId(int templateId)
        {
            return _entities.Where(s => s.TemplateId == templateId);
        }
    }
}
