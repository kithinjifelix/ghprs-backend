using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GHPRS.Persistence.Migrations
{
    public partial class reorganization : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_stg_community_data_FileUploads_FileUploadsId",
                table: "stg_community_data");

            migrationBuilder.DropForeignKey(
                name: "FK_stg_facility_data_FileUploads_FileUploadsId",
                table: "stg_facility_data");

            migrationBuilder.DropIndex(
                name: "IX_stg_facility_data_FileUploadsId",
                table: "stg_facility_data");

            migrationBuilder.DropIndex(
                name: "IX_stg_community_data_FileUploadsId",
                table: "stg_community_data");

            migrationBuilder.DropColumn(
                name: "FileUploadsId",
                table: "stg_facility_data");

            migrationBuilder.DropColumn(
                name: "FileUploadsId",
                table: "stg_community_data");

            migrationBuilder.RenameColumn(
                name: "vmmc_circ_u15_m",
                table: "stg_facility_data",
                newName: "vmmc_circ.u15.m");

            migrationBuilder.RenameColumn(
                name: "vmmc_circ_o15_m",
                table: "stg_facility_data",
                newName: "vmmc_circ.o15.m");

            migrationBuilder.RenameColumn(
                name: "tx_mmd_u15_m_u3mo",
                table: "stg_facility_data",
                newName: "tx_mmd.u15.m.u3mo");

            migrationBuilder.RenameColumn(
                name: "tx_mmd_u15_m_o6mo",
                table: "stg_facility_data",
                newName: "tx_mmd.u15.m.o6mo");

            migrationBuilder.RenameColumn(
                name: "tx_mmd_u15_m_35mo",
                table: "stg_facility_data",
                newName: "tx_mmd.u15.m.35mo");

            migrationBuilder.RenameColumn(
                name: "tx_mmd_u15_f_u3mo",
                table: "stg_facility_data",
                newName: "tx_mmd.u15.f.u3mo");

            migrationBuilder.RenameColumn(
                name: "tx_mmd_u15_f_o6mo",
                table: "stg_facility_data",
                newName: "tx_mmd.u15.f.o6mo");

            migrationBuilder.RenameColumn(
                name: "tx_mmd_u15_f_35mo",
                table: "stg_facility_data",
                newName: "tx_mmd.u15.f.35mo");

            migrationBuilder.RenameColumn(
                name: "tx_mmd_o15_m_u3mo",
                table: "stg_facility_data",
                newName: "tx_mmd.o15.m.u3mo");

            migrationBuilder.RenameColumn(
                name: "tx_mmd_o15_m_o6mo",
                table: "stg_facility_data",
                newName: "tx_mmd.o15.m.o6mo");

            migrationBuilder.RenameColumn(
                name: "tx_mmd_o15_m_35mo",
                table: "stg_facility_data",
                newName: "tx_mmd.o15.m.35mo");

            migrationBuilder.RenameColumn(
                name: "tx_mmd_o15_f_u3mo",
                table: "stg_facility_data",
                newName: "tx_mmd.o15.f.u3mo");

            migrationBuilder.RenameColumn(
                name: "tx_mmd_o15_f_o6mo",
                table: "stg_facility_data",
                newName: "tx_mmd.o15.f.o6mo");

            migrationBuilder.RenameColumn(
                name: "tx_mmd_o15_f_35mo",
                table: "stg_facility_data",
                newName: "tx_mmd.o15.f.35mo");

            migrationBuilder.RenameColumn(
                name: "tx_curr_u15_m",
                table: "stg_facility_data",
                newName: "tx_curr.u15.m");

            migrationBuilder.RenameColumn(
                name: "tx_curr_u15_f",
                table: "stg_facility_data",
                newName: "tx_curr.u15.f");

            migrationBuilder.RenameColumn(
                name: "tx_curr_o15_m",
                table: "stg_facility_data",
                newName: "tx_curr.o15.m");

            migrationBuilder.RenameColumn(
                name: "tx_curr_o15_f",
                table: "stg_facility_data",
                newName: "tx_curr.o15.f");

            migrationBuilder.RenameColumn(
                name: "prep_new_u15_m",
                table: "stg_facility_data",
                newName: "prep_new.u15.m");

            migrationBuilder.RenameColumn(
                name: "prep_new_u15_f",
                table: "stg_facility_data",
                newName: "prep_new.u15.f");

            migrationBuilder.RenameColumn(
                name: "prep_new_o15_m",
                table: "stg_facility_data",
                newName: "prep_new.o15.m");

            migrationBuilder.RenameColumn(
                name: "prep_new_o15_f",
                table: "stg_facility_data",
                newName: "prep_new.o15.f");

            migrationBuilder.RenameColumn(
                name: "VL_ELIG_A",
                table: "stg_facility_data",
                newName: "VL_ELIG _A ");

            migrationBuilder.RenameColumn(
                name: "Site_id",
                table: "stg_facility_data",
                newName: "Site ID (from DATIM)");

            migrationBuilder.RenameColumn(
                name: "Site_Name",
                table: "stg_facility_data",
                newName: "Site Name");

            migrationBuilder.RenameColumn(
                name: "Priority_Tier",
                table: "stg_facility_data",
                newName: "Priority Tier (1, 2, 3, 4)");

            migrationBuilder.RenameColumn(
                name: "MECHANISM_ID",
                table: "stg_facility_data",
                newName: "MECHANISM ID");

            migrationBuilder.RenameColumn(
                name: "HTS_2_months",
                table: "stg_facility_data",
                newName: "HTS_2 months");

            migrationBuilder.RenameColumn(
                name: "SiteId",
                table: "stg_community_data",
                newName: "Site ID/ward ID (from DATIM)");

            migrationBuilder.AddColumn<string>(
                name: "Report Date",
                table: "stg_facility_data",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UploadBatchGuid",
                table: "stg_facility_data",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "Upload_Batch",
                table: "stg_facility_data",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Report Date",
                table: "stg_community_data",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UploadBatchGuid",
                table: "stg_community_data",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "Upload_Batch",
                table: "stg_community_data",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Report Date",
                table: "stg_facility_data");

            migrationBuilder.DropColumn(
                name: "UploadBatchGuid",
                table: "stg_facility_data");

            migrationBuilder.DropColumn(
                name: "Upload_Batch",
                table: "stg_facility_data");

            migrationBuilder.DropColumn(
                name: "Report Date",
                table: "stg_community_data");

            migrationBuilder.DropColumn(
                name: "UploadBatchGuid",
                table: "stg_community_data");

            migrationBuilder.DropColumn(
                name: "Upload_Batch",
                table: "stg_community_data");

            migrationBuilder.RenameColumn(
                name: "vmmc_circ.u15.m",
                table: "stg_facility_data",
                newName: "vmmc_circ_u15_m");

            migrationBuilder.RenameColumn(
                name: "vmmc_circ.o15.m",
                table: "stg_facility_data",
                newName: "vmmc_circ_o15_m");

            migrationBuilder.RenameColumn(
                name: "tx_mmd.u15.m.u3mo",
                table: "stg_facility_data",
                newName: "tx_mmd_u15_m_u3mo");

            migrationBuilder.RenameColumn(
                name: "tx_mmd.u15.m.o6mo",
                table: "stg_facility_data",
                newName: "tx_mmd_u15_m_o6mo");

            migrationBuilder.RenameColumn(
                name: "tx_mmd.u15.m.35mo",
                table: "stg_facility_data",
                newName: "tx_mmd_u15_m_35mo");

            migrationBuilder.RenameColumn(
                name: "tx_mmd.u15.f.u3mo",
                table: "stg_facility_data",
                newName: "tx_mmd_u15_f_u3mo");

            migrationBuilder.RenameColumn(
                name: "tx_mmd.u15.f.o6mo",
                table: "stg_facility_data",
                newName: "tx_mmd_u15_f_o6mo");

            migrationBuilder.RenameColumn(
                name: "tx_mmd.u15.f.35mo",
                table: "stg_facility_data",
                newName: "tx_mmd_u15_f_35mo");

            migrationBuilder.RenameColumn(
                name: "tx_mmd.o15.m.u3mo",
                table: "stg_facility_data",
                newName: "tx_mmd_o15_m_u3mo");

            migrationBuilder.RenameColumn(
                name: "tx_mmd.o15.m.o6mo",
                table: "stg_facility_data",
                newName: "tx_mmd_o15_m_o6mo");

            migrationBuilder.RenameColumn(
                name: "tx_mmd.o15.m.35mo",
                table: "stg_facility_data",
                newName: "tx_mmd_o15_m_35mo");

            migrationBuilder.RenameColumn(
                name: "tx_mmd.o15.f.u3mo",
                table: "stg_facility_data",
                newName: "tx_mmd_o15_f_u3mo");

            migrationBuilder.RenameColumn(
                name: "tx_mmd.o15.f.o6mo",
                table: "stg_facility_data",
                newName: "tx_mmd_o15_f_o6mo");

            migrationBuilder.RenameColumn(
                name: "tx_mmd.o15.f.35mo",
                table: "stg_facility_data",
                newName: "tx_mmd_o15_f_35mo");

            migrationBuilder.RenameColumn(
                name: "tx_curr.u15.m",
                table: "stg_facility_data",
                newName: "tx_curr_u15_m");

            migrationBuilder.RenameColumn(
                name: "tx_curr.u15.f",
                table: "stg_facility_data",
                newName: "tx_curr_u15_f");

            migrationBuilder.RenameColumn(
                name: "tx_curr.o15.m",
                table: "stg_facility_data",
                newName: "tx_curr_o15_m");

            migrationBuilder.RenameColumn(
                name: "tx_curr.o15.f",
                table: "stg_facility_data",
                newName: "tx_curr_o15_f");

            migrationBuilder.RenameColumn(
                name: "prep_new.u15.m",
                table: "stg_facility_data",
                newName: "prep_new_u15_m");

            migrationBuilder.RenameColumn(
                name: "prep_new.u15.f",
                table: "stg_facility_data",
                newName: "prep_new_u15_f");

            migrationBuilder.RenameColumn(
                name: "prep_new.o15.m",
                table: "stg_facility_data",
                newName: "prep_new_o15_m");

            migrationBuilder.RenameColumn(
                name: "prep_new.o15.f",
                table: "stg_facility_data",
                newName: "prep_new_o15_f");

            migrationBuilder.RenameColumn(
                name: "VL_ELIG _A ",
                table: "stg_facility_data",
                newName: "VL_ELIG_A");

            migrationBuilder.RenameColumn(
                name: "Site Name",
                table: "stg_facility_data",
                newName: "Site_Name");

            migrationBuilder.RenameColumn(
                name: "Site ID (from DATIM)",
                table: "stg_facility_data",
                newName: "Site_id");

            migrationBuilder.RenameColumn(
                name: "Priority Tier (1, 2, 3, 4)",
                table: "stg_facility_data",
                newName: "Priority_Tier");

            migrationBuilder.RenameColumn(
                name: "MECHANISM ID",
                table: "stg_facility_data",
                newName: "MECHANISM_ID");

            migrationBuilder.RenameColumn(
                name: "HTS_2 months",
                table: "stg_facility_data",
                newName: "HTS_2_months");

            migrationBuilder.RenameColumn(
                name: "Site ID/ward ID (from DATIM)",
                table: "stg_community_data",
                newName: "SiteId");

            migrationBuilder.AddColumn<int>(
                name: "FileUploadsId",
                table: "stg_facility_data",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FileUploadsId",
                table: "stg_community_data",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_stg_facility_data_FileUploadsId",
                table: "stg_facility_data",
                column: "FileUploadsId");

            migrationBuilder.CreateIndex(
                name: "IX_stg_community_data_FileUploadsId",
                table: "stg_community_data",
                column: "FileUploadsId");

            migrationBuilder.AddForeignKey(
                name: "FK_stg_community_data_FileUploads_FileUploadsId",
                table: "stg_community_data",
                column: "FileUploadsId",
                principalTable: "FileUploads",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_stg_facility_data_FileUploads_FileUploadsId",
                table: "stg_facility_data",
                column: "FileUploadsId",
                principalTable: "FileUploads",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
