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
                new Lookup { Id = 1, Name = "Male", LookupType = LookupType.Gender, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new Lookup { Id = 2, Name = "Female", LookupType = LookupType.Gender, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new Lookup { Id = 3, Name = "Single", LookupType = LookupType.MaritalStatus, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new Lookup { Id = 4, Name = "Married", LookupType = LookupType.MaritalStatus, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new Lookup { Id = 5, Name = "Divorced", LookupType = LookupType.MaritalStatus, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new Lookup { Id = 6, Name = "Widow", LookupType = LookupType.MaritalStatus, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new Lookup { Id = 7, Name = "Widower", LookupType = LookupType.MaritalStatus, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now }
               );

            modelBuilder.Entity<Link>().HasData(
                new Link { Id = 8, Name = "Document Manager", Url = "/documents", LinkType = LinkType.External, Key = "", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new Link { Id = 9, Name = "DATIM", Url = "https://www.datim.org/dhis", LinkType = LinkType.External, Key = "", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new Link { Id = 10, Name = "Panaroma Dashboard", Url = "https://pepfar-panorama.org/", LinkType = LinkType.External, Key = "", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new Link { Id = 11, Name = "OHA Dashboard", Url = "https://sites.google.com/a/usaid.gov/gh-oha/home/reports-resources/quarterly-reporting-guidance-and-resources", LinkType = LinkType.External, Key = "", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new Link { Id = 12, Name = "Partner Performance Report", Url = "https://www.pepfar.net/OGAC-HQ/icpi/Products/Forms/AllItems.aspx", LinkType = LinkType.External, Key = "", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new Link { Id = 13, Name = "Monthly Portal", Url = "http://hmis.reachproject.or.tz/MonthlyReporting/", LinkType = LinkType.External, Key = "", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new Link { Id = 14, Name = "IP Reporting System", Url = "https://usaidtanzaniaiprs.com/index.cfm", LinkType = LinkType.External, Key = "", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new Link { Id = 15, Name = "STAT Compiler", Url = "https://statcompiler.com/en/", LinkType = LinkType.External, Key = "", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new Link { Id = 16, Name = "UNICEF (MICS)", Url = "https://data.unicef.org/", LinkType = LinkType.External, Key = "", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new Link { Id = 17, Name = "Global Health Data", Url = "http://apps.who.int/gho/data/node.home", LinkType = LinkType.External, Key = "", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new Link { Id = 18, Name = "World Bank", Url = "https://data.worldbank.org/", LinkType = LinkType.External, Key = "", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new Link { Id = 19, Name = "World Bank Service Delivery Indicators", Url = "http://datatopics.worldbank.org/sdi/", LinkType = LinkType.External, Key = "", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new Link { Id = 20, Name = "WHO Global Health Observatory", Url = "/Observatory", LinkType = LinkType.External, Key = "", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now }
               );
        }
    }
}