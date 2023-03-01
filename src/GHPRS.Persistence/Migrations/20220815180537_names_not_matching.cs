using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GHPRS.Persistence.Migrations
{
    public partial class names_not_matching : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "POS_A",
                table: "stg_community_data",
                newName: "C_POS_A");

            migrationBuilder.RenameColumn(
                name: "NEG_A",
                table: "stg_community_data",
                newName: "C_NEG_A");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "C_POS_A",
                table: "stg_community_data",
                newName: "POS_A");

            migrationBuilder.RenameColumn(
                name: "C_NEG_A",
                table: "stg_community_data",
                newName: "NEG_A");
        }
    }
}
