using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GHPRS.Persistence.Migrations
{
    public partial class include_upload_relationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FileUploadsId",
                table: "stg_facility_data",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FileUploadsId",
                table: "stg_community_data",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_stg_facility_data_FileUploadsId",
                table: "stg_facility_data",
                column: "FileUploadsId");

            migrationBuilder.CreateIndex(
                name: "IX_stg_community_data_FileUploadsId",
                table: "stg_community_data",
                column: "FileUploadsId");

            migrationBuilder.AddForeignKey(
                name: "FK_stg_community_data_FileUploads_FileUploadsId",
                table: "stg_community_data",
                column: "FileUploadsId",
                principalTable: "FileUploads",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_stg_facility_data_FileUploads_FileUploadsId",
                table: "stg_facility_data",
                column: "FileUploadsId",
                principalTable: "FileUploads",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_stg_community_data_FileUploads_FileUploadsId",
                table: "stg_community_data");

            migrationBuilder.DropForeignKey(
                name: "FK_stg_facility_data_FileUploads_FileUploadsId",
                table: "stg_facility_data");

            migrationBuilder.DropIndex(
                name: "IX_stg_facility_data_FileUploadsId",
                table: "stg_facility_data");

            migrationBuilder.DropIndex(
                name: "IX_stg_community_data_FileUploadsId",
                table: "stg_community_data");

            migrationBuilder.DropColumn(
                name: "FileUploadsId",
                table: "stg_facility_data");

            migrationBuilder.DropColumn(
                name: "FileUploadsId",
                table: "stg_community_data");
        }
    }
}
