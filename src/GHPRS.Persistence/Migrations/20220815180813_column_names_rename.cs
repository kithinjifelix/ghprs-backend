using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GHPRS.Persistence.Migrations
{
    public partial class column_names_rename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "POS_PEDS",
                table: "stg_community_data",
                newName: "C_POS_PEDS");

            migrationBuilder.RenameColumn(
                name: "NEG_PEDS",
                table: "stg_community_data",
                newName: "C_NEG_PEDS");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "C_POS_PEDS",
                table: "stg_community_data",
                newName: "POS_PEDS");

            migrationBuilder.RenameColumn(
                name: "C_NEG_PEDS",
                table: "stg_community_data",
                newName: "NEG_PEDS");
        }
    }
}
