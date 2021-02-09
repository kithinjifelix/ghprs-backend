using Microsoft.EntityFrameworkCore;

namespace GHPRS.Persistence
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
    }
}