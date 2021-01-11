using GHPRS.Core.Entities;
using System.Collections.Generic;
using System.Linq;
using GHPRS.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using GHPRS.Core.Models;

namespace GHPRS.Persistence.Repositories
{
    public class TemplateRepository : Repository<Template>, ITemplateRepository
    {
        private readonly DbSet<Template> _entities;
        public TemplateRepository(GhprsContext context) : base(context)
        {
            _entities = context.Set<Template>();
        }

        public IEnumerable<object> GetList()
        {
            var result = _entities.Select(s => new { s.Id, s.Name, s.Description, s.ContentType }).ToList();
            return result;
        }
    }
}
