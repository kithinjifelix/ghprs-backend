using GHPRS.Core.Entities;
using GHPRS.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace GHPRS.Persistence.Repositories
{
    public class UploadRepository : Repository<Upload>, IUploadRepository
    {
        private readonly DbSet<Upload> _entities;
        public UploadRepository(GhprsContext context) : base(context)
        {
            _entities = context.Set<Upload>();
        }

        public object GetDetailsById(int id)
        {
            var result = _entities.Select(s => new { s.Id, s.Name, s.Comments, s.Status, s.ContentType }).FirstOrDefault(x => x.Id == id);
            return result;
        }

        public IEnumerable<object> GetList()
        {
            var result = _entities.Select(s => new { s.Id, s.Name, s.Comments , s.Status, s.ContentType }).ToList();
            return result;
        }
    }
}
