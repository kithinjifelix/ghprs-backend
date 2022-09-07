using Microsoft.EntityFrameworkCore.Migrations;

namespace GHPRS.Persistence.Migrations
{
    public partial class add_organisation_to_upload : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrganizationId",
                table: "Uploads",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Uploads_OrganizationId",
                table: "Uploads",
                column: "OrganizationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Uploads_Organizations_OrganizationId",
                table: "Uploads",
                column: "OrganizationId",
                principalTable: "Organizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Uploads_Organizations_OrganizationId",
                table: "Uploads");

            migrationBuilder.DropIndex(
                name: "IX_Uploads_OrganizationId",
                table: "Uploads");

            migrationBuilder.DropColumn(
                name: "OrganizationId",
                table: "Uploads");
        }
    }
}
