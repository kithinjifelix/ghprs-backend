using GHPRS.Core.Entities;
using GHPRS.Persistence.Seed;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

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
        public DbSet<WorkSheet> WorkSheets { get; set; }
        public DbSet<Column> Columns { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<MerData> MerDatas { get; set; }
        public DbSet<FileUploads> FileUploads { get; set; }
        public DbSet<FacilityData> FacilityDatas { get; set; }
        public DbSet<CommunityData> CommunityDatas { get; set; }
        public DbSet<TBData> TbDatas { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Person>().Property(b => b.Id).HasIdentityOptions(startValue: 120);
            modelBuilder.Entity<User>()
                .HasMany(c => c.Uploads)
                .WithOne(e => e.User);

            modelBuilder.Entity<WorkSheet>()
                .HasMany(c => c.Columns)
                .WithOne(e => e.WorkSheet);

            modelBuilder.Entity<WorkSheet>()
                .HasOne(c => c.Template);

            modelBuilder.Entity<Organization>()
                .HasMany(c => c.Users)
                .WithOne(e => e.Organization);

            modelBuilder.Seed();
        }
    }
}