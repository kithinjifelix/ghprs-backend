using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GHPRS.Persistence.Migrations
{
    public partial class update_tb_community_facility_data_columns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Site ID (from DATIM)",
                table: "StagingFacilityData",
                newName: "Site_ID");

            migrationBuilder.RenameColumn(
                name: "Priority Tier (1, 2, 3, 4)",
                table: "StagingFacilityData",
                newName: "Priority_Tier");

            migrationBuilder.RenameColumn(
                name: "PrEP_NEW-TG",
                table: "StagingFacilityData",
                newName: "PrEP_NEW_TG");

            migrationBuilder.RenameColumn(
                name: "PrEP_NEW-Serodiscordant Couple",
                table: "StagingFacilityData",
                newName: "PrEP_NEW_Serodiscordant Couple");

            migrationBuilder.RenameColumn(
                name: "PrEP_NEW-Pregnant& Breastfeeding Women",
                table: "StagingFacilityData",
                newName: "PrEP_NEW_Pregnant_Breastfeeding Women");

            migrationBuilder.RenameColumn(
                name: "PrEP_NEW-PWID",
                table: "StagingFacilityData",
                newName: "PrEP_NEW_PWID");

            migrationBuilder.RenameColumn(
                name: "PrEP_NEW-MSM",
                table: "StagingFacilityData",
                newName: "PrEP_NEW_MSM");

            migrationBuilder.RenameColumn(
                name: "PrEP_NEW-FSW",
                table: "StagingFacilityData",
                newName: "PrEP_NEW_FSW");

            migrationBuilder.RenameColumn(
                name: "PrEP_NEW-AGYW(20-24)",
                table: "StagingFacilityData",
                newName: "PrEP_NEW_AGYW(20-24)");

            migrationBuilder.RenameColumn(
                name: "PrEP_NEW-AGYW(15-19)",
                table: "StagingFacilityData",
                newName: "PrEP_NEW_AGYW(15-19)");

            migrationBuilder.RenameColumn(
                name: "PrEP_CT-TG",
                table: "StagingFacilityData",
                newName: "PrEP_CT_TG");

            migrationBuilder.RenameColumn(
                name: "PrEP_CT-Serodiscordant Couple",
                table: "StagingFacilityData",
                newName: "PrEP_CT_Serodiscordant Couple");

            migrationBuilder.RenameColumn(
                name: "PrEP_CT-Pregnant& Breastfeeding Women",
                table: "StagingFacilityData",
                newName: "PrEP_CT_Pregnant_Breastfeeding Women");

            migrationBuilder.RenameColumn(
                name: "PrEP_CT-PWID",
                table: "StagingFacilityData",
                newName: "PrEP_CT_PWID");

            migrationBuilder.RenameColumn(
                name: "PrEP_CT-MSM",
                table: "StagingFacilityData",
                newName: "PrEP_CT_MSM");

            migrationBuilder.RenameColumn(
                name: "PrEP_CT-FSW",
                table: "StagingFacilityData",
                newName: "PrEP_CT_FSW");

            migrationBuilder.RenameColumn(
                name: "PrEP_CT-AGYW",
                table: "StagingFacilityData",
                newName: "PrEP_CT_AGYW");

            migrationBuilder.RenameColumn(
                name: "PrEP Screen_FSW",
                table: "StagingFacilityData",
                newName: "PrEP_Screen_FSW");

            migrationBuilder.RenameColumn(
                name: "PrEP Screen-TG",
                table: "StagingFacilityData",
                newName: "PrEP_Screen_TG");

            migrationBuilder.RenameColumn(
                name: "PrEP Screen-Serodiscordant Couple",
                table: "StagingFacilityData",
                newName: "PrEP_Screen_Serodiscordant Couple");

            migrationBuilder.RenameColumn(
                name: "PrEP Screen-Pregnant& Breastfeeding Women",
                table: "StagingFacilityData",
                newName: "PrEP_Screen_Pregnant_Breastfeeding Women");

            migrationBuilder.RenameColumn(
                name: "PrEP Screen-PWID",
                table: "StagingFacilityData",
                newName: "PrEP_Screen_PWID");

            migrationBuilder.RenameColumn(
                name: "PrEP Screen-MSM",
                table: "StagingFacilityData",
                newName: "PrEP_Screen_MSM");

            migrationBuilder.RenameColumn(
                name: "PrEP Screen-AGY(20-24)",
                table: "StagingFacilityData",
                newName: "PrEP_Screen_AGY(20-24)");

            migrationBuilder.RenameColumn(
                name: "PrEP Screen-AGY(15-19)",
                table: "StagingFacilityData",
                newName: "PrEP_Screen_AGY(15-19)");

            migrationBuilder.RenameColumn(
                name: "PrEP Eligible_FSW",
                table: "StagingFacilityData",
                newName: "PrEP_Eligible_FSW");

            migrationBuilder.RenameColumn(
                name: "PrEP Eligible-TG",
                table: "StagingFacilityData",
                newName: "PrEP_Eligible_TG");

            migrationBuilder.RenameColumn(
                name: "PrEP Eligible-Serodiscordant Couple",
                table: "StagingFacilityData",
                newName: "PrEP_Eligible_Serodiscordant Couple");

            migrationBuilder.RenameColumn(
                name: "PrEP Eligible-Pregnant& Breastfeeding Women",
                table: "StagingFacilityData",
                newName: "PrEP_Eligible_Pregnant_Breastfeeding Women");

            migrationBuilder.RenameColumn(
                name: "PrEP Eligible-PWID",
                table: "StagingFacilityData",
                newName: "PrEP_Eligible_PWID");

            migrationBuilder.RenameColumn(
                name: "PrEP Eligible-MSM",
                table: "StagingFacilityData",
                newName: "PrEP_Eligible_MSM");

            migrationBuilder.RenameColumn(
                name: "PrEP Eligible-AGY(20-24)",
                table: "StagingFacilityData",
                newName: "PrEP_Eligible_AGY(20-24)");

            migrationBuilder.RenameColumn(
                name: "PrEP Eligible-AGY(15-19)",
                table: "StagingFacilityData",
                newName: "PrEP_Eligible_AGY(15-19)");

            migrationBuilder.RenameColumn(
                name: "Site ID/ward ID (from DATIM)",
                table: "StagingCommunityData",
                newName: "Site_ID");

            migrationBuilder.RenameColumn(
                name: "PrEP_NEW-TG",
                table: "StagingCommunityData",
                newName: "PrEP_NEW_TG");

            migrationBuilder.RenameColumn(
                name: "PrEP_NEW-Serodiscordant Couple",
                table: "StagingCommunityData",
                newName: "PrEP_NEW_Serodiscordant Couple");

            migrationBuilder.RenameColumn(
                name: "PrEP_NEW-Pregnant& Breastfeeding Women",
                table: "StagingCommunityData",
                newName: "PrEP_NEW_Pregnant_Breastfeeding Women");

            migrationBuilder.RenameColumn(
                name: "PrEP_NEW-PWID",
                table: "StagingCommunityData",
                newName: "PrEP_NEW_PWID");

            migrationBuilder.RenameColumn(
                name: "PrEP_NEW-MSM",
                table: "StagingCommunityData",
                newName: "PrEP_NEW_MSM");

            migrationBuilder.RenameColumn(
                name: "PrEP_NEW-FSW",
                table: "StagingCommunityData",
                newName: "PrEP_NEW_FSW");

            migrationBuilder.RenameColumn(
                name: "PrEP_NEW-AGYW(20-24)",
                table: "StagingCommunityData",
                newName: "PrEP_NEW_AGYW(20-24)");

            migrationBuilder.RenameColumn(
                name: "PrEP_NEW-AGYW(15-19)",
                table: "StagingCommunityData",
                newName: "PrEP_NEW_AGYW(15-19)");

            migrationBuilder.RenameColumn(
                name: "PrEP_CT-TG",
                table: "StagingCommunityData",
                newName: "PrEP_CT_TG");

            migrationBuilder.RenameColumn(
                name: "PrEP_CT-Serodiscordant Couple",
                table: "StagingCommunityData",
                newName: "PrEP_CT_Serodiscordant Couple");

            migrationBuilder.RenameColumn(
                name: "PrEP_CT-Pregnant& Breastfeeding Women",
                table: "StagingCommunityData",
                newName: "PrEP_CT_Pregnant_Breastfeeding Women");

            migrationBuilder.RenameColumn(
                name: "PrEP_CT-PWID",
                table: "StagingCommunityData",
                newName: "PrEP_CT_PWID");

            migrationBuilder.RenameColumn(
                name: "PrEP_CT-MSM",
                table: "StagingCommunityData",
                newName: "PrEP_CT_MSM");

            migrationBuilder.RenameColumn(
                name: "PrEP_CT-FSW",
                table: "StagingCommunityData",
                newName: "PrEP_CT_FSW");

            migrationBuilder.RenameColumn(
                name: "PrEP_CT-AGYW",
                table: "StagingCommunityData",
                newName: "PrEP_CT_AGYW");

            migrationBuilder.RenameColumn(
                name: "PrEP Screen_FSW",
                table: "StagingCommunityData",
                newName: "PrEP_Screen_FSW");

            migrationBuilder.RenameColumn(
                name: "PrEP Screen-TG",
                table: "StagingCommunityData",
                newName: "PrEP_Screen_TG");

            migrationBuilder.RenameColumn(
                name: "PrEP Screen-Serodiscordant Couple",
                table: "StagingCommunityData",
                newName: "PrEP_Screen_Serodiscordant Couple");

            migrationBuilder.RenameColumn(
                name: "PrEP Screen-Pregnant& Breastfeeding Women",
                table: "StagingCommunityData",
                newName: "PrEP_Screen_Pregnant_Breastfeeding Women");

            migrationBuilder.RenameColumn(
                name: "PrEP Screen-PWID",
                table: "StagingCommunityData",
                newName: "PrEP_Screen_PWID");

            migrationBuilder.RenameColumn(
                name: "PrEP Screen-MSM",
                table: "StagingCommunityData",
                newName: "PrEP_Screen_MSM");

            migrationBuilder.RenameColumn(
                name: "PrEP Screen-AGY(20-24)",
                table: "StagingCommunityData",
                newName: "PrEP_Screen_AGY(20-24)");

            migrationBuilder.RenameColumn(
                name: "PrEP Screen-AGY(15-19)",
                table: "StagingCommunityData",
                newName: "PrEP_Screen_AGY(15-19)");

            migrationBuilder.RenameColumn(
                name: "PrEP Eligible_FSW",
                table: "StagingCommunityData",
                newName: "PrEP_Eligible_FSW");

            migrationBuilder.RenameColumn(
                name: "PrEP Eligible-TG",
                table: "StagingCommunityData",
                newName: "PrEP_Eligible_TG");

            migrationBuilder.RenameColumn(
                name: "PrEP Eligible-Serodiscordant Couple",
                table: "StagingCommunityData",
                newName: "PrEP_Eligible_Serodiscordant Couple");

            migrationBuilder.RenameColumn(
                name: "PrEP Eligible-Pregnant& Breastfeeding Women",
                table: "StagingCommunityData",
                newName: "PrEP_Eligible_Pregnant_Breastfeeding Women");

            migrationBuilder.RenameColumn(
                name: "PrEP Eligible-PWID",
                table: "StagingCommunityData",
                newName: "PrEP_Eligible_PWID");

            migrationBuilder.RenameColumn(
                name: "PrEP Eligible-MSM",
                table: "StagingCommunityData",
                newName: "PrEP_Eligible_MSM");

            migrationBuilder.RenameColumn(
                name: "PrEP Eligible-AGY(20-24)",
                table: "StagingCommunityData",
                newName: "PrEP_Eligible_AGY(20-24)");

            migrationBuilder.RenameColumn(
                name: "PrEP Eligible-AGY(15-19)",
                table: "StagingCommunityData",
                newName: "PrEP_Eligible_AGY(15-19)");

            migrationBuilder.AddColumn<string>(
                name: "MECHANISM ID",
                table: "StagingCommunityData",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Priority_Tier",
                table: "StagingCommunityData",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Site Name",
                table: "StagingCommunityData",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MECHANISM ID",
                table: "StagingCommunityData");

            migrationBuilder.DropColumn(
                name: "Priority_Tier",
                table: "StagingCommunityData");

            migrationBuilder.DropColumn(
                name: "Site Name",
                table: "StagingCommunityData");

            migrationBuilder.RenameColumn(
                name: "Site_ID",
                table: "StagingFacilityData",
                newName: "Site ID (from DATIM)");

            migrationBuilder.RenameColumn(
                name: "Priority_Tier",
                table: "StagingFacilityData",
                newName: "Priority Tier (1, 2, 3, 4)");

            migrationBuilder.RenameColumn(
                name: "PrEP_Screen_TG",
                table: "StagingFacilityData",
                newName: "PrEP Screen-TG");

            migrationBuilder.RenameColumn(
                name: "PrEP_Screen_Serodiscordant Couple",
                table: "StagingFacilityData",
                newName: "PrEP Screen-Serodiscordant Couple");

            migrationBuilder.RenameColumn(
                name: "PrEP_Screen_Pregnant_Breastfeeding Women",
                table: "StagingFacilityData",
                newName: "PrEP Screen-Pregnant& Breastfeeding Women");

            migrationBuilder.RenameColumn(
                name: "PrEP_Screen_PWID",
                table: "StagingFacilityData",
                newName: "PrEP Screen-PWID");

            migrationBuilder.RenameColumn(
                name: "PrEP_Screen_MSM",
                table: "StagingFacilityData",
                newName: "PrEP Screen-MSM");

            migrationBuilder.RenameColumn(
                name: "PrEP_Screen_FSW",
                table: "StagingFacilityData",
                newName: "PrEP Screen_FSW");

            migrationBuilder.RenameColumn(
                name: "PrEP_Screen_AGY(20-24)",
                table: "StagingFacilityData",
                newName: "PrEP Screen-AGY(20-24)");

            migrationBuilder.RenameColumn(
                name: "PrEP_Screen_AGY(15-19)",
                table: "StagingFacilityData",
                newName: "PrEP Screen-AGY(15-19)");

            migrationBuilder.RenameColumn(
                name: "PrEP_NEW_TG",
                table: "StagingFacilityData",
                newName: "PrEP_NEW-TG");

            migrationBuilder.RenameColumn(
                name: "PrEP_NEW_Serodiscordant Couple",
                table: "StagingFacilityData",
                newName: "PrEP_NEW-Serodiscordant Couple");

            migrationBuilder.RenameColumn(
                name: "PrEP_NEW_Pregnant_Breastfeeding Women",
                table: "StagingFacilityData",
                newName: "PrEP_NEW-Pregnant& Breastfeeding Women");

            migrationBuilder.RenameColumn(
                name: "PrEP_NEW_PWID",
                table: "StagingFacilityData",
                newName: "PrEP_NEW-PWID");

            migrationBuilder.RenameColumn(
                name: "PrEP_NEW_MSM",
                table: "StagingFacilityData",
                newName: "PrEP_NEW-MSM");

            migrationBuilder.RenameColumn(
                name: "PrEP_NEW_FSW",
                table: "StagingFacilityData",
                newName: "PrEP_NEW-FSW");

            migrationBuilder.RenameColumn(
                name: "PrEP_NEW_AGYW(20-24)",
                table: "StagingFacilityData",
                newName: "PrEP_NEW-AGYW(20-24)");

            migrationBuilder.RenameColumn(
                name: "PrEP_NEW_AGYW(15-19)",
                table: "StagingFacilityData",
                newName: "PrEP_NEW-AGYW(15-19)");

            migrationBuilder.RenameColumn(
                name: "PrEP_Eligible_TG",
                table: "StagingFacilityData",
                newName: "PrEP Eligible-TG");

            migrationBuilder.RenameColumn(
                name: "PrEP_Eligible_Serodiscordant Couple",
                table: "StagingFacilityData",
                newName: "PrEP Eligible-Serodiscordant Couple");

            migrationBuilder.RenameColumn(
                name: "PrEP_Eligible_Pregnant_Breastfeeding Women",
                table: "StagingFacilityData",
                newName: "PrEP Eligible-Pregnant& Breastfeeding Women");

            migrationBuilder.RenameColumn(
                name: "PrEP_Eligible_PWID",
                table: "StagingFacilityData",
                newName: "PrEP Eligible-PWID");

            migrationBuilder.RenameColumn(
                name: "PrEP_Eligible_MSM",
                table: "StagingFacilityData",
                newName: "PrEP Eligible-MSM");

            migrationBuilder.RenameColumn(
                name: "PrEP_Eligible_FSW",
                table: "StagingFacilityData",
                newName: "PrEP Eligible_FSW");

            migrationBuilder.RenameColumn(
                name: "PrEP_Eligible_AGY(20-24)",
                table: "StagingFacilityData",
                newName: "PrEP Eligible-AGY(20-24)");

            migrationBuilder.RenameColumn(
                name: "PrEP_Eligible_AGY(15-19)",
                table: "StagingFacilityData",
                newName: "PrEP Eligible-AGY(15-19)");

            migrationBuilder.RenameColumn(
                name: "PrEP_CT_TG",
                table: "StagingFacilityData",
                newName: "PrEP_CT-TG");

            migrationBuilder.RenameColumn(
                name: "PrEP_CT_Serodiscordant Couple",
                table: "StagingFacilityData",
                newName: "PrEP_CT-Serodiscordant Couple");

            migrationBuilder.RenameColumn(
                name: "PrEP_CT_Pregnant_Breastfeeding Women",
                table: "StagingFacilityData",
                newName: "PrEP_CT-Pregnant& Breastfeeding Women");

            migrationBuilder.RenameColumn(
                name: "PrEP_CT_PWID",
                table: "StagingFacilityData",
                newName: "PrEP_CT-PWID");

            migrationBuilder.RenameColumn(
                name: "PrEP_CT_MSM",
                table: "StagingFacilityData",
                newName: "PrEP_CT-MSM");

            migrationBuilder.RenameColumn(
                name: "PrEP_CT_FSW",
                table: "StagingFacilityData",
                newName: "PrEP_CT-FSW");

            migrationBuilder.RenameColumn(
                name: "PrEP_CT_AGYW",
                table: "StagingFacilityData",
                newName: "PrEP_CT-AGYW");

            migrationBuilder.RenameColumn(
                name: "Site_ID",
                table: "StagingCommunityData",
                newName: "Site ID/ward ID (from DATIM)");

            migrationBuilder.RenameColumn(
                name: "PrEP_Screen_TG",
                table: "StagingCommunityData",
                newName: "PrEP Screen-TG");

            migrationBuilder.RenameColumn(
                name: "PrEP_Screen_Serodiscordant Couple",
                table: "StagingCommunityData",
                newName: "PrEP Screen-Serodiscordant Couple");

            migrationBuilder.RenameColumn(
                name: "PrEP_Screen_Pregnant_Breastfeeding Women",
                table: "StagingCommunityData",
                newName: "PrEP Screen-Pregnant& Breastfeeding Women");

            migrationBuilder.RenameColumn(
                name: "PrEP_Screen_PWID",
                table: "StagingCommunityData",
                newName: "PrEP Screen-PWID");

            migrationBuilder.RenameColumn(
                name: "PrEP_Screen_MSM",
                table: "StagingCommunityData",
                newName: "PrEP Screen-MSM");

            migrationBuilder.RenameColumn(
                name: "PrEP_Screen_FSW",
                table: "StagingCommunityData",
                newName: "PrEP Screen_FSW");

            migrationBuilder.RenameColumn(
                name: "PrEP_Screen_AGY(20-24)",
                table: "StagingCommunityData",
                newName: "PrEP Screen-AGY(20-24)");

            migrationBuilder.RenameColumn(
                name: "PrEP_Screen_AGY(15-19)",
                table: "StagingCommunityData",
                newName: "PrEP Screen-AGY(15-19)");

            migrationBuilder.RenameColumn(
                name: "PrEP_NEW_TG",
                table: "StagingCommunityData",
                newName: "PrEP_NEW-TG");

            migrationBuilder.RenameColumn(
                name: "PrEP_NEW_Serodiscordant Couple",
                table: "StagingCommunityData",
                newName: "PrEP_NEW-Serodiscordant Couple");

            migrationBuilder.RenameColumn(
                name: "PrEP_NEW_Pregnant_Breastfeeding Women",
                table: "StagingCommunityData",
                newName: "PrEP_NEW-Pregnant& Breastfeeding Women");

            migrationBuilder.RenameColumn(
                name: "PrEP_NEW_PWID",
                table: "StagingCommunityData",
                newName: "PrEP_NEW-PWID");

            migrationBuilder.RenameColumn(
                name: "PrEP_NEW_MSM",
                table: "StagingCommunityData",
                newName: "PrEP_NEW-MSM");

            migrationBuilder.RenameColumn(
                name: "PrEP_NEW_FSW",
                table: "StagingCommunityData",
                newName: "PrEP_NEW-FSW");

            migrationBuilder.RenameColumn(
                name: "PrEP_NEW_AGYW(20-24)",
                table: "StagingCommunityData",
                newName: "PrEP_NEW-AGYW(20-24)");

            migrationBuilder.RenameColumn(
                name: "PrEP_NEW_AGYW(15-19)",
                table: "StagingCommunityData",
                newName: "PrEP_NEW-AGYW(15-19)");

            migrationBuilder.RenameColumn(
                name: "PrEP_Eligible_TG",
                table: "StagingCommunityData",
                newName: "PrEP Eligible-TG");

            migrationBuilder.RenameColumn(
                name: "PrEP_Eligible_Serodiscordant Couple",
                table: "StagingCommunityData",
                newName: "PrEP Eligible-Serodiscordant Couple");

            migrationBuilder.RenameColumn(
                name: "PrEP_Eligible_Pregnant_Breastfeeding Women",
                table: "StagingCommunityData",
                newName: "PrEP Eligible-Pregnant& Breastfeeding Women");

            migrationBuilder.RenameColumn(
                name: "PrEP_Eligible_PWID",
                table: "StagingCommunityData",
                newName: "PrEP Eligible-PWID");

            migrationBuilder.RenameColumn(
                name: "PrEP_Eligible_MSM",
                table: "StagingCommunityData",
                newName: "PrEP Eligible-MSM");

            migrationBuilder.RenameColumn(
                name: "PrEP_Eligible_FSW",
                table: "StagingCommunityData",
                newName: "PrEP Eligible_FSW");

            migrationBuilder.RenameColumn(
                name: "PrEP_Eligible_AGY(20-24)",
                table: "StagingCommunityData",
                newName: "PrEP Eligible-AGY(20-24)");

            migrationBuilder.RenameColumn(
                name: "PrEP_Eligible_AGY(15-19)",
                table: "StagingCommunityData",
                newName: "PrEP Eligible-AGY(15-19)");

            migrationBuilder.RenameColumn(
                name: "PrEP_CT_TG",
                table: "StagingCommunityData",
                newName: "PrEP_CT-TG");

            migrationBuilder.RenameColumn(
                name: "PrEP_CT_Serodiscordant Couple",
                table: "StagingCommunityData",
                newName: "PrEP_CT-Serodiscordant Couple");

            migrationBuilder.RenameColumn(
                name: "PrEP_CT_Pregnant_Breastfeeding Women",
                table: "StagingCommunityData",
                newName: "PrEP_CT-Pregnant& Breastfeeding Women");

            migrationBuilder.RenameColumn(
                name: "PrEP_CT_PWID",
                table: "StagingCommunityData",
                newName: "PrEP_CT-PWID");

            migrationBuilder.RenameColumn(
                name: "PrEP_CT_MSM",
                table: "StagingCommunityData",
                newName: "PrEP_CT-MSM");

            migrationBuilder.RenameColumn(
                name: "PrEP_CT_FSW",
                table: "StagingCommunityData",
                newName: "PrEP_CT-FSW");

            migrationBuilder.RenameColumn(
                name: "PrEP_CT_AGYW",
                table: "StagingCommunityData",
                newName: "PrEP_CT-AGYW");
        }
    }
}
