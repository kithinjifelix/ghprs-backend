using GHPRS.Core.Entities;
using GHPRS.Persistence.Seed;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GHPRS.Persistence
{
    public class GhprsContext : IdentityDbContext<User>
    {
        public GhprsContext(DbContextOptions<GhprsContext> options) : base(options)
        {

        }

        public override int SaveChanges()
        {
            AddTimestamps();
            return base.SaveChanges();
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            AddTimestamps();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        private void AddTimestamps()
        {
            var entities = ChangeTracker.Entries()
                .Where(x => (x.Entity is Entity ) && (x.State == EntityState.Added || x.State == EntityState.Modified));

            foreach (var entity in entities)
            {
                var now = DateTime.UtcNow; // current datetime

                if (entity.State == EntityState.Added)
                {
                    ((Entity)entity.Entity).CreatedAt = now;
                }
                ((Entity)entity.Entity).UpdatedAt = now;
            }
        }

        public DbSet<Lookup> Lookups { get; set; }

        public DbSet<Template> Templates { get; set; }

        public DbSet<Upload> Uploads { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasMany(c => c.Uploads)
                .WithOne(e => e.User);

            modelBuilder.Seed();
        }
    }
}