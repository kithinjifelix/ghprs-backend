using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GHPRS.Persistence.Migrations
{
    public partial class add_remove_columns_facility_data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "prep_new.u15.m",
                table: "StagingFacilityData",
                newName: "SCREEN_P");

            migrationBuilder.RenameColumn(
                name: "prep_new.u15.f",
                table: "StagingFacilityData",
                newName: "SCREEN_HTS_POS_P");

            migrationBuilder.RenameColumn(
                name: "prep_new.o15.m",
                table: "StagingFacilityData",
                newName: "SCREEN_HTS_P");

            migrationBuilder.RenameColumn(
                name: "prep_new.o15.f",
                table: "StagingFacilityData",
                newName: "SCREEN_ELIG_P");

            migrationBuilder.RenameColumn(
                name: "SDI_8_14",
                table: "StagingFacilityData",
                newName: "PrEP_NEW-TG");

            migrationBuilder.RenameColumn(
                name: "SDI_15",
                table: "StagingFacilityData",
                newName: "PrEP_NEW-Serodiscordant Couple");

            migrationBuilder.RenameColumn(
                name: "SDI_0_7",
                table: "StagingFacilityData",
                newName: "PrEP_NEW-Pregnant-Breastfeeding Women");

            migrationBuilder.RenameColumn(
                name: "MMS_6_P",
                table: "StagingFacilityData",
                newName: "PrEP_NEW-PWID");

            migrationBuilder.RenameColumn(
                name: "MMS_6_A",
                table: "StagingFacilityData",
                newName: "PrEP_NEW-MSM");

            migrationBuilder.RenameColumn(
                name: "MMS_3",
                table: "StagingFacilityData",
                newName: "PrEP_NEW-FSW");

            migrationBuilder.RenameColumn(
                name: "MMS_2",
                table: "StagingFacilityData",
                newName: "PrEP_NEW-AGYW(20-24)");

            migrationBuilder.RenameColumn(
                name: "MMS_1",
                table: "StagingFacilityData",
                newName: "PrEP_NEW-AGYW(15-19)");

            migrationBuilder.AddColumn<string>(
                name: "PrEP Eligible-AGY(15-19)",
                table: "StagingFacilityData",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PrEP Eligible-AGY(20-24)",
                table: "StagingFacilityData",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PrEP Eligible-MSM",
                table: "StagingFacilityData",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PrEP Eligible-PWID",
                table: "StagingFacilityData",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PrEP Eligible-Pregnant& Breastfeeding Women",
                table: "StagingFacilityData",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PrEP Eligible-Serodiscordant Couple",
                table: "StagingFacilityData",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PrEP Eligible-TG",
                table: "StagingFacilityData",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PrEP Eligible_FSW",
                table: "StagingFacilityData",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PrEP Screen-AGY(15-19)",
                table: "StagingFacilityData",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PrEP Screen-AGY(20-24)",
                table: "StagingFacilityData",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PrEP Screen-MSM",
                table: "StagingFacilityData",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PrEP Screen-PWID",
                table: "StagingFacilityData",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PrEP Screen-Pregnant& Breastfeeding Women",
                table: "StagingFacilityData",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PrEP Screen-Serodiscordant Couple",
                table: "StagingFacilityData",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PrEP Screen-TG",
                table: "StagingFacilityData",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PrEP Screen_FSW",
                table: "StagingFacilityData",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PrEP_CT-AGYW",
                table: "StagingFacilityData",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PrEP_CT-FSW",
                table: "StagingFacilityData",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PrEP_CT-MSM",
                table: "StagingFacilityData",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PrEP_CT-PWID",
                table: "StagingFacilityData",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PrEP_CT-Pregnant-Breastfeeding Women",
                table: "StagingFacilityData",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PrEP_CT-Serodiscordant Couple ",
                table: "StagingFacilityData",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PrEP_CT-TG",
                table: "StagingFacilityData",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrEP Eligible-AGY(15-19)",
                table: "StagingFacilityData");

            migrationBuilder.DropColumn(
                name: "PrEP Eligible-AGY(20-24)",
                table: "StagingFacilityData");

            migrationBuilder.DropColumn(
                name: "PrEP Eligible-MSM",
                table: "StagingFacilityData");

            migrationBuilder.DropColumn(
                name: "PrEP Eligible-PWID",
                table: "StagingFacilityData");

            migrationBuilder.DropColumn(
                name: "PrEP Eligible-Pregnant& Breastfeeding Women",
                table: "StagingFacilityData");

            migrationBuilder.DropColumn(
                name: "PrEP Eligible-Serodiscordant Couple",
                table: "StagingFacilityData");

            migrationBuilder.DropColumn(
                name: "PrEP Eligible-TG",
                table: "StagingFacilityData");

            migrationBuilder.DropColumn(
                name: "PrEP Eligible_FSW",
                table: "StagingFacilityData");

            migrationBuilder.DropColumn(
                name: "PrEP Screen-AGY(15-19)",
                table: "StagingFacilityData");

            migrationBuilder.DropColumn(
                name: "PrEP Screen-AGY(20-24)",
                table: "StagingFacilityData");

            migrationBuilder.DropColumn(
                name: "PrEP Screen-MSM",
                table: "StagingFacilityData");

            migrationBuilder.DropColumn(
                name: "PrEP Screen-PWID",
                table: "StagingFacilityData");

            migrationBuilder.DropColumn(
                name: "PrEP Screen-Pregnant& Breastfeeding Women",
                table: "StagingFacilityData");

            migrationBuilder.DropColumn(
                name: "PrEP Screen-Serodiscordant Couple",
                table: "StagingFacilityData");

            migrationBuilder.DropColumn(
                name: "PrEP Screen-TG",
                table: "StagingFacilityData");

            migrationBuilder.DropColumn(
                name: "PrEP Screen_FSW",
                table: "StagingFacilityData");

            migrationBuilder.DropColumn(
                name: "PrEP_CT-AGYW",
                table: "StagingFacilityData");

            migrationBuilder.DropColumn(
                name: "PrEP_CT-FSW",
                table: "StagingFacilityData");

            migrationBuilder.DropColumn(
                name: "PrEP_CT-MSM",
                table: "StagingFacilityData");

            migrationBuilder.DropColumn(
                name: "PrEP_CT-PWID",
                table: "StagingFacilityData");

            migrationBuilder.DropColumn(
                name: "PrEP_CT-Pregnant-Breastfeeding Women",
                table: "StagingFacilityData");

            migrationBuilder.DropColumn(
                name: "PrEP_CT-Serodiscordant Couple ",
                table: "StagingFacilityData");

            migrationBuilder.DropColumn(
                name: "PrEP_CT-TG",
                table: "StagingFacilityData");

            migrationBuilder.RenameColumn(
                name: "SCREEN_P",
                table: "StagingFacilityData",
                newName: "prep_new.u15.m");

            migrationBuilder.RenameColumn(
                name: "SCREEN_HTS_POS_P",
                table: "StagingFacilityData",
                newName: "prep_new.u15.f");

            migrationBuilder.RenameColumn(
                name: "SCREEN_HTS_P",
                table: "StagingFacilityData",
                newName: "prep_new.o15.m");

            migrationBuilder.RenameColumn(
                name: "SCREEN_ELIG_P",
                table: "StagingFacilityData",
                newName: "prep_new.o15.f");

            migrationBuilder.RenameColumn(
                name: "PrEP_NEW-TG",
                table: "StagingFacilityData",
                newName: "SDI_8_14");

            migrationBuilder.RenameColumn(
                name: "PrEP_NEW-Serodiscordant Couple",
                table: "StagingFacilityData",
                newName: "SDI_15");

            migrationBuilder.RenameColumn(
                name: "PrEP_NEW-Pregnant-Breastfeeding Women",
                table: "StagingFacilityData",
                newName: "SDI_0_7");

            migrationBuilder.RenameColumn(
                name: "PrEP_NEW-PWID",
                table: "StagingFacilityData",
                newName: "MMS_6_P");

            migrationBuilder.RenameColumn(
                name: "PrEP_NEW-MSM",
                table: "StagingFacilityData",
                newName: "MMS_6_A");

            migrationBuilder.RenameColumn(
                name: "PrEP_NEW-FSW",
                table: "StagingFacilityData",
                newName: "MMS_3");

            migrationBuilder.RenameColumn(
                name: "PrEP_NEW-AGYW(20-24)",
                table: "StagingFacilityData",
                newName: "MMS_2");

            migrationBuilder.RenameColumn(
                name: "PrEP_NEW-AGYW(15-19)",
                table: "StagingFacilityData",
                newName: "MMS_1");
        }
    }
}
