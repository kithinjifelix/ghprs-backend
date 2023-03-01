using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GHPRS.Persistence.Migrations
{
    public partial class rename_mer_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_stg_mer_data_FileUploads_FileUploadsId",
                table: "stg_mer_data");

            migrationBuilder.DropPrimaryKey(
                name: "PK_stg_mer_data",
                table: "stg_mer_data");

            migrationBuilder.RenameTable(
                name: "stg_mer_data",
                newName: "StagingMerData");

            migrationBuilder.RenameIndex(
                name: "IX_stg_mer_data_FileUploadsId",
                table: "StagingMerData",
                newName: "IX_StagingMerData_FileUploadsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StagingMerData",
                table: "StagingMerData",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StagingMerData_FileUploads_FileUploadsId",
                table: "StagingMerData",
                column: "FileUploadsId",
                principalTable: "FileUploads",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StagingMerData_FileUploads_FileUploadsId",
                table: "StagingMerData");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StagingMerData",
                table: "StagingMerData");

            migrationBuilder.RenameTable(
                name: "StagingMerData",
                newName: "stg_mer_data");

            migrationBuilder.RenameIndex(
                name: "IX_StagingMerData_FileUploadsId",
                table: "stg_mer_data",
                newName: "IX_stg_mer_data_FileUploadsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_stg_mer_data",
                table: "stg_mer_data",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_stg_mer_data_FileUploads_FileUploadsId",
                table: "stg_mer_data",
                column: "FileUploadsId",
                principalTable: "FileUploads",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
