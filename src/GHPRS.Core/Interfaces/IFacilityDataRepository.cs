using System.Collections.Generic;
using GHPRS.Core.Entities;

namespace GHPRS.Core.Interfaces;

public interface IFacilityDataRepository : IRepository<FacilityData>
{
    IEnumerable<FacilityData> Insert(IEnumerable<FacilityData> entities);
}