using Microsoft.EntityFrameworkCore.Migrations;

namespace GHPRS.Persistence.Migrations
{
    public partial class create_upload_status_column : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UploadStatus",
                table: "Uploads",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UploadStatus",
                table: "Uploads");
        }
    }
}
