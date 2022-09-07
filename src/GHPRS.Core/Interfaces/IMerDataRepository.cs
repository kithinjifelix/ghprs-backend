using GHPRS.Core.Entities;
using System.Collections.Generic;

namespace GHPRS.Core.Interfaces
{
    public interface IMerDataRepository : IRepository<MerData>
    {
        IEnumerable<MerData> Insert(IEnumerable<MerData> entities);
    }
}
