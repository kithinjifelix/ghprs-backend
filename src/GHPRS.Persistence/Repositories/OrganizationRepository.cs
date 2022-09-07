using Microsoft.EntityFrameworkCore;
using GHPRS.Core.Entities;
using GHPRS.Core.Interfaces;

namespace GHPRS.Persistence.Repositories
{
    public class OrganizationRepository : Repository<Organization>, IOrganizationRepository
    {
        private readonly DbSet<Organization> _entities;
        public OrganizationRepository(GhprsContext context) : base(context)
        {
            _entities = context.Set<Organization>();
        }

    }
}
