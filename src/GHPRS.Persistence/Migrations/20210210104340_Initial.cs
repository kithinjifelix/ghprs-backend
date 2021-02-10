using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace GHPRS.Persistence.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Link",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Url = table.Column<string>(type: "text", nullable: true),
                    LinkType = table.Column<int>(type: "integer", nullable: false),
                    Number = table.Column<int>(type: "integer", nullable: false),
                    Key = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Link", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lookups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Value = table.Column<string>(type: "text", nullable: true),
                    LookupType = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lookups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Organizations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    ShortName = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    GenderId = table.Column<int>(type: "integer", nullable: false),
                    MaritalStatusId = table.Column<int>(type: "integer", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Templates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    FileExtension = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    File = table.Column<byte[]>(type: "bytea", nullable: true),
                    ContentType = table.Column<string>(type: "text", nullable: true),
                    Version = table.Column<decimal>(type: "numeric", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    Frequency = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Templates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    PersonId = table.Column<int>(type: "integer", nullable: false),
                    OrganizationId = table.Column<int>(type: "integer", nullable: false),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkSheets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Range = table.Column<string>(type: "text", nullable: true),
                    TableName = table.Column<string>(type: "text", nullable: true),
                    TemplateId = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkSheets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkSheets_Templates_TemplateId",
                        column: x => x.TemplateId,
                        principalTable: "Templates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Uploads",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    FileExtension = table.Column<string>(type: "text", nullable: true),
                    File = table.Column<byte[]>(type: "bytea", nullable: true),
                    ContentType = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Comments = table.Column<string>(type: "text", nullable: true),
                    UploadBatch = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: true),
                    TemplateId = table.Column<int>(type: "integer", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uploads", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Uploads_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Uploads_Templates_TemplateId",
                        column: x => x.TemplateId,
                        principalTable: "Templates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Columns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Type = table.Column<string>(type: "text", nullable: true),
                    WorkSheetId = table.Column<int>(type: "integer", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Columns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Columns_WorkSheets_WorkSheetId",
                        column: x => x.WorkSheetId,
                        principalTable: "WorkSheets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Link",
                columns: new[] { "Id", "CreatedAt", "Key", "LinkType", "Name", "Number", "UpdatedAt", "Url" },
                values: new object[,]
                {
                    { 8, new DateTime(2021, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 3, "Document Manager", 0, new DateTime(2021, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "/documents" },
                    { 25, new DateTime(2021, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "80334b54cc4c696b67e0d20c2bc461b9d867781b4234af3819030209cbde6751", 0, "Boresha Afya Facilities", 36, new DateTime(2021, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "http://52.251.58.64:3000" },
                    { 24, new DateTime(2021, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "80334b54cc4c696b67e0d20c2bc461b9d867781b4234af3819030209cbde6751", 0, "MCH FP Performance Dashboard", 14, new DateTime(2021, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "http://52.251.58.64:3000" },
                    { 23, new DateTime(2021, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "80334b54cc4c696b67e0d20c2bc461b9d867781b4234af3819030209cbde6751", 0, "D5 USAID Monthly Reporting - Site Level", 13, new DateTime(2021, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "http://52.251.58.64:3000" },
                    { 21, new DateTime(2021, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "80334b54cc4c696b67e0d20c2bc461b9d867781b4234af3819030209cbde6751", 0, "Pediatric ARV Optimization", 5, new DateTime(2021, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "http://52.251.58.64:3000" },
                    { 20, new DateTime(2021, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 3, "WHO Global Health Observatory", 0, new DateTime(2021, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "/Observatory" },
                    { 19, new DateTime(2021, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 3, "World Bank Service Delivery Indicators", 0, new DateTime(2021, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "http://datatopics.worldbank.org/sdi/" },
                    { 18, new DateTime(2021, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 3, "World Bank", 0, new DateTime(2021, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://data.worldbank.org/" },
                    { 17, new DateTime(2021, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 3, "Global Health Data", 0, new DateTime(2021, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "http://apps.who.int/gho/data/node.home" },
                    { 22, new DateTime(2021, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "80334b54cc4c696b67e0d20c2bc461b9d867781b4234af3819030209cbde6751", 0, "D5 USAID Monthly Reporting", 12, new DateTime(2021, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "http://52.251.58.64:3000" },
                    { 15, new DateTime(2021, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 3, "STAT Compiler", 0, new DateTime(2021, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://statcompiler.com/en/" },
                    { 14, new DateTime(2021, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 3, "IP Reporting System", 0, new DateTime(2021, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://usaidtanzaniaiprs.com/index.cfm" },
                    { 13, new DateTime(2021, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 3, "Monthly Portal", 0, new DateTime(2021, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "http://hmis.reachproject.or.tz/MonthlyReporting/" },
                    { 12, new DateTime(2021, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 3, "Partner Performance Report", 0, new DateTime(2021, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://www.pepfar.net/OGAC-HQ/icpi/Products/Forms/AllItems.aspx" },
                    { 11, new DateTime(2021, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 3, "OHA Dashboard", 0, new DateTime(2021, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://sites.google.com/a/usaid.gov/gh-oha/home/reports-resources/quarterly-reporting-guidance-and-resources" },
                    { 10, new DateTime(2021, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 3, "Panaroma Dashboard", 0, new DateTime(2021, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://pepfar-panorama.org/" },
                    { 9, new DateTime(2021, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 3, "DATIM", 0, new DateTime(2021, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://www.datim.org/dhis" },
                    { 16, new DateTime(2021, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 3, "UNICEF (MICS)", 0, new DateTime(2021, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://data.unicef.org/" }
                });

            migrationBuilder.InsertData(
                table: "Lookups",
                columns: new[] { "Id", "CreatedAt", "LookupType", "Name", "UpdatedAt", "Value" },
                values: new object[,]
                {
                    { 9, new DateTime(2021, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "DATE", new DateTime(2021, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "DATE" },
                    { 8, new DateTime(2021, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "TEXT", new DateTime(2021, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "TEXT" },
                    { 7, new DateTime(2021, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Widower", new DateTime(2021, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 6, new DateTime(2021, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Widow", new DateTime(2021, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2, new DateTime(2021, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Female", new DateTime(2021, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 4, new DateTime(2021, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Married", new DateTime(2021, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 3, new DateTime(2021, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Single", new DateTime(2021, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 1, new DateTime(2021, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Male", new DateTime(2021, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 10, new DateTime(2021, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "NUMBER", new DateTime(2021, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "NUMERIC" },
                    { 5, new DateTime(2021, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Divorced", new DateTime(2021, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null }
                });

            migrationBuilder.InsertData(
                table: "Organizations",
                columns: new[] { "Id", "CreatedAt", "Description", "Name", "ShortName", "Status", "UpdatedAt" },
                values: new object[] { 1, new DateTime(2021, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "USAID", "USAID", "USAID", 0, new DateTime(2021, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_OrganizationId",
                table: "AspNetUsers",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_PersonId",
                table: "AspNetUsers",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Columns_WorkSheetId",
                table: "Columns",
                column: "WorkSheetId");

            migrationBuilder.CreateIndex(
                name: "IX_Uploads_TemplateId",
                table: "Uploads",
                column: "TemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_Uploads_UserId",
                table: "Uploads",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkSheets_TemplateId",
                table: "WorkSheets",
                column: "TemplateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Columns");

            migrationBuilder.DropTable(
                name: "Link");

            migrationBuilder.DropTable(
                name: "Lookups");

            migrationBuilder.DropTable(
                name: "Uploads");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "WorkSheets");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Templates");

            migrationBuilder.DropTable(
                name: "Organizations");

            migrationBuilder.DropTable(
                name: "Person");
        }
    }
}
