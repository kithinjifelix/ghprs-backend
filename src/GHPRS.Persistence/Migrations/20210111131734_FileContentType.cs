using Microsoft.EntityFrameworkCore.Migrations;

namespace GHPRS.Persistence.Migrations
{
    public partial class FileContentType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ContentType",
                table: "Templates",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContentType",
                table: "Templates");
        }
    }
}
