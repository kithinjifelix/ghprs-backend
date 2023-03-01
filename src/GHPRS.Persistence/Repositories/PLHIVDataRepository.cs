using System;
using System.Collections.Generic;
using System.Linq;
using GHPRS.Core.Entities;
using GHPRS.Core.Interfaces;

namespace GHPRS.Persistence.Repositories;

public class PLHIVDataRepository : Repository<PLHIVData>, IPLHIVDataRepository
{
    private readonly GhprsContext _context;

    public PLHIVDataRepository(GhprsContext context) : base(context)
    {
        _context = context;
    }
    
    public IEnumerable<PLHIVData> Insert(IEnumerable<PLHIVData> entities)
    {
        if (!entities.Any()) throw new ArgumentException(nameof(entities));
        _context.AddRange(entities);
        _context.SaveChanges();
        return entities;
    }
}