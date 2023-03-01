using GHPRS.Core.Entities;
using GHPRS.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace GHPRS.Persistence.Repositories
{
    public class LinkRepository : Repository<Link>, ILinkRepository
    {
        private readonly DbSet<Link> _entities;
        public LinkRepository(GhprsContext context) : base(context)
        {
            _entities = context.Set<Link>();
        }

        public IEnumerable<Link> GetByType(LinkType type)
        {
            return _entities.Where(s => s.LinkType == type).OrderBy(n => n.Name);
        }

        public Link GetByNumber(int number)
        {
            return _entities.SingleOrDefault(s => s.Number == number);
        }
    }
}
