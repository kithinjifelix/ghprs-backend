using GHPRS.Core.Entities;
using System.Collections.Generic;
using System.Linq;
using GHPRS.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using GHPRS.Core.Models;
using static GHPRS.Core.Entities.Template;

namespace GHPRS.Persistence.Repositories
{
    public class TemplateRepository : Repository<Template>, ITemplateRepository
    {
        private readonly DbSet<Template> _entities;
        public TemplateRepository(GhprsContext context) : base(context)
        {
            _entities = context.Set<Template>();
        }

        public object GetDetailsById(int id)
        {
            var result = _entities.Select(s => new { s.Id, s.Name, s.Description, s.ContentType, s.Version, s.Frequency, s.Status, s.CreatedAt }).FirstOrDefault(x => x.Id == id);
            return result;
        }

        public IEnumerable<object> GetList(string role)
        {
            if (role == "Administrator")
            {
                return _entities.Select(s => new { s.Id, s.Name, s.Description, s.ContentType, s.Version, s.Frequency, s.Status, s.CreatedAt }).ToList();
            }
            else
            {
                return _entities.Select(s => new { s.Id, s.Name, s.Description, s.ContentType, s.Version, s.Frequency, s.Status, s.CreatedAt }).Where(x => x.Status == TemplateStatus.Active).ToList();
            }
            
        }
    }
}
