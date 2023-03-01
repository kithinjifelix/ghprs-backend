using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GHPRS.Persistence.Migrations
{
    public partial class rename_site_id_community_data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Site ID/ ward ID (from DATIM)",
                table: "StagingCommunityData",
                newName: "Site ID/ward ID (from DATIM)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Site ID/ward ID (from DATIM)",
                table: "StagingCommunityData",
                newName: "Site ID/ ward ID (from DATIM)");
        }
    }
}
