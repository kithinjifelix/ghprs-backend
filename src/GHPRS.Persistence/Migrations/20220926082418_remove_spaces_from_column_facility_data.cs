using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GHPRS.Persistence.Migrations
{
    public partial class remove_spaces_from_column_facility_data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "VL_ELIG _A ",
                table: "StagingFacilityData",
                newName: "VL_ELIG _A");

            migrationBuilder.RenameColumn(
                name: "PrEP_CT-Serodiscordant Couple ",
                table: "StagingFacilityData",
                newName: "PrEP_CT-Serodiscordant Couple");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "VL_ELIG _A",
                table: "StagingFacilityData",
                newName: "VL_ELIG _A ");

            migrationBuilder.RenameColumn(
                name: "PrEP_CT-Serodiscordant Couple",
                table: "StagingFacilityData",
                newName: "PrEP_CT-Serodiscordant Couple ");
        }
    }
}
