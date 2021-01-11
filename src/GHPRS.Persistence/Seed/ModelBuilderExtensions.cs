using System;
using System.Linq;
using GHPRS.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace GHPRS.Persistence.Seed
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Lookup>().HasData(
                new Lookup { Id = 1, Name = "Male", LookupType = LookupType.Gender },
                new Lookup { Id = 2, Name = "Female", LookupType = LookupType.Gender },
                new Lookup { Id = 3, Name = "Single", LookupType = LookupType.MaritalStatus },
                new Lookup { Id = 4, Name = "Married", LookupType = LookupType.MaritalStatus },
                new Lookup { Id = 5, Name = "Divorced", LookupType = LookupType.MaritalStatus },
                new Lookup { Id = 6, Name = "Widow", LookupType = LookupType.MaritalStatus },
                new Lookup { Id = 7, Name = "Widower", LookupType = LookupType.MaritalStatus }
               );
        }
    }
}