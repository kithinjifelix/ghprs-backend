using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace GHPRS.Persistence.Migrations
{
    public partial class add_mer_data_entity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FileUploads",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    ContentType = table.Column<string>(type: "text", nullable: true),
                    File = table.Column<byte[]>(type: "bytea", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: true),
                    UploadDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileUploads", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FileUploads_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "stg_mer_data",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    orgunituid = table.Column<string>(type: "text", nullable: true),
                    sitename = table.Column<string>(type: "text", nullable: true),
                    operatingunit = table.Column<string>(type: "text", nullable: true),
                    operatingunituid = table.Column<string>(type: "text", nullable: true),
                    country = table.Column<string>(type: "text", nullable: true),
                    snu1 = table.Column<string>(type: "text", nullable: true),
                    snu1uid = table.Column<string>(type: "text", nullable: true),
                    psnu = table.Column<string>(type: "text", nullable: true),
                    psnuuid = table.Column<string>(type: "text", nullable: true),
                    snuprioritization = table.Column<string>(type: "text", nullable: true),
                    typemilitary = table.Column<string>(type: "text", nullable: true),
                    dreams = table.Column<string>(type: "text", nullable: true),
                    prime_partner_name = table.Column<string>(type: "text", nullable: true),
                    funding_agency = table.Column<string>(type: "text", nullable: true),
                    mech_code = table.Column<string>(type: "text", nullable: true),
                    mech_name = table.Column<string>(type: "text", nullable: true),
                    prime_partner_duns = table.Column<string>(type: "text", nullable: true),
                    prime_partner_uei = table.Column<string>(type: "text", nullable: true),
                    award_number = table.Column<string>(type: "text", nullable: true),
                    communityuid = table.Column<string>(type: "text", nullable: true),
                    community = table.Column<string>(type: "text", nullable: true),
                    facilityuid = table.Column<string>(type: "text", nullable: true),
                    facility = table.Column<string>(type: "text", nullable: true),
                    sitetype = table.Column<string>(type: "text", nullable: true),
                    indicator = table.Column<string>(type: "text", nullable: true),
                    numeratordenom = table.Column<string>(type: "text", nullable: true),
                    indicatortype = table.Column<string>(type: "text", nullable: true),
                    disaggregate = table.Column<string>(type: "text", nullable: true),
                    standardizeddisaggregate = table.Column<string>(type: "text", nullable: true),
                    categoryoptioncomboname = table.Column<string>(type: "text", nullable: true),
                    ageasentered = table.Column<string>(type: "text", nullable: true),
                    age_2018 = table.Column<string>(type: "text", nullable: true),
                    age_2019 = table.Column<string>(type: "text", nullable: true),
                    trendscoarse = table.Column<string>(type: "text", nullable: true),
                    sex = table.Column<string>(type: "text", nullable: true),
                    statushiv = table.Column<string>(type: "text", nullable: true),
                    statustb = table.Column<string>(type: "text", nullable: true),
                    statuscx = table.Column<string>(type: "text", nullable: true),
                    hiv_treatment_status = table.Column<string>(type: "text", nullable: true),
                    otherdisaggregate = table.Column<string>(type: "text", nullable: true),
                    otherdisaggregate_sub = table.Column<string>(type: "text", nullable: true),
                    modality = table.Column<string>(type: "text", nullable: true),
                    fiscal_year = table.Column<string>(type: "text", nullable: true),
                    targets = table.Column<string>(type: "text", nullable: true),
                    qtr1 = table.Column<string>(type: "text", nullable: true),
                    qtr2 = table.Column<string>(type: "text", nullable: true),
                    qtr3 = table.Column<string>(type: "text", nullable: true),
                    qtr4 = table.Column<string>(type: "text", nullable: true),
                    cumulative = table.Column<string>(type: "text", nullable: true),
                    source_name = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_stg_mer_data", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FileUploads_UserId",
                table: "FileUploads",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FileUploads");

            migrationBuilder.DropTable(
                name: "stg_mer_data");
        }
    }
}
