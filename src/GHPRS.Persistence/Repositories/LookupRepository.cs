using System.Collections.Generic;
using System.Linq;
using GHPRS.Core.Entities;
using GHPRS.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GHPRS.Persistence.Repositories
{
    public class LookupRepository : Repository<Lookup>, ILookupRepository
    {
        private readonly DbSet<Lookup> _entities;
        public LookupRepository(GhprsContext context) : base(context)
        {
            _entities = context.Set<Lookup>();
        }

        public IEnumerable<Lookup> GetByType(LookupType type)
        {
            return _entities.Where(s => s.LookupType == type).OrderBy(n => n.Name);
        }
    }
}
