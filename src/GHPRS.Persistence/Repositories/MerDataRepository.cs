using GHPRS.Core.Entities;
using GHPRS.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GHPRS.Persistence.Repositories
{
    public class MerDataRepository : Repository<MerData>, IMerDataRepository
    {
        private readonly GhprsContext _context;

        public MerDataRepository(GhprsContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<MerData> Insert(IEnumerable<MerData> entities)
        {
            if (!entities.Any()) throw new ArgumentException(nameof(entities));
            _context.AddRange(entities);
            _context.SaveChanges();
            return entities;
        }
    }
}
