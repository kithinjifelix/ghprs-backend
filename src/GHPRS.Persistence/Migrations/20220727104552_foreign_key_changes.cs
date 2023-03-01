using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GHPRS.Persistence.Migrations
{
    public partial class foreign_key_changes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_stg_community_data_FileUploads_FileUploadsId",
                table: "stg_community_data");

            migrationBuilder.DropForeignKey(
                name: "FK_stg_facility_data_FileUploads_FileUploadsId",
                table: "stg_facility_data");

            migrationBuilder.DropForeignKey(
                name: "FK_stg_mer_data_FileUploads_FileUploadsId",
                table: "stg_mer_data");

            migrationBuilder.AlterColumn<int>(
                name: "FileUploadsId",
                table: "stg_mer_data",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FileUploadsId",
                table: "stg_facility_data",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FileUploadsId",
                table: "stg_community_data",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_stg_community_data_FileUploads_FileUploadsId",
                table: "stg_community_data",
                column: "FileUploadsId",
                principalTable: "FileUploads",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_stg_facility_data_FileUploads_FileUploadsId",
                table: "stg_facility_data",
                column: "FileUploadsId",
                principalTable: "FileUploads",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_stg_mer_data_FileUploads_FileUploadsId",
                table: "stg_mer_data",
                column: "FileUploadsId",
                principalTable: "FileUploads",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_stg_community_data_FileUploads_FileUploadsId",
                table: "stg_community_data");

            migrationBuilder.DropForeignKey(
                name: "FK_stg_facility_data_FileUploads_FileUploadsId",
                table: "stg_facility_data");

            migrationBuilder.DropForeignKey(
                name: "FK_stg_mer_data_FileUploads_FileUploadsId",
                table: "stg_mer_data");

            migrationBuilder.AlterColumn<int>(
                name: "FileUploadsId",
                table: "stg_mer_data",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "FileUploadsId",
                table: "stg_facility_data",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "FileUploadsId",
                table: "stg_community_data",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

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

            migrationBuilder.AddForeignKey(
                name: "FK_stg_mer_data_FileUploads_FileUploadsId",
                table: "stg_mer_data",
                column: "FileUploadsId",
                principalTable: "FileUploads",
                principalColumn: "Id");
        }
    }
}
