using System;
using System.Collections.Generic;
using System.Linq;
using GHPRS.Core.Entities;
using GHPRS.Core.Interfaces;

namespace GHPRS.Persistence.Repositories;

public class CommunityDataRepository : Repository<CommunityData>, ICommunityDataRepository
{
    private readonly GhprsContext _context;
    
    public CommunityDataRepository(GhprsContext context) : base(context)
    {
        _context = context;
    }

    public IEnumerable<CommunityData> Insert(IEnumerable<CommunityData> entities)
    {
        if (!entities.Any()) throw new ArgumentException(nameof(entities));
        _context.AddRange(entities);
        _context.SaveChanges();
        return entities;
    }
}