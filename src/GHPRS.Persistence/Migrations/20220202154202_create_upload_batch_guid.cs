using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GHPRS.Persistence.Migrations
{
    public partial class create_upload_batch_guid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UploadBatchGuid",
                table: "Uploads",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UploadBatchGuid",
                table: "Uploads");
        }
    }
}
