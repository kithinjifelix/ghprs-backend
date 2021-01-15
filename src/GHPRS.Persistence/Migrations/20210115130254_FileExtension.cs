using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GHPRS.Persistence.Migrations
{
    public partial class FileExtension : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FileExtension",
                table: "Uploads",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileExtension",
                table: "Templates",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Link",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 1, 15, 16, 2, 54, 272, DateTimeKind.Local).AddTicks(7551), new DateTime(2021, 1, 15, 16, 2, 54, 272, DateTimeKind.Local).AddTicks(7574) });

            migrationBuilder.UpdateData(
                table: "Link",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 1, 15, 16, 2, 54, 272, DateTimeKind.Local).AddTicks(7631), new DateTime(2021, 1, 15, 16, 2, 54, 272, DateTimeKind.Local).AddTicks(7633) });

            migrationBuilder.UpdateData(
                table: "Link",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 1, 15, 16, 2, 54, 272, DateTimeKind.Local).AddTicks(7635), new DateTime(2021, 1, 15, 16, 2, 54, 272, DateTimeKind.Local).AddTicks(7636) });

            migrationBuilder.UpdateData(
                table: "Link",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 1, 15, 16, 2, 54, 272, DateTimeKind.Local).AddTicks(7638), new DateTime(2021, 1, 15, 16, 2, 54, 272, DateTimeKind.Local).AddTicks(7639) });

            migrationBuilder.UpdateData(
                table: "Link",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 1, 15, 16, 2, 54, 272, DateTimeKind.Local).AddTicks(7641), new DateTime(2021, 1, 15, 16, 2, 54, 272, DateTimeKind.Local).AddTicks(7642) });

            migrationBuilder.UpdateData(
                table: "Link",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 1, 15, 16, 2, 54, 272, DateTimeKind.Local).AddTicks(7643), new DateTime(2021, 1, 15, 16, 2, 54, 272, DateTimeKind.Local).AddTicks(7644) });

            migrationBuilder.UpdateData(
                table: "Link",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 1, 15, 16, 2, 54, 272, DateTimeKind.Local).AddTicks(7646), new DateTime(2021, 1, 15, 16, 2, 54, 272, DateTimeKind.Local).AddTicks(7647) });

            migrationBuilder.UpdateData(
                table: "Link",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 1, 15, 16, 2, 54, 272, DateTimeKind.Local).AddTicks(7649), new DateTime(2021, 1, 15, 16, 2, 54, 272, DateTimeKind.Local).AddTicks(7649) });

            migrationBuilder.UpdateData(
                table: "Link",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 1, 15, 16, 2, 54, 272, DateTimeKind.Local).AddTicks(7651), new DateTime(2021, 1, 15, 16, 2, 54, 272, DateTimeKind.Local).AddTicks(7652) });

            migrationBuilder.UpdateData(
                table: "Link",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 1, 15, 16, 2, 54, 272, DateTimeKind.Local).AddTicks(7654), new DateTime(2021, 1, 15, 16, 2, 54, 272, DateTimeKind.Local).AddTicks(7655) });

            migrationBuilder.UpdateData(
                table: "Link",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 1, 15, 16, 2, 54, 272, DateTimeKind.Local).AddTicks(7656), new DateTime(2021, 1, 15, 16, 2, 54, 272, DateTimeKind.Local).AddTicks(7657) });

            migrationBuilder.UpdateData(
                table: "Link",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 1, 15, 16, 2, 54, 272, DateTimeKind.Local).AddTicks(7659), new DateTime(2021, 1, 15, 16, 2, 54, 272, DateTimeKind.Local).AddTicks(7660) });

            migrationBuilder.UpdateData(
                table: "Link",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 1, 15, 16, 2, 54, 272, DateTimeKind.Local).AddTicks(7661), new DateTime(2021, 1, 15, 16, 2, 54, 272, DateTimeKind.Local).AddTicks(7662) });

            migrationBuilder.UpdateData(
                table: "Lookups",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 1, 15, 16, 2, 54, 268, DateTimeKind.Local).AddTicks(1483), new DateTime(2021, 1, 15, 16, 2, 54, 268, DateTimeKind.Local).AddTicks(9986) });

            migrationBuilder.UpdateData(
                table: "Lookups",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 1, 15, 16, 2, 54, 269, DateTimeKind.Local).AddTicks(530), new DateTime(2021, 1, 15, 16, 2, 54, 269, DateTimeKind.Local).AddTicks(541) });

            migrationBuilder.UpdateData(
                table: "Lookups",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 1, 15, 16, 2, 54, 269, DateTimeKind.Local).AddTicks(549), new DateTime(2021, 1, 15, 16, 2, 54, 269, DateTimeKind.Local).AddTicks(550) });

            migrationBuilder.UpdateData(
                table: "Lookups",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 1, 15, 16, 2, 54, 269, DateTimeKind.Local).AddTicks(552), new DateTime(2021, 1, 15, 16, 2, 54, 269, DateTimeKind.Local).AddTicks(553) });

            migrationBuilder.UpdateData(
                table: "Lookups",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 1, 15, 16, 2, 54, 269, DateTimeKind.Local).AddTicks(554), new DateTime(2021, 1, 15, 16, 2, 54, 269, DateTimeKind.Local).AddTicks(555) });

            migrationBuilder.UpdateData(
                table: "Lookups",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 1, 15, 16, 2, 54, 269, DateTimeKind.Local).AddTicks(557), new DateTime(2021, 1, 15, 16, 2, 54, 269, DateTimeKind.Local).AddTicks(558) });

            migrationBuilder.UpdateData(
                table: "Lookups",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 1, 15, 16, 2, 54, 269, DateTimeKind.Local).AddTicks(559), new DateTime(2021, 1, 15, 16, 2, 54, 269, DateTimeKind.Local).AddTicks(560) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileExtension",
                table: "Uploads");

            migrationBuilder.DropColumn(
                name: "FileExtension",
                table: "Templates");

            migrationBuilder.UpdateData(
                table: "Link",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 1, 13, 23, 13, 17, 726, DateTimeKind.Local).AddTicks(765), new DateTime(2021, 1, 13, 23, 13, 17, 726, DateTimeKind.Local).AddTicks(797) });

            migrationBuilder.UpdateData(
                table: "Link",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 1, 13, 23, 13, 17, 726, DateTimeKind.Local).AddTicks(853), new DateTime(2021, 1, 13, 23, 13, 17, 726, DateTimeKind.Local).AddTicks(854) });

            migrationBuilder.UpdateData(
                table: "Link",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 1, 13, 23, 13, 17, 726, DateTimeKind.Local).AddTicks(857), new DateTime(2021, 1, 13, 23, 13, 17, 726, DateTimeKind.Local).AddTicks(858) });

            migrationBuilder.UpdateData(
                table: "Link",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 1, 13, 23, 13, 17, 726, DateTimeKind.Local).AddTicks(860), new DateTime(2021, 1, 13, 23, 13, 17, 726, DateTimeKind.Local).AddTicks(861) });

            migrationBuilder.UpdateData(
                table: "Link",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 1, 13, 23, 13, 17, 726, DateTimeKind.Local).AddTicks(863), new DateTime(2021, 1, 13, 23, 13, 17, 726, DateTimeKind.Local).AddTicks(864) });

            migrationBuilder.UpdateData(
                table: "Link",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 1, 13, 23, 13, 17, 726, DateTimeKind.Local).AddTicks(865), new DateTime(2021, 1, 13, 23, 13, 17, 726, DateTimeKind.Local).AddTicks(866) });

            migrationBuilder.UpdateData(
                table: "Link",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 1, 13, 23, 13, 17, 726, DateTimeKind.Local).AddTicks(868), new DateTime(2021, 1, 13, 23, 13, 17, 726, DateTimeKind.Local).AddTicks(869) });

            migrationBuilder.UpdateData(
                table: "Link",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 1, 13, 23, 13, 17, 726, DateTimeKind.Local).AddTicks(871), new DateTime(2021, 1, 13, 23, 13, 17, 726, DateTimeKind.Local).AddTicks(872) });

            migrationBuilder.UpdateData(
                table: "Link",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 1, 13, 23, 13, 17, 726, DateTimeKind.Local).AddTicks(873), new DateTime(2021, 1, 13, 23, 13, 17, 726, DateTimeKind.Local).AddTicks(874) });

            migrationBuilder.UpdateData(
                table: "Link",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 1, 13, 23, 13, 17, 726, DateTimeKind.Local).AddTicks(876), new DateTime(2021, 1, 13, 23, 13, 17, 726, DateTimeKind.Local).AddTicks(877) });

            migrationBuilder.UpdateData(
                table: "Link",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 1, 13, 23, 13, 17, 726, DateTimeKind.Local).AddTicks(879), new DateTime(2021, 1, 13, 23, 13, 17, 726, DateTimeKind.Local).AddTicks(880) });

            migrationBuilder.UpdateData(
                table: "Link",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 1, 13, 23, 13, 17, 726, DateTimeKind.Local).AddTicks(881), new DateTime(2021, 1, 13, 23, 13, 17, 726, DateTimeKind.Local).AddTicks(882) });

            migrationBuilder.UpdateData(
                table: "Link",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 1, 13, 23, 13, 17, 726, DateTimeKind.Local).AddTicks(884), new DateTime(2021, 1, 13, 23, 13, 17, 726, DateTimeKind.Local).AddTicks(885) });

            migrationBuilder.UpdateData(
                table: "Lookups",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 1, 13, 23, 13, 17, 721, DateTimeKind.Local).AddTicks(4174), new DateTime(2021, 1, 13, 23, 13, 17, 722, DateTimeKind.Local).AddTicks(1886) });

            migrationBuilder.UpdateData(
                table: "Lookups",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 1, 13, 23, 13, 17, 722, DateTimeKind.Local).AddTicks(2436), new DateTime(2021, 1, 13, 23, 13, 17, 722, DateTimeKind.Local).AddTicks(2450) });

            migrationBuilder.UpdateData(
                table: "Lookups",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 1, 13, 23, 13, 17, 722, DateTimeKind.Local).AddTicks(2458), new DateTime(2021, 1, 13, 23, 13, 17, 722, DateTimeKind.Local).AddTicks(2460) });

            migrationBuilder.UpdateData(
                table: "Lookups",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 1, 13, 23, 13, 17, 722, DateTimeKind.Local).AddTicks(2461), new DateTime(2021, 1, 13, 23, 13, 17, 722, DateTimeKind.Local).AddTicks(2462) });

            migrationBuilder.UpdateData(
                table: "Lookups",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 1, 13, 23, 13, 17, 722, DateTimeKind.Local).AddTicks(2464), new DateTime(2021, 1, 13, 23, 13, 17, 722, DateTimeKind.Local).AddTicks(2465) });

            migrationBuilder.UpdateData(
                table: "Lookups",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 1, 13, 23, 13, 17, 722, DateTimeKind.Local).AddTicks(2467), new DateTime(2021, 1, 13, 23, 13, 17, 722, DateTimeKind.Local).AddTicks(2468) });

            migrationBuilder.UpdateData(
                table: "Lookups",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 1, 13, 23, 13, 17, 722, DateTimeKind.Local).AddTicks(2469), new DateTime(2021, 1, 13, 23, 13, 17, 722, DateTimeKind.Local).AddTicks(2470) });
        }
    }
}
