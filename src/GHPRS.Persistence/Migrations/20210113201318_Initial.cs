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
                    Description = table.Column<string>(type: "text", nullable: true),
                    File = table.Column<byte[]>(type: "bytea", nullable: true),
                    ContentType = table.Column<string>(type: "text", nullable: true),
                    Version = table.Column<decimal>(type: "numeric", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
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
                    File = table.Column<byte[]>(type: "bytea", nullable: true),
                    ContentType = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    Comments = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: true),
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
                });

            migrationBuilder.InsertData(
                table: "Link",
                columns: new[] { "Id", "CreatedAt", "Key", "LinkType", "Name", "UpdatedAt", "Url" },
                values: new object[,]
                {
                    { 8, new DateTime(2021, 1, 13, 23, 13, 17, 726, DateTimeKind.Local).AddTicks(765), "", 3, "Document Manager", new DateTime(2021, 1, 13, 23, 13, 17, 726, DateTimeKind.Local).AddTicks(797), "/documents" },
                    { 20, new DateTime(2021, 1, 13, 23, 13, 17, 726, DateTimeKind.Local).AddTicks(884), "", 3, "WHO Global Health Observatory", new DateTime(2021, 1, 13, 23, 13, 17, 726, DateTimeKind.Local).AddTicks(885), "/Observatory" },
                    { 19, new DateTime(2021, 1, 13, 23, 13, 17, 726, DateTimeKind.Local).AddTicks(881), "", 3, "World Bank Service Delivery Indicators", new DateTime(2021, 1, 13, 23, 13, 17, 726, DateTimeKind.Local).AddTicks(882), "http://datatopics.worldbank.org/sdi/" },
                    { 18, new DateTime(2021, 1, 13, 23, 13, 17, 726, DateTimeKind.Local).AddTicks(879), "", 3, "World Bank", new DateTime(2021, 1, 13, 23, 13, 17, 726, DateTimeKind.Local).AddTicks(880), "https://data.worldbank.org/" },
                    { 16, new DateTime(2021, 1, 13, 23, 13, 17, 726, DateTimeKind.Local).AddTicks(873), "", 3, "UNICEF (MICS)", new DateTime(2021, 1, 13, 23, 13, 17, 726, DateTimeKind.Local).AddTicks(874), "https://data.unicef.org/" },
                    { 15, new DateTime(2021, 1, 13, 23, 13, 17, 726, DateTimeKind.Local).AddTicks(871), "", 3, "STAT Compiler", new DateTime(2021, 1, 13, 23, 13, 17, 726, DateTimeKind.Local).AddTicks(872), "https://statcompiler.com/en/" },
                    { 17, new DateTime(2021, 1, 13, 23, 13, 17, 726, DateTimeKind.Local).AddTicks(876), "", 3, "Global Health Data", new DateTime(2021, 1, 13, 23, 13, 17, 726, DateTimeKind.Local).AddTicks(877), "http://apps.who.int/gho/data/node.home" },
                    { 13, new DateTime(2021, 1, 13, 23, 13, 17, 726, DateTimeKind.Local).AddTicks(865), "", 3, "Monthly Portal", new DateTime(2021, 1, 13, 23, 13, 17, 726, DateTimeKind.Local).AddTicks(866), "http://hmis.reachproject.or.tz/MonthlyReporting/" },
                    { 12, new DateTime(2021, 1, 13, 23, 13, 17, 726, DateTimeKind.Local).AddTicks(863), "", 3, "Partner Performance Report", new DateTime(2021, 1, 13, 23, 13, 17, 726, DateTimeKind.Local).AddTicks(864), "https://www.pepfar.net/OGAC-HQ/icpi/Products/Forms/AllItems.aspx" },
                    { 11, new DateTime(2021, 1, 13, 23, 13, 17, 726, DateTimeKind.Local).AddTicks(860), "", 3, "OHA Dashboard", new DateTime(2021, 1, 13, 23, 13, 17, 726, DateTimeKind.Local).AddTicks(861), "https://sites.google.com/a/usaid.gov/gh-oha/home/reports-resources/quarterly-reporting-guidance-and-resources" },
                    { 10, new DateTime(2021, 1, 13, 23, 13, 17, 726, DateTimeKind.Local).AddTicks(857), "", 3, "Panaroma Dashboard", new DateTime(2021, 1, 13, 23, 13, 17, 726, DateTimeKind.Local).AddTicks(858), "https://pepfar-panorama.org/" },
                    { 9, new DateTime(2021, 1, 13, 23, 13, 17, 726, DateTimeKind.Local).AddTicks(853), "", 3, "DATIM", new DateTime(2021, 1, 13, 23, 13, 17, 726, DateTimeKind.Local).AddTicks(854), "https://www.datim.org/dhis" },
                    { 14, new DateTime(2021, 1, 13, 23, 13, 17, 726, DateTimeKind.Local).AddTicks(868), "", 3, "IP Reporting System", new DateTime(2021, 1, 13, 23, 13, 17, 726, DateTimeKind.Local).AddTicks(869), "https://usaidtanzaniaiprs.com/index.cfm" }
                });

            migrationBuilder.InsertData(
                table: "Lookups",
                columns: new[] { "Id", "CreatedAt", "LookupType", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 6, new DateTime(2021, 1, 13, 23, 13, 17, 722, DateTimeKind.Local).AddTicks(2467), 1, "Widow", new DateTime(2021, 1, 13, 23, 13, 17, 722, DateTimeKind.Local).AddTicks(2468) },
                    { 1, new DateTime(2021, 1, 13, 23, 13, 17, 721, DateTimeKind.Local).AddTicks(4174), 0, "Male", new DateTime(2021, 1, 13, 23, 13, 17, 722, DateTimeKind.Local).AddTicks(1886) },
                    { 2, new DateTime(2021, 1, 13, 23, 13, 17, 722, DateTimeKind.Local).AddTicks(2436), 0, "Female", new DateTime(2021, 1, 13, 23, 13, 17, 722, DateTimeKind.Local).AddTicks(2450) },
                    { 3, new DateTime(2021, 1, 13, 23, 13, 17, 722, DateTimeKind.Local).AddTicks(2458), 1, "Single", new DateTime(2021, 1, 13, 23, 13, 17, 722, DateTimeKind.Local).AddTicks(2460) },
                    { 4, new DateTime(2021, 1, 13, 23, 13, 17, 722, DateTimeKind.Local).AddTicks(2461), 1, "Married", new DateTime(2021, 1, 13, 23, 13, 17, 722, DateTimeKind.Local).AddTicks(2462) },
                    { 5, new DateTime(2021, 1, 13, 23, 13, 17, 722, DateTimeKind.Local).AddTicks(2464), 1, "Divorced", new DateTime(2021, 1, 13, 23, 13, 17, 722, DateTimeKind.Local).AddTicks(2465) },
                    { 7, new DateTime(2021, 1, 13, 23, 13, 17, 722, DateTimeKind.Local).AddTicks(2469), 1, "Widower", new DateTime(2021, 1, 13, 23, 13, 17, 722, DateTimeKind.Local).AddTicks(2470) }
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
                name: "IX_Uploads_UserId",
                table: "Uploads",
                column: "UserId");
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
                name: "Link");

            migrationBuilder.DropTable(
                name: "Lookups");

            migrationBuilder.DropTable(
                name: "Templates");

            migrationBuilder.DropTable(
                name: "Uploads");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Person");
        }
    }
}
