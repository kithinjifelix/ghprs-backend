using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GHPRS.Persistence.Migrations
{
    public partial class columns_updated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Site ID/ward ID (from DATIM)",
                table: "stg_community_data",
                newName: "Site ID/ ward ID (from DATIM)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Site ID/ ward ID (from DATIM)",
                table: "stg_community_data",
                newName: "Site ID/ward ID (from DATIM)");
        }
    }
}
