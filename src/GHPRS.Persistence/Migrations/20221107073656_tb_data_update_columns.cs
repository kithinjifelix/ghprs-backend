using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GHPRS.Persistence.Migrations
{
    public partial class tb_data_update_columns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Mechanism ID",
                table: "StagingTBData",
                newName: "MECHANISM ID");

            migrationBuilder.RenameColumn(
                name: "TB Detection Male 15+",
                table: "StagingTBData",
                newName: "TB_Detection_Male_15+");

            migrationBuilder.RenameColumn(
                name: "TB Detection Male 0 - 14",
                table: "StagingTBData",
                newName: "TB_Detection_Male_0-14");

            migrationBuilder.RenameColumn(
                name: "TB Detection Female 15+",
                table: "StagingTBData",
                newName: "TB_Detection_Female_15+");

            migrationBuilder.RenameColumn(
                name: "TB Detection Female 0 - 14",
                table: "StagingTBData",
                newName: "TB_Detection_Female_0-14");

            migrationBuilder.RenameColumn(
                name: "Reporting Month",
                table: "StagingTBData",
                newName: "Month");

            migrationBuilder.RenameColumn(
                name: "Health Facility",
                table: "StagingTBData",
                newName: "Site Name");

            migrationBuilder.RenameColumn(
                name: "Facility ID",
                table: "StagingTBData",
                newName: "Site_ID");

            migrationBuilder.RenameColumn(
                name: "Bacteriological Diagnosis Coverage (Pulmonary TB) 15+",
                table: "StagingTBData",
                newName: "Pulmonary_TB_15+");

            migrationBuilder.RenameColumn(
                name: "Bacteriological Diagnosis Coverage (Pulmonary TB) 0 - 14",
                table: "StagingTBData",
                newName: "Pulmonary_TB_0-14");

            migrationBuilder.AddColumn<string>(
                name: "Agency",
                table: "StagingTBData",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Council",
                table: "StagingTBData",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Priority_Tier",
                table: "StagingTBData",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ward",
                table: "StagingTBData",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Agency",
                table: "StagingTBData");

            migrationBuilder.DropColumn(
                name: "Council",
                table: "StagingTBData");

            migrationBuilder.DropColumn(
                name: "Priority_Tier",
                table: "StagingTBData");

            migrationBuilder.DropColumn(
                name: "Ward",
                table: "StagingTBData");

            migrationBuilder.RenameColumn(
                name: "MECHANISM ID",
                table: "StagingTBData",
                newName: "Mechanism ID");

            migrationBuilder.RenameColumn(
                name: "TB_Detection_Male_15+",
                table: "StagingTBData",
                newName: "TB Detection Male 15+");

            migrationBuilder.RenameColumn(
                name: "TB_Detection_Male_0-14",
                table: "StagingTBData",
                newName: "TB Detection Male 0 - 14");

            migrationBuilder.RenameColumn(
                name: "TB_Detection_Female_15+",
                table: "StagingTBData",
                newName: "TB Detection Female 15+");

            migrationBuilder.RenameColumn(
                name: "TB_Detection_Female_0-14",
                table: "StagingTBData",
                newName: "TB Detection Female 0 - 14");

            migrationBuilder.RenameColumn(
                name: "Site_ID",
                table: "StagingTBData",
                newName: "Facility ID");

            migrationBuilder.RenameColumn(
                name: "Site Name",
                table: "StagingTBData",
                newName: "Health Facility");

            migrationBuilder.RenameColumn(
                name: "Pulmonary_TB_15+",
                table: "StagingTBData",
                newName: "Bacteriological Diagnosis Coverage (Pulmonary TB) 15+");

            migrationBuilder.RenameColumn(
                name: "Pulmonary_TB_0-14",
                table: "StagingTBData",
                newName: "Bacteriological Diagnosis Coverage (Pulmonary TB) 0 - 14");

            migrationBuilder.RenameColumn(
                name: "Month",
                table: "StagingTBData",
                newName: "Reporting Month");
        }
    }
}
