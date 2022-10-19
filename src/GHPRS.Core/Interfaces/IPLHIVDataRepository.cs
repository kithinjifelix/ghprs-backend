using System.Collections.Generic;
using GHPRS.Core.Entities;

namespace GHPRS.Core.Interfaces;

public interface IPLHIVDataRepository : IRepository<PLHIVData>
{
    IEnumerable<PLHIVData> Insert(IEnumerable<PLHIVData> entities);
}