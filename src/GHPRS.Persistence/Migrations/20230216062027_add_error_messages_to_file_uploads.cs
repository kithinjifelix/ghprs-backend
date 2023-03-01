using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GHPRS.Persistence.Migrations
{
    public partial class add_error_messages_to_file_uploads : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ErrorMessage",
                table: "FileUploads",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ErrorMessage",
                table: "FileUploads");
        }
    }
}
