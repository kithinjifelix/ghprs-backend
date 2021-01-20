using GHPRS.Core.Entities;
using GHPRS.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GHPRS.Persistence.Repositories
{
    public class WorkSheetRepository : Repository<WorkSheet>, IWorkSheetRepository
    {
        private readonly DbSet<WorkSheet> _entities;
        public WorkSheetRepository(GhprsContext context) : base(context)
        {
            _entities = context.Set<WorkSheet>();
        }
    }
}
