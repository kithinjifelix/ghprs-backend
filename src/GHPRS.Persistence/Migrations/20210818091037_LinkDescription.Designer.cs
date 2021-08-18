﻿// <auto-generated />
using System;
using GHPRS.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace GHPRS.Persistence.Migrations
{
    [DbContext(typeof(GhprsContext))]
    [Migration("20210818091037_LinkDescription")]
    partial class LinkDescription
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityByDefaultColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("GHPRS.Core.Entities.Column", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Type")
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("WorkSheetId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("WorkSheetId");

                    b.ToTable("Columns");
                });

            modelBuilder.Entity("GHPRS.Core.Entities.Link", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Key")
                        .HasColumnType("text");

                    b.Property<int>("LinkType")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("Number")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Url")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Link");

                    b.HasData(
                        new
                        {
                            Id = 8,
                            CreatedAt = new DateTime(2021, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "",
                            Key = "",
                            LinkType = 3,
                            Name = "Document Manager",
                            Number = 0,
                            UpdatedAt = new DateTime(2021, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Url = "/documents"
                        },
                        new
                        {
                            Id = 9,
                            CreatedAt = new DateTime(2021, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "",
                            Key = "",
                            LinkType = 3,
                            Name = "DATIM",
                            Number = 0,
                            UpdatedAt = new DateTime(2021, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Url = "https://www.datim.org/dhis"
                        },
                        new
                        {
                            Id = 10,
                            CreatedAt = new DateTime(2021, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "",
                            Key = "",
                            LinkType = 3,
                            Name = "Panaroma Dashboard",
                            Number = 0,
                            UpdatedAt = new DateTime(2021, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Url = "https://pepfar-panorama.org/"
                        },
                        new
                        {
                            Id = 11,
                            CreatedAt = new DateTime(2021, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "",
                            Key = "",
                            LinkType = 3,
                            Name = "OHA Dashboard",
                            Number = 0,
                            UpdatedAt = new DateTime(2021, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Url = "https://sites.google.com/a/usaid.gov/gh-oha/home/reports-resources/quarterly-reporting-guidance-and-resources"
                        },
                        new
                        {
                            Id = 12,
                            CreatedAt = new DateTime(2021, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "",
                            Key = "",
                            LinkType = 3,
                            Name = "Partner Performance Report",
                            Number = 0,
                            UpdatedAt = new DateTime(2021, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Url = "https://www.pepfar.net/OGAC-HQ/icpi/Products/Forms/AllItems.aspx"
                        },
                        new
                        {
                            Id = 13,
                            CreatedAt = new DateTime(2021, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "",
                            Key = "",
                            LinkType = 3,
                            Name = "Monthly Portal",
                            Number = 0,
                            UpdatedAt = new DateTime(2021, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Url = "http://hmis.reachproject.or.tz/MonthlyReporting/"
                        },
                        new
                        {
                            Id = 14,
                            CreatedAt = new DateTime(2021, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "",
                            Key = "",
                            LinkType = 3,
                            Name = "IP Reporting System",
                            Number = 0,
                            UpdatedAt = new DateTime(2021, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Url = "https://usaidtanzaniaiprs.com/index.cfm"
                        },
                        new
                        {
                            Id = 15,
                            CreatedAt = new DateTime(2021, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "",
                            Key = "",
                            LinkType = 3,
                            Name = "STAT Compiler",
                            Number = 0,
                            UpdatedAt = new DateTime(2021, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Url = "https://statcompiler.com/en/"
                        },
                        new
                        {
                            Id = 16,
                            CreatedAt = new DateTime(2021, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "",
                            Key = "",
                            LinkType = 3,
                            Name = "UNICEF (MICS)",
                            Number = 0,
                            UpdatedAt = new DateTime(2021, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Url = "https://data.unicef.org/"
                        },
                        new
                        {
                            Id = 17,
                            CreatedAt = new DateTime(2021, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "",
                            Key = "",
                            LinkType = 3,
                            Name = "Global Health Data",
                            Number = 0,
                            UpdatedAt = new DateTime(2021, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Url = "http://apps.who.int/gho/data/node.home"
                        },
                        new
                        {
                            Id = 18,
                            CreatedAt = new DateTime(2021, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "",
                            Key = "",
                            LinkType = 3,
                            Name = "World Bank",
                            Number = 0,
                            UpdatedAt = new DateTime(2021, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Url = "https://data.worldbank.org/"
                        },
                        new
                        {
                            Id = 19,
                            CreatedAt = new DateTime(2021, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "",
                            Key = "",
                            LinkType = 3,
                            Name = "World Bank Service Delivery Indicators",
                            Number = 0,
                            UpdatedAt = new DateTime(2021, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Url = "http://datatopics.worldbank.org/sdi/"
                        },
                        new
                        {
                            Id = 20,
                            CreatedAt = new DateTime(2021, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "",
                            Key = "",
                            LinkType = 3,
                            Name = "WHO Global Health Observatory",
                            Number = 0,
                            UpdatedAt = new DateTime(2021, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Url = "/Observatory"
                        },
                        new
                        {
                            Id = 21,
                            CreatedAt = new DateTime(2021, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "",
                            Key = "80334b54cc4c696b67e0d20c2bc461b9d867781b4234af3819030209cbde6751",
                            LinkType = 0,
                            Name = "Pediatric ARV Optimization",
                            Number = 5,
                            UpdatedAt = new DateTime(2021, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Url = "http://52.251.58.64:3000"
                        },
                        new
                        {
                            Id = 22,
                            CreatedAt = new DateTime(2021, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "",
                            Key = "80334b54cc4c696b67e0d20c2bc461b9d867781b4234af3819030209cbde6751",
                            LinkType = 0,
                            Name = "D5 USAID Monthly Reporting",
                            Number = 12,
                            UpdatedAt = new DateTime(2021, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Url = "http://52.251.58.64:3000"
                        },
                        new
                        {
                            Id = 23,
                            CreatedAt = new DateTime(2021, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "",
                            Key = "80334b54cc4c696b67e0d20c2bc461b9d867781b4234af3819030209cbde6751",
                            LinkType = 0,
                            Name = "D5 USAID Monthly Reporting - Site Level",
                            Number = 13,
                            UpdatedAt = new DateTime(2021, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Url = "http://52.251.58.64:3000"
                        },
                        new
                        {
                            Id = 24,
                            CreatedAt = new DateTime(2021, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "",
                            Key = "80334b54cc4c696b67e0d20c2bc461b9d867781b4234af3819030209cbde6751",
                            LinkType = 0,
                            Name = "MCH FP Performance Dashboard",
                            Number = 14,
                            UpdatedAt = new DateTime(2021, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Url = "http://52.251.58.64:3000"
                        },
                        new
                        {
                            Id = 25,
                            CreatedAt = new DateTime(2021, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "",
                            Key = "80334b54cc4c696b67e0d20c2bc461b9d867781b4234af3819030209cbde6751",
                            LinkType = 0,
                            Name = "Boresha Afya Facilities",
                            Number = 36,
                            UpdatedAt = new DateTime(2021, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Url = "http://52.251.58.64:3000"
                        });
                });

            modelBuilder.Entity("GHPRS.Core.Entities.Lookup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("LookupType")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Lookups");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2021, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LookupType = 0,
                            Name = "Male",
                            UpdatedAt = new DateTime(2021, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2021, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LookupType = 0,
                            Name = "Female",
                            UpdatedAt = new DateTime(2021, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(2021, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LookupType = 1,
                            Name = "Single",
                            UpdatedAt = new DateTime(2021, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 4,
                            CreatedAt = new DateTime(2021, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LookupType = 1,
                            Name = "Married",
                            UpdatedAt = new DateTime(2021, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 5,
                            CreatedAt = new DateTime(2021, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LookupType = 1,
                            Name = "Divorced",
                            UpdatedAt = new DateTime(2021, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 6,
                            CreatedAt = new DateTime(2021, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LookupType = 1,
                            Name = "Widow",
                            UpdatedAt = new DateTime(2021, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 7,
                            CreatedAt = new DateTime(2021, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LookupType = 1,
                            Name = "Widower",
                            UpdatedAt = new DateTime(2021, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 8,
                            CreatedAt = new DateTime(2021, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LookupType = 2,
                            Name = "TEXT",
                            UpdatedAt = new DateTime(2021, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Value = "TEXT"
                        },
                        new
                        {
                            Id = 9,
                            CreatedAt = new DateTime(2021, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LookupType = 2,
                            Name = "DATE",
                            UpdatedAt = new DateTime(2021, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Value = "DATE"
                        },
                        new
                        {
                            Id = 10,
                            CreatedAt = new DateTime(2021, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LookupType = 2,
                            Name = "NUMBER",
                            UpdatedAt = new DateTime(2021, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Value = "NUMERIC"
                        });
                });

            modelBuilder.Entity("GHPRS.Core.Entities.Organization", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("ShortName")
                        .HasColumnType("text");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("Organizations");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2021, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "USAID",
                            Name = "USAID",
                            ShortName = "USAID",
                            Status = 0,
                            UpdatedAt = new DateTime(2021, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("GHPRS.Core.Entities.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("GenderId")
                        .HasColumnType("integer");

                    b.Property<int>("MaritalStatusId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("Person");
                });

            modelBuilder.Entity("GHPRS.Core.Entities.Template", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("ContentType")
                        .HasColumnType("text");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<byte[]>("File")
                        .HasColumnType("bytea");

                    b.Property<string>("FileExtension")
                        .HasColumnType("text");

                    b.Property<int>("Frequency")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<decimal>("Version")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.ToTable("Templates");
                });

            modelBuilder.Entity("GHPRS.Core.Entities.Upload", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("Comments")
                        .HasColumnType("text");

                    b.Property<string>("ContentType")
                        .HasColumnType("text");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<byte[]>("File")
                        .HasColumnType("bytea");

                    b.Property<string>("FileExtension")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<int?>("TemplateId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("UploadBatch")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("TemplateId");

                    b.HasIndex("UserId");

                    b.ToTable("Uploads");
                });

            modelBuilder.Entity("GHPRS.Core.Entities.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<int>("OrganizationId")
                        .HasColumnType("integer");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<int>("PersonId")
                        .HasColumnType("integer");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.HasIndex("OrganizationId");

                    b.HasIndex("PersonId");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("GHPRS.Core.Entities.WorkSheet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Range")
                        .HasColumnType("text");

                    b.Property<string>("TableName")
                        .HasColumnType("text");

                    b.Property<int>("TemplateId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("TemplateId");

                    b.ToTable("WorkSheets");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .HasColumnType("text");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("GHPRS.Core.Entities.Column", b =>
                {
                    b.HasOne("GHPRS.Core.Entities.WorkSheet", "WorkSheet")
                        .WithMany("Columns")
                        .HasForeignKey("WorkSheetId");

                    b.Navigation("WorkSheet");
                });

            modelBuilder.Entity("GHPRS.Core.Entities.Upload", b =>
                {
                    b.HasOne("GHPRS.Core.Entities.Template", "Template")
                        .WithMany()
                        .HasForeignKey("TemplateId");

                    b.HasOne("GHPRS.Core.Entities.User", "User")
                        .WithMany("Uploads")
                        .HasForeignKey("UserId");

                    b.Navigation("Template");

                    b.Navigation("User");
                });

            modelBuilder.Entity("GHPRS.Core.Entities.User", b =>
                {
                    b.HasOne("GHPRS.Core.Entities.Organization", "Organization")
                        .WithMany("Users")
                        .HasForeignKey("OrganizationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GHPRS.Core.Entities.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Organization");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("GHPRS.Core.Entities.WorkSheet", b =>
                {
                    b.HasOne("GHPRS.Core.Entities.Template", "Template")
                        .WithMany()
                        .HasForeignKey("TemplateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Template");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("GHPRS.Core.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("GHPRS.Core.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GHPRS.Core.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("GHPRS.Core.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GHPRS.Core.Entities.Organization", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("GHPRS.Core.Entities.User", b =>
                {
                    b.Navigation("Uploads");
                });

            modelBuilder.Entity("GHPRS.Core.Entities.WorkSheet", b =>
                {
                    b.Navigation("Columns");
                });
#pragma warning restore 612, 618
        }
    }
}
