using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using GHPRS.Core.Entities;
using static GHPRS.Core.Entities.Organisation;
using System.Linq;
using GHPRS.Core.Interfaces;
using Microsoft.Extensions.Logging;

namespace GHPRS.Persistence.Repositories
{
    public class OrganisationRepository : Repository<Organisation>, IOrganisationRepository
    {
        private readonly DbSet<Organisation> _entities;
        public OrganisationRepository(GhprsContext context) : base(context)
        {
            _entities = context.Set<Organisation>();
        }

    }
}
