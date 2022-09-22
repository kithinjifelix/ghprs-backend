using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GHPRS.Persistence.Migrations
{
    public partial class wrongly_named_columns_community_data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "C_POS_PEDS",
                table: "StagingCommunityData",
                newName: "POS_PEDS");

            migrationBuilder.RenameColumn(
                name: "C_POS_A",
                table: "StagingCommunityData",
                newName: "POS_A");

            migrationBuilder.RenameColumn(
                name: "C_NEG_PEDS",
                table: "StagingCommunityData",
                newName: "NEG_PEDS");

            migrationBuilder.RenameColumn(
                name: "C_NEG_A",
                table: "StagingCommunityData",
                newName: "NEG_A");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "POS_PEDS",
                table: "StagingCommunityData",
                newName: "C_POS_PEDS");

            migrationBuilder.RenameColumn(
                name: "POS_A",
                table: "StagingCommunityData",
                newName: "C_POS_A");

            migrationBuilder.RenameColumn(
                name: "NEG_PEDS",
                table: "StagingCommunityData",
                newName: "C_NEG_PEDS");

            migrationBuilder.RenameColumn(
                name: "NEG_A",
                table: "StagingCommunityData",
                newName: "C_NEG_A");
        }
    }
}
