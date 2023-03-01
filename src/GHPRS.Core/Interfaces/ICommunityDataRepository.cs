using System.Collections.Generic;
using GHPRS.Core.Entities;

namespace GHPRS.Core.Interfaces;

public interface ICommunityDataRepository : IRepository<CommunityData>
{
    IEnumerable<CommunityData> Insert(IEnumerable<CommunityData> entities);
}