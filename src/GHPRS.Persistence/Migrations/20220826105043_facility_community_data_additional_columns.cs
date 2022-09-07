using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GHPRS.Persistence.Migrations
{
    public partial class facility_community_data_additional_columns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_stg_facility_data",
                table: "stg_facility_data");

            migrationBuilder.DropPrimaryKey(
                name: "PK_stg_community_data",
                table: "stg_community_data");

            migrationBuilder.RenameTable(
                name: "stg_facility_data",
                newName: "StagingFacilityData");

            migrationBuilder.RenameTable(
                name: "stg_community_data",
                newName: "StagingCommunityData");

            migrationBuilder.AddColumn<string>(
                name: "MMS_6_ELIG_A_F",
                table: "StagingFacilityData",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MMS_6_ELIG_A_M",
                table: "StagingFacilityData",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MMS_6_ELIG_P_M",
                table: "StagingFacilityData",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MMS_6__ELIG_P_F",
                table: "StagingFacilityData",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PMTCT_ART",
                table: "StagingFacilityData",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PMTCT_EID",
                table: "StagingFacilityData",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PMTCT_HEI_POS",
                table: "StagingFacilityData",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PMTCT_HEI_POS_ART",
                table: "StagingFacilityData",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PMTCT_STAT_D",
                table: "StagingFacilityData",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PMTCT_STAT_N",
                table: "StagingFacilityData",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TB_ART",
                table: "StagingFacilityData",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TB_STAT_D",
                table: "StagingFacilityData",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TB_STAT_N",
                table: "StagingFacilityData",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TB_STAT_POS",
                table: "StagingFacilityData",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TX_TB_D",
                table: "StagingFacilityData",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TX_TB_N",
                table: "StagingFacilityData",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PrEP Eligible-AGY(15-19)",
                table: "StagingCommunityData",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PrEP Eligible-AGY(20-24)",
                table: "StagingCommunityData",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PrEP Eligible-MSM",
                table: "StagingCommunityData",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PrEP Eligible-PWID",
                table: "StagingCommunityData",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PrEP Eligible-Pregnant& Breastfeeding Women",
                table: "StagingCommunityData",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PrEP Eligible-Serodiscordant Couple",
                table: "StagingCommunityData",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PrEP Eligible-TG",
                table: "StagingCommunityData",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PrEP Eligible_FSW",
                table: "StagingCommunityData",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PrEP Screen-AGY(15-19)",
                table: "StagingCommunityData",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PrEP Screen-MSM",
                table: "StagingCommunityData",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PrEP Screen-PWID",
                table: "StagingCommunityData",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PrEP Screen-Pregnant& Breastfeeding Women",
                table: "StagingCommunityData",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PrEP Screen-Serodiscordant Couple",
                table: "StagingCommunityData",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PrEP Screen-TG",
                table: "StagingCommunityData",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PrEP Screen_FSW",
                table: "StagingCommunityData",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PrEP_CT-AGYW",
                table: "StagingCommunityData",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PrEP_CT-FSW",
                table: "StagingCommunityData",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PrEP_CT-MSM",
                table: "StagingCommunityData",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PrEP_CT-PWID",
                table: "StagingCommunityData",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PrEP_CT-Pregnant& Breastfeeding Women",
                table: "StagingCommunityData",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PrEP_CT-Serodiscordant Couple",
                table: "StagingCommunityData",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PrEP_CT-TG",
                table: "StagingCommunityData",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PrEP_NEW-AGYW(15-19)",
                table: "StagingCommunityData",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PrEP_NEW-AGYW(20-24)",
                table: "StagingCommunityData",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PrEP_NEW-FSW",
                table: "StagingCommunityData",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PrEP_NEW-PWID",
                table: "StagingCommunityData",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PrEP_NEW-Pregnant& Breastfeeding Women",
                table: "StagingCommunityData",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PrEP_NEW-Serodiscordant Couple",
                table: "StagingCommunityData",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PrEP_NEW-TG",
                table: "StagingCommunityData",
                type: "text",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_StagingFacilityData",
                table: "StagingFacilityData",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StagingCommunityData",
                table: "StagingCommunityData",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_StagingFacilityData",
                table: "StagingFacilityData");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StagingCommunityData",
                table: "StagingCommunityData");

            migrationBuilder.DropColumn(
                name: "MMS_6_ELIG_A_F",
                table: "StagingFacilityData");

            migrationBuilder.DropColumn(
                name: "MMS_6_ELIG_A_M",
                table: "StagingFacilityData");

            migrationBuilder.DropColumn(
                name: "MMS_6_ELIG_P_M",
                table: "StagingFacilityData");

            migrationBuilder.DropColumn(
                name: "MMS_6__ELIG_P_F",
                table: "StagingFacilityData");

            migrationBuilder.DropColumn(
                name: "PMTCT_ART",
                table: "StagingFacilityData");

            migrationBuilder.DropColumn(
                name: "PMTCT_EID",
                table: "StagingFacilityData");

            migrationBuilder.DropColumn(
                name: "PMTCT_HEI_POS",
                table: "StagingFacilityData");

            migrationBuilder.DropColumn(
                name: "PMTCT_HEI_POS_ART",
                table: "StagingFacilityData");

            migrationBuilder.DropColumn(
                name: "PMTCT_STAT_D",
                table: "StagingFacilityData");

            migrationBuilder.DropColumn(
                name: "PMTCT_STAT_N",
                table: "StagingFacilityData");

            migrationBuilder.DropColumn(
                name: "TB_ART",
                table: "StagingFacilityData");

            migrationBuilder.DropColumn(
                name: "TB_STAT_D",
                table: "StagingFacilityData");

            migrationBuilder.DropColumn(
                name: "TB_STAT_N",
                table: "StagingFacilityData");

            migrationBuilder.DropColumn(
                name: "TB_STAT_POS",
                table: "StagingFacilityData");

            migrationBuilder.DropColumn(
                name: "TX_TB_D",
                table: "StagingFacilityData");

            migrationBuilder.DropColumn(
                name: "TX_TB_N",
                table: "StagingFacilityData");

            migrationBuilder.DropColumn(
                name: "PrEP Eligible-AGY(15-19)",
                table: "StagingCommunityData");

            migrationBuilder.DropColumn(
                name: "PrEP Eligible-AGY(20-24)",
                table: "StagingCommunityData");

            migrationBuilder.DropColumn(
                name: "PrEP Eligible-MSM",
                table: "StagingCommunityData");

            migrationBuilder.DropColumn(
                name: "PrEP Eligible-PWID",
                table: "StagingCommunityData");

            migrationBuilder.DropColumn(
                name: "PrEP Eligible-Pregnant& Breastfeeding Women",
                table: "StagingCommunityData");

            migrationBuilder.DropColumn(
                name: "PrEP Eligible-Serodiscordant Couple",
                table: "StagingCommunityData");

            migrationBuilder.DropColumn(
                name: "PrEP Eligible-TG",
                table: "StagingCommunityData");

            migrationBuilder.DropColumn(
                name: "PrEP Eligible_FSW",
                table: "StagingCommunityData");

            migrationBuilder.DropColumn(
                name: "PrEP Screen-AGY(15-19)",
                table: "StagingCommunityData");

            migrationBuilder.DropColumn(
                name: "PrEP Screen-MSM",
                table: "StagingCommunityData");

            migrationBuilder.DropColumn(
                name: "PrEP Screen-PWID",
                table: "StagingCommunityData");

            migrationBuilder.DropColumn(
                name: "PrEP Screen-Pregnant& Breastfeeding Women",
                table: "StagingCommunityData");

            migrationBuilder.DropColumn(
                name: "PrEP Screen-Serodiscordant Couple",
                table: "StagingCommunityData");

            migrationBuilder.DropColumn(
                name: "PrEP Screen-TG",
                table: "StagingCommunityData");

            migrationBuilder.DropColumn(
                name: "PrEP Screen_FSW",
                table: "StagingCommunityData");

            migrationBuilder.DropColumn(
                name: "PrEP_CT-AGYW",
                table: "StagingCommunityData");

            migrationBuilder.DropColumn(
                name: "PrEP_CT-FSW",
                table: "StagingCommunityData");

            migrationBuilder.DropColumn(
                name: "PrEP_CT-MSM",
                table: "StagingCommunityData");

            migrationBuilder.DropColumn(
                name: "PrEP_CT-PWID",
                table: "StagingCommunityData");

            migrationBuilder.DropColumn(
                name: "PrEP_CT-Pregnant& Breastfeeding Women",
                table: "StagingCommunityData");

            migrationBuilder.DropColumn(
                name: "PrEP_CT-Serodiscordant Couple",
                table: "StagingCommunityData");

            migrationBuilder.DropColumn(
                name: "PrEP_CT-TG",
                table: "StagingCommunityData");

            migrationBuilder.DropColumn(
                name: "PrEP_NEW-AGYW(15-19)",
                table: "StagingCommunityData");

            migrationBuilder.DropColumn(
                name: "PrEP_NEW-AGYW(20-24)",
                table: "StagingCommunityData");

            migrationBuilder.DropColumn(
                name: "PrEP_NEW-FSW",
                table: "StagingCommunityData");

            migrationBuilder.DropColumn(
                name: "PrEP_NEW-PWID",
                table: "StagingCommunityData");

            migrationBuilder.DropColumn(
                name: "PrEP_NEW-Pregnant& Breastfeeding Women",
                table: "StagingCommunityData");

            migrationBuilder.DropColumn(
                name: "PrEP_NEW-Serodiscordant Couple",
                table: "StagingCommunityData");

            migrationBuilder.DropColumn(
                name: "PrEP_NEW-TG",
                table: "StagingCommunityData");

            migrationBuilder.RenameTable(
                name: "StagingFacilityData",
                newName: "stg_facility_data");

            migrationBuilder.RenameTable(
                name: "StagingCommunityData",
                newName: "stg_community_data");

            migrationBuilder.AddPrimaryKey(
                name: "PK_stg_facility_data",
                table: "stg_facility_data",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_stg_community_data",
                table: "stg_community_data",
                column: "Id");
        }
    }
}
