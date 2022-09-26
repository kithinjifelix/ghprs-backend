using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GHPRS.Persistence.Migrations
{
    public partial class column_notnamed_properly_facility_data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PrEP_NEW-Pregnant-Breastfeeding Women",
                table: "StagingFacilityData",
                newName: "PrEP_NEW-Pregnant& Breastfeeding Women");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PrEP_NEW-Pregnant& Breastfeeding Women",
                table: "StagingFacilityData",
                newName: "PrEP_NEW-Pregnant-Breastfeeding Women");
        }
    }
}
