using System;
using System.Collections.Generic;
using System.Linq;
using GHPRS.Core.Entities;
using GHPRS.Core.Interfaces;

namespace GHPRS.Persistence.Repositories;

public class FacilityDataRepository : Repository<FacilityData>, IFacilityDataRepository
{
    private readonly GhprsContext _context;
    
    public FacilityDataRepository(GhprsContext context) : base(context)
    {
        _context = context;
    }

    public IEnumerable<FacilityData> Insert(IEnumerable<FacilityData> entities)
    {
        if (!entities.Any()) throw new ArgumentException(nameof(entities));
        _context.AddRange(entities);
        _context.SaveChanges();
        return entities;
    }
}