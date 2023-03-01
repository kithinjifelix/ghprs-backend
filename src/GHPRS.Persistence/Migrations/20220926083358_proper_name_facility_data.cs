using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GHPRS.Persistence.Migrations
{
    public partial class proper_name_facility_data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PrEP_CT-Pregnant-Breastfeeding Women",
                table: "StagingFacilityData",
                newName: "PrEP_CT-Pregnant& Breastfeeding Women");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PrEP_CT-Pregnant& Breastfeeding Women",
                table: "StagingFacilityData",
                newName: "PrEP_CT-Pregnant-Breastfeeding Women");
        }
    }
}
