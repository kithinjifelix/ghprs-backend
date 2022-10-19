using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace GHPRS.Persistence.Migrations
{
    public partial class plhiv_data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StagingPLHIVData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    operatingunit = table.Column<string>(type: "text", nullable: true),
                    operatingunituid = table.Column<string>(type: "text", nullable: true),
                    country = table.Column<string>(type: "text", nullable: true),
                    snu1 = table.Column<string>(type: "text", nullable: true),
                    snu1uid = table.Column<string>(type: "text", nullable: true),
                    psnu = table.Column<string>(type: "text", nullable: true),
                    psnuuid = table.Column<string>(type: "text", nullable: true),
                    snuprioritization = table.Column<string>(type: "text", nullable: true),
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
                    otherdisaggregate = table.Column<string>(type: "text", nullable: true),
                    fiscal_year = table.Column<string>(type: "text", nullable: true),
                    targets = table.Column<string>(type: "text", nullable: true),
                    qtr4 = table.Column<string>(type: "text", nullable: true),
                    source_name = table.Column<string>(type: "text", nullable: true),
                    FileUploadsId = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StagingPLHIVData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StagingPLHIVData_FileUploads_FileUploadsId",
                        column: x => x.FileUploadsId,
                        principalTable: "FileUploads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StagingPLHIVData_FileUploadsId",
                table: "StagingPLHIVData",
                column: "FileUploadsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StagingPLHIVData");
        }
    }
}
