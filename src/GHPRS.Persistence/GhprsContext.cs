using GHPRS.Core.Entities;
using GHPRS.Persistence.Seed;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GHPRS.Persistence
{
    public class GhprsContext : IdentityDbContext<User>
    {
        public GhprsContext(DbContextOptions<GhprsContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Seed();
        }
    }
}