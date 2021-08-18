using GHPRS.Core.Entities;
using System.Collections.Generic;

namespace GHPRS.Core.Interfaces
{
    public interface ILinkRepository : IRepository<Link>
    {
        IEnumerable<Link> GetByType(LinkType type);
        Link GetByNumber(int number);
    }
}
