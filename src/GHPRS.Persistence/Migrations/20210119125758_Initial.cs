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
                    LookupType = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lookups", x => x.Id);
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
                        name: "FK_AspNetUsers_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkSheet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Range = table.Column<string>(type: "text", nullable: true),
                    TableName = table.Column<string>(type: "text", nullable: true),
                    TemplateId = table.Column<int>(type: "integer", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkSheet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkSheet_Templates_TemplateId",
                        column: x => x.TemplateId,
                        principalTable: "Templates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                        name: "FK_Columns_WorkSheet_WorkSheetId",
                        column: x => x.WorkSheetId,
                        principalTable: "WorkSheet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Link",
                columns: new[] { "Id", "CreatedAt", "Key", "LinkType", "Name", "Number", "UpdatedAt", "Url" },
                values: new object[,]
                {
                    { 8, new DateTime(2021, 1, 19, 15, 57, 58, 96, DateTimeKind.Local).AddTicks(655), "", 3, "Document Manager", 0, new DateTime(2021, 1, 19, 15, 57, 58, 96, DateTimeKind.Local).AddTicks(676), "/documents" },
                    { 25, new DateTime(2021, 1, 19, 15, 57, 58, 96, DateTimeKind.Local).AddTicks(1148), "80334b54cc4c696b67e0d20c2bc461b9d867781b4234af3819030209cbde6751", 0, "TX ML", 8, new DateTime(2021, 1, 19, 15, 57, 58, 96, DateTimeKind.Local).AddTicks(1149), "http://52.251.58.64:3000" },
                    { 24, new DateTime(2021, 1, 19, 15, 57, 58, 96, DateTimeKind.Local).AddTicks(1146), "80334b54cc4c696b67e0d20c2bc461b9d867781b4234af3819030209cbde6751", 0, "TX Curr and TX MMD", 4, new DateTime(2021, 1, 19, 15, 57, 58, 96, DateTimeKind.Local).AddTicks(1147), "http://52.251.58.64:3000" },
                    { 23, new DateTime(2021, 1, 19, 15, 57, 58, 96, DateTimeKind.Local).AddTicks(1143), "80334b54cc4c696b67e0d20c2bc461b9d867781b4234af3819030209cbde6751", 0, "HTS Testing Monthly Reporting", 3, new DateTime(2021, 1, 19, 15, 57, 58, 96, DateTimeKind.Local).AddTicks(1144), "http://52.251.58.64:3000" },
                    { 22, new DateTime(2021, 1, 19, 15, 57, 58, 96, DateTimeKind.Local).AddTicks(1140), "80334b54cc4c696b67e0d20c2bc461b9d867781b4234af3819030209cbde6751", 0, "TX New", 9, new DateTime(2021, 1, 19, 15, 57, 58, 96, DateTimeKind.Local).AddTicks(1141), "http://52.251.58.64:3000" },
                    { 21, new DateTime(2021, 1, 19, 15, 57, 58, 96, DateTimeKind.Local).AddTicks(1112), "80334b54cc4c696b67e0d20c2bc461b9d867781b4234af3819030209cbde6751", 0, "Pediatric ARV Optimization", 5, new DateTime(2021, 1, 19, 15, 57, 58, 96, DateTimeKind.Local).AddTicks(1116), "http://52.251.58.64:3000" },
                    { 19, new DateTime(2021, 1, 19, 15, 57, 58, 96, DateTimeKind.Local).AddTicks(755), "", 3, "World Bank Service Delivery Indicators", 0, new DateTime(2021, 1, 19, 15, 57, 58, 96, DateTimeKind.Local).AddTicks(756), "http://datatopics.worldbank.org/sdi/" },
                    { 18, new DateTime(2021, 1, 19, 15, 57, 58, 96, DateTimeKind.Local).AddTicks(752), "", 3, "World Bank", 0, new DateTime(2021, 1, 19, 15, 57, 58, 96, DateTimeKind.Local).AddTicks(754), "https://data.worldbank.org/" },
                    { 17, new DateTime(2021, 1, 19, 15, 57, 58, 96, DateTimeKind.Local).AddTicks(750), "", 3, "Global Health Data", 0, new DateTime(2021, 1, 19, 15, 57, 58, 96, DateTimeKind.Local).AddTicks(751), "http://apps.who.int/gho/data/node.home" },
                    { 20, new DateTime(2021, 1, 19, 15, 57, 58, 96, DateTimeKind.Local).AddTicks(758), "", 3, "WHO Global Health Observatory", 0, new DateTime(2021, 1, 19, 15, 57, 58, 96, DateTimeKind.Local).AddTicks(759), "/Observatory" },
                    { 15, new DateTime(2021, 1, 19, 15, 57, 58, 96, DateTimeKind.Local).AddTicks(745), "", 3, "STAT Compiler", 0, new DateTime(2021, 1, 19, 15, 57, 58, 96, DateTimeKind.Local).AddTicks(746), "https://statcompiler.com/en/" },
                    { 14, new DateTime(2021, 1, 19, 15, 57, 58, 96, DateTimeKind.Local).AddTicks(742), "", 3, "IP Reporting System", 0, new DateTime(2021, 1, 19, 15, 57, 58, 96, DateTimeKind.Local).AddTicks(743), "https://usaidtanzaniaiprs.com/index.cfm" },
                    { 13, new DateTime(2021, 1, 19, 15, 57, 58, 96, DateTimeKind.Local).AddTicks(739), "", 3, "Monthly Portal", 0, new DateTime(2021, 1, 19, 15, 57, 58, 96, DateTimeKind.Local).AddTicks(740), "http://hmis.reachproject.or.tz/MonthlyReporting/" },
                    { 12, new DateTime(2021, 1, 19, 15, 57, 58, 96, DateTimeKind.Local).AddTicks(737), "", 3, "Partner Performance Report", 0, new DateTime(2021, 1, 19, 15, 57, 58, 96, DateTimeKind.Local).AddTicks(738), "https://www.pepfar.net/OGAC-HQ/icpi/Products/Forms/AllItems.aspx" },
                    { 11, new DateTime(2021, 1, 19, 15, 57, 58, 96, DateTimeKind.Local).AddTicks(734), "", 3, "OHA Dashboard", 0, new DateTime(2021, 1, 19, 15, 57, 58, 96, DateTimeKind.Local).AddTicks(735), "https://sites.google.com/a/usaid.gov/gh-oha/home/reports-resources/quarterly-reporting-guidance-and-resources" },
                    { 10, new DateTime(2021, 1, 19, 15, 57, 58, 96, DateTimeKind.Local).AddTicks(731), "", 3, "Panaroma Dashboard", 0, new DateTime(2021, 1, 19, 15, 57, 58, 96, DateTimeKind.Local).AddTicks(732), "https://pepfar-panorama.org/" },
                    { 9, new DateTime(2021, 1, 19, 15, 57, 58, 96, DateTimeKind.Local).AddTicks(727), "", 3, "DATIM", 0, new DateTime(2021, 1, 19, 15, 57, 58, 96, DateTimeKind.Local).AddTicks(729), "https://www.datim.org/dhis" },
                    { 16, new DateTime(2021, 1, 19, 15, 57, 58, 96, DateTimeKind.Local).AddTicks(747), "", 3, "UNICEF (MICS)", 0, new DateTime(2021, 1, 19, 15, 57, 58, 96, DateTimeKind.Local).AddTicks(748), "https://data.unicef.org/" }
                });

            migrationBuilder.InsertData(
                table: "Lookups",
                columns: new[] { "Id", "CreatedAt", "LookupType", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 6, new DateTime(2021, 1, 19, 15, 57, 58, 92, DateTimeKind.Local).AddTicks(2583), 1, "Widow", new DateTime(2021, 1, 19, 15, 57, 58, 92, DateTimeKind.Local).AddTicks(2585) },
                    { 1, new DateTime(2021, 1, 19, 15, 57, 58, 91, DateTimeKind.Local).AddTicks(3874), 0, "Male", new DateTime(2021, 1, 19, 15, 57, 58, 92, DateTimeKind.Local).AddTicks(2019) },
                    { 2, new DateTime(2021, 1, 19, 15, 57, 58, 92, DateTimeKind.Local).AddTicks(2551), 0, "Female", new DateTime(2021, 1, 19, 15, 57, 58, 92, DateTimeKind.Local).AddTicks(2566) },
                    { 3, new DateTime(2021, 1, 19, 15, 57, 58, 92, DateTimeKind.Local).AddTicks(2576), 1, "Single", new DateTime(2021, 1, 19, 15, 57, 58, 92, DateTimeKind.Local).AddTicks(2577) },
                    { 4, new DateTime(2021, 1, 19, 15, 57, 58, 92, DateTimeKind.Local).AddTicks(2578), 1, "Married", new DateTime(2021, 1, 19, 15, 57, 58, 92, DateTimeKind.Local).AddTicks(2579) },
                    { 5, new DateTime(2021, 1, 19, 15, 57, 58, 92, DateTimeKind.Local).AddTicks(2581), 1, "Divorced", new DateTime(2021, 1, 19, 15, 57, 58, 92, DateTimeKind.Local).AddTicks(2582) },
                    { 7, new DateTime(2021, 1, 19, 15, 57, 58, 92, DateTimeKind.Local).AddTicks(2586), 1, "Widower", new DateTime(2021, 1, 19, 15, 57, 58, 92, DateTimeKind.Local).AddTicks(2587) }
                });

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
                name: "IX_WorkSheet_TemplateId",
                table: "WorkSheet",
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
                name: "WorkSheet");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Templates");

            migrationBuilder.DropTable(
                name: "Person");
        }
    }
}
