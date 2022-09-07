using Microsoft.EntityFrameworkCore;

namespace GHPRS.Persistence
{
    public class DataContext : BaseContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
    }
}