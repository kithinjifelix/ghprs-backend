using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GHPRS.Persistence.Migrations
{
    public partial class missing_columns_community_data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HTS_SNS_Female 15+",
                table: "StagingCommunityData",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HTS_SNS_Female<15",
                table: "StagingCommunityData",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HTS_SNS_Male 15+",
                table: "StagingCommunityData",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HTS_SNS_Male<15",
                table: "StagingCommunityData",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "POS_Mobile_ADULTS",
                table: "StagingCommunityData",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "POS_Mobile_PEDS",
                table: "StagingCommunityData",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "POS_SNS_Female 15+",
                table: "StagingCommunityData",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "POS_SNS_Female<15",
                table: "StagingCommunityData",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "POS_SNS_Male 15+",
                table: "StagingCommunityData",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "POS_SNS_Male<15",
                table: "StagingCommunityData",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HTS_SNS_Female 15+",
                table: "StagingCommunityData");

            migrationBuilder.DropColumn(
                name: "HTS_SNS_Female<15",
                table: "StagingCommunityData");

            migrationBuilder.DropColumn(
                name: "HTS_SNS_Male 15+",
                table: "StagingCommunityData");

            migrationBuilder.DropColumn(
                name: "HTS_SNS_Male<15",
                table: "StagingCommunityData");

            migrationBuilder.DropColumn(
                name: "POS_Mobile_ADULTS",
                table: "StagingCommunityData");

            migrationBuilder.DropColumn(
                name: "POS_Mobile_PEDS",
                table: "StagingCommunityData");

            migrationBuilder.DropColumn(
                name: "POS_SNS_Female 15+",
                table: "StagingCommunityData");

            migrationBuilder.DropColumn(
                name: "POS_SNS_Female<15",
                table: "StagingCommunityData");

            migrationBuilder.DropColumn(
                name: "POS_SNS_Male 15+",
                table: "StagingCommunityData");

            migrationBuilder.DropColumn(
                name: "POS_SNS_Male<15",
                table: "StagingCommunityData");
        }
    }
}
