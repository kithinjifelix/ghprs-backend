using System;
using System.Globalization;
using GHPRS.Core.Entities;
using Microsoft.EntityFrameworkCore;
using static GHPRS.Core.Entities.Organization;

namespace GHPRS.Persistence.Seed
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            string[] dateFormats = new[] { "yyyy/MM/dd", "MM/dd/yyyy", "MM/dd/yyyyHH:mm:ss" };
            CultureInfo provider = new CultureInfo("en-US");
            DateTime newDate = DateTime.ParseExact("01/20/2021", dateFormats, provider,
            DateTimeStyles.AdjustToUniversal);

            modelBuilder.Entity<Lookup>().HasData(
                new Lookup { Id = 1, Name = "Male", LookupType = LookupType.Gender, CreatedAt = newDate, UpdatedAt = newDate },
                new Lookup { Id = 2, Name = "Female", LookupType = LookupType.Gender, CreatedAt = newDate, UpdatedAt = newDate },
                new Lookup { Id = 3, Name = "Single", LookupType = LookupType.MaritalStatus, CreatedAt = newDate, UpdatedAt = newDate },
                new Lookup { Id = 4, Name = "Married", LookupType = LookupType.MaritalStatus, CreatedAt = newDate, UpdatedAt = newDate },
                new Lookup { Id = 5, Name = "Divorced", LookupType = LookupType.MaritalStatus, CreatedAt = newDate, UpdatedAt = newDate },
                new Lookup { Id = 6, Name = "Widow", LookupType = LookupType.MaritalStatus, CreatedAt = newDate, UpdatedAt = newDate },
                new Lookup { Id = 7, Name = "Widower", LookupType = LookupType.MaritalStatus, CreatedAt = newDate, UpdatedAt = newDate },
                new Lookup { Id = 8, Name = "TEXT", Value = "TEXT", LookupType = LookupType.DataType, CreatedAt = newDate, UpdatedAt = newDate },
                new Lookup { Id = 9, Name = "DATE", Value = "DATE", LookupType = LookupType.DataType, CreatedAt = newDate, UpdatedAt = newDate },
                new Lookup { Id = 10, Name = "NUMBER", Value = "NUMERIC", LookupType = LookupType.DataType, CreatedAt = newDate, UpdatedAt = newDate }
               );

            modelBuilder.Entity<Link>().HasData(
                new Link { Id = 8, Name = "Document Manager", Url = "/documents", LinkType = LinkType.External, Key = "", CreatedAt = newDate, UpdatedAt = newDate },
                new Link { Id = 9, Name = "DATIM", Url = "https://www.datim.org/dhis", LinkType = LinkType.External, Key = "", CreatedAt = newDate, UpdatedAt = newDate },
                new Link { Id = 10, Name = "Panaroma Dashboard", Url = "https://pepfar-panorama.org/", LinkType = LinkType.External, Key = "", CreatedAt = newDate, UpdatedAt = newDate },
                new Link { Id = 11, Name = "OHA Dashboard", Url = "https://sites.google.com/a/usaid.gov/gh-oha/home/reports-resources/quarterly-reporting-guidance-and-resources", LinkType = LinkType.External, Key = "", CreatedAt = newDate, UpdatedAt = newDate },
                new Link { Id = 12, Name = "Partner Performance Report", Url = "https://www.pepfar.net/OGAC-HQ/icpi/Products/Forms/AllItems.aspx", LinkType = LinkType.External, Key = "", CreatedAt = newDate, UpdatedAt = newDate },
                new Link { Id = 13, Name = "Monthly Portal", Url = "http://hmis.reachproject.or.tz/MonthlyReporting/", LinkType = LinkType.External, Key = "", CreatedAt = newDate, UpdatedAt = newDate },
                new Link { Id = 14, Name = "IP Reporting System", Url = "https://usaidtanzaniaiprs.com/index.cfm", LinkType = LinkType.External, Key = "", CreatedAt = newDate, UpdatedAt = newDate },
                new Link { Id = 15, Name = "STAT Compiler", Url = "https://statcompiler.com/en/", LinkType = LinkType.External, Key = "", CreatedAt = newDate, UpdatedAt = newDate },
                new Link { Id = 16, Name = "UNICEF (MICS)", Url = "https://data.unicef.org/", LinkType = LinkType.External, Key = "", CreatedAt = newDate, UpdatedAt = newDate },
                new Link { Id = 17, Name = "Global Health Data", Url = "http://apps.who.int/gho/data/node.home", LinkType = LinkType.External, Key = "", CreatedAt = newDate, UpdatedAt = newDate },
                new Link { Id = 18, Name = "World Bank", Url = "https://data.worldbank.org/", LinkType = LinkType.External, Key = "", CreatedAt = newDate, UpdatedAt = newDate },
                new Link { Id = 19, Name = "World Bank Service Delivery Indicators", Url = "http://datatopics.worldbank.org/sdi/", LinkType = LinkType.External, Key = "", CreatedAt = newDate, UpdatedAt = newDate },
                new Link { Id = 20, Name = "WHO Global Health Observatory", Url = "/Observatory", LinkType = LinkType.External, Key = "", CreatedAt = newDate, UpdatedAt = newDate },
                new Link { Id = 21, Name = "Pediatric ARV Optimization", Url = "http://52.251.58.64:3000", LinkType = LinkType.Dashboard, Number = 5,Key = "80334b54cc4c696b67e0d20c2bc461b9d867781b4234af3819030209cbde6751", CreatedAt = newDate, UpdatedAt = newDate },
                new Link { Id = 22, Name = "TX New", Url = "http://52.251.58.64:3000", LinkType = LinkType.Dashboard, Number = 9, Key = "80334b54cc4c696b67e0d20c2bc461b9d867781b4234af3819030209cbde6751", CreatedAt = newDate, UpdatedAt = newDate },
                new Link { Id = 23, Name = "HTS Testing Monthly Reporting", Url = "http://52.251.58.64:3000", LinkType = LinkType.Dashboard, Number = 3, Key = "80334b54cc4c696b67e0d20c2bc461b9d867781b4234af3819030209cbde6751", CreatedAt = newDate, UpdatedAt = newDate },
                new Link { Id = 24, Name = "TX Curr and TX MMD", Url = "http://52.251.58.64:3000", LinkType = LinkType.Dashboard, Number = 4, Key = "80334b54cc4c696b67e0d20c2bc461b9d867781b4234af3819030209cbde6751", CreatedAt = newDate, UpdatedAt = newDate },
                new Link { Id = 25, Name = "TX ML", Url = "http://52.251.58.64:3000", LinkType = LinkType.Dashboard, Number = 8, Key = "80334b54cc4c696b67e0d20c2bc461b9d867781b4234af3819030209cbde6751", CreatedAt = newDate, UpdatedAt = newDate }
               );

            modelBuilder.Entity<Organization>().HasData(
                new Organization { Id = 1, Name = "USAID", ShortName = "USAID", Status = OrganizationStatus.Active, CreatedAt = newDate, UpdatedAt = newDate }
               );
        }
    }
}