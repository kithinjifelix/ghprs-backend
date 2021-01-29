
using GHPRS.Core.Entities;
using GHPRS.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GHPRS.Persistence.Repositories
{
    public class ColumnRepository : Repository<Column>, IColumnRepository
    {
        private readonly DbSet<Column> _entities;
        public ColumnRepository(GhprsContext context) : base(context)
        {
            _entities = context.Set<Column>();
        }
    }
}
