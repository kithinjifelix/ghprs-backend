using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace GHPRS.Persistence.Migrations
{
    public partial class add_tb_data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StagingTBData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MechanismID = table.Column<string>(name: "Mechanism ID", type: "text", nullable: true),
                    Partner = table.Column<string>(type: "text", nullable: true),
                    ReportingMonth = table.Column<string>(name: "Reporting Month", type: "text", nullable: true),
                    Year = table.Column<string>(type: "text", nullable: true),
                    Region = table.Column<string>(type: "text", nullable: true),
                    District = table.Column<string>(type: "text", nullable: true),
                    HealthFacility = table.Column<string>(name: "Health Facility", type: "text", nullable: true),
                    FacilityID = table.Column<string>(name: "Facility ID", type: "text", nullable: true),
                    TBDetectionMale014 = table.Column<string>(name: "TB Detection Male 0 - 14", type: "text", nullable: true),
                    TBDetectionMale15 = table.Column<string>(name: "TB Detection Male 15+", type: "text", nullable: true),
                    TBDetectionFemale014 = table.Column<string>(name: "TB Detection Female 0 - 14", type: "text", nullable: true),
                    TBDetectionFemale15 = table.Column<string>(name: "TB Detection Female 15+", type: "text", nullable: true),
                    BacteriologicalDiagnosisCoveragePulmonaryTB014 = table.Column<string>(name: "Bacteriological Diagnosis Coverage (Pulmonary TB) 0 - 14", type: "text", nullable: true),
                    BacteriologicalDiagnosisCoveragePulmonaryTB15 = table.Column<string>(name: "Bacteriological Diagnosis Coverage (Pulmonary TB) 15+", type: "text", nullable: true),
                    Upload_Batch = table.Column<string>(type: "text", nullable: true),
                    ReportDate = table.Column<string>(name: "Report Date", type: "text", nullable: true),
                    UploadBatchGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StagingTBData", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StagingTBData");
        }
    }
}
