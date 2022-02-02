using Microsoft.EntityFrameworkCore;

namespace GHPRS.Persistence
{
    public abstract class BaseContext : DbContext
    {
        protected BaseContext(DbContextOptions options) : base(options)
        {
            
        }
    }
}