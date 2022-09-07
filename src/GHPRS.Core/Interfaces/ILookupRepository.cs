using System.Collections.Generic;
using GHPRS.Core.Entities;

namespace GHPRS.Core.Interfaces
{
    public interface ILookupRepository : IRepository<Lookup>
    {
        IEnumerable<Lookup> GetByType(LookupType type);
    }
}
