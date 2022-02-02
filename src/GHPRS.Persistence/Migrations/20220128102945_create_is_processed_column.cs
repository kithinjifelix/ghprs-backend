using Microsoft.EntityFrameworkCore.Migrations;

namespace GHPRS.Persistence.Migrations
{
    public partial class create_is_processed_column : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsProcessed",
                table: "Uploads",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsProcessed",
                table: "Uploads");
        }
    }
}
