using System;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace GHPRS.Core.Entities;

[Table("StagingFacilityData")]
public class FacilityData : Entity
{
    [Column("Priority Tier (1, 2, 3, 4)")]
    public string Priority_Tier { get; set; }
    [Column("Month")]
    public string Month { get; set; }
    [Column("Year")]
    public string Year { get; set; }
    [Column("MECHANISM ID")]
    public string MECHANISM_ID { get; set; }
    [Column("Partner")]
    public string Partner { get; set; }
    [Column("Agency")]
    public string Agency { get; set; }
    [Column("Region")]
    public string Region { get; set; }
    [Column("District")]
    public string District { get; set; }
    [Column("Council")]
    public string Council { get; set; }
    [Column("Ward")]
    public string Ward { get; set; }
    [Column("Site Name")]
    public string Site_Name { get; set; }
    [Column("Site ID (from DATIM)")]
    public string Site_id { get; set; }
    [Column("CLIENT_A_TX_NEW")]
    public string CLIENT_A_TX_NEW { get; set; }
    [Column("CLIENT_A_TX_CURR")]
    public string CLIENT_A_TX_CURR { get; set; }
    [Column("CONTACT_A")]
    public string CONTACT_A { get; set; }
    [Column("IPV_HX_SCREEN")]
    public string IPV_HX_SCREEN { get; set; }
    [Column("KNOWN_POS_A")]
    public string KNOWN_POS_A { get; set; }
    [Column("NEG_A")]
    public string NEG_A { get; set; }
    [Column("POS_A")]
    public string POS_A { get; set; }
    [Column("CONTACT_PEDS")]
    public string CONTACT_PEDS { get; set; }
    [Column("KNOWN_POS_PEDS")]
    public string KNOWN_POS_PEDS { get; set; }
    [Column("NEG_PEDS")]
    public string NEG_PEDS { get; set; }
    [Column("POS_PEDS")]
    public string POS_PEDS { get; set; }
    [Column("OPD_P")]
    public string OPD_P { get; set; }
    [Column("OPD_A")]
    public string OPD_A { get; set; }
    [Column("SCREEN_A")]
    public string SCREEN_A { get; set; }
    [Column("SCREEN_ELIG_A")]
    public string SCREEN_ELIG_A { get; set; }
    [Column("SCREEN_HTS_A")]
    public string SCREEN_HTS_A { get; set; }
    [Column("SCREEN_HTS_POS_A")]
    public string SCREEN_HTS_POS_A { get; set; }
    [Column("LCM_A")]
    public string LCM_A { get; set; }
    [Column("REFILL")]
    public string REFILL { get; set; }
    [Column("SDI_0_7")]
    public string SDI_0_7 { get; set; }
    [Column("SDI_8_14")]
    public string SDI_8_14 { get; set; }
    [Column("SDI_15")]
    public string SDI_15 { get; set; }
    [Column("TX_PREV")]
    public string TX_PREV { get; set; }
    [Column("TX_CURR")]
    public string TX_CURR { get; set; }
    [Column("XFER_IN")]
    public string XFER_IN { get; set; }
    [Column("XFER_OUT")]
    public string XFER_OUT { get; set; }
    [Column("XFER_DEATH")]
    public string XFER_DEATH { get; set; }
    [Column("MMS_1")]
    public string MMS_1 { get; set; }
    [Column("MMS_2")]
    public string MMS_2 { get; set; }
    [Column("MMS_3")]
    public string MMS_3 { get; set; }
    [Column("TB_PREV_D")]
    public string TB_PREV_D { get; set; }
    [Column("TB_PREV_N")]
    public string TB_PREV_N { get; set; }
    [Column("TB_PREV_NEW")]
    public string TB_PREV_NEW { get; set; }
    [Column("VL_ELIG_P")]
    public string VL_ELIG_P { get; set; }
    [Column("VL_D_P")]
    public string VL_D_P { get; set; }
    [Column("VL_N_P")]
    public string VL_N_P { get; set; }
    [Column("VL_ELIG _A ")]
    public string VL_ELIG_A { get; set; }
    [Column("VL_D_A")]
    public string VL_D_A { get; set; }
    [Column("VL_N_A")]
    public string VL_N_A { get; set; }
    [Column("HTS_F_A")]
    public string HTS_F_A { get; set; }
    [Column("HTS_M_A")]
    public string HTS_M_A { get; set; }
    [Column("HTS_F_P")]
    public string HTS_F_P { get; set; }
    [Column("HTS_M_P")]
    public string HTS_M_P { get; set; }
    [Column("POS_F_A")]
    public string POS_F_A { get; set; }
    [Column("POS_M_A")]
    public string POS_M_A { get; set; }
    [Column("POS_F_P")]
    public string POS_F_P { get; set; }
    [Column("POS_M_P")]
    public string POS_M_P { get; set; }
    [Column("TX_NEW_F_A")]
    public string TX_NEW_F_A { get; set; }
    [Column("TX_NEW_M_A")]
    public string TX_NEW_M_A { get; set; }
    [Column("TX_NEW_F_P")]
    public string TX_NEW_F_P { get; set; }
    [Column("TX_NEW_M_P")]
    public string TX_NEW_M_P { get; set; }
    [Column("vmmc_circ.u15.m")]
    public string vmmc_circ_u15_m { get; set; }
    [Column("vmmc_circ.o15.m")]
    public string vmmc_circ_o15_m { get; set; }
    [Column("prep_new.u15.f")]
    public string prep_new_u15_f { get; set; }
    [Column("prep_new.u15.m")]
    public string prep_new_u15_m { get; set; }
    [Column("prep_new.o15.f")]
    public string prep_new_o15_f { get; set; }
    [Column("prep_new.o15.m")]
    public string prep_new_o15_m { get; set; }
    [Column("tx_curr.u15.f")]
    public string tx_curr_u15_f { get; set; }
    [Column("tx_curr.u15.m")]
    public string tx_curr_u15_m { get; set; }
    [Column("tx_curr.o15.f")]
    public string tx_curr_o15_f { get; set; }
    [Column("tx_curr.o15.m")]
    public string tx_curr_o15_m { get; set; }
    [Column("tx_mmd.u15.f.u3mo")]
    public string tx_mmd_u15_f_u3mo { get; set; }
    [Column("tx_mmd.u15.m.u3mo")]
    public string tx_mmd_u15_m_u3mo { get; set; }
    [Column("tx_mmd.o15.f.u3mo")]
    public string tx_mmd_o15_f_u3mo { get; set; }
    [Column("tx_mmd.o15.m.u3mo")]
    public string tx_mmd_o15_m_u3mo { get; set; }
    [Column("tx_mmd.u15.f.35mo")]
    public string tx_mmd_u15_f_35mo { get; set; }
    [Column("tx_mmd.u15.m.35mo")]
    public string tx_mmd_u15_m_35mo { get; set; }
    [Column("tx_mmd.o15.f.35mo")]
    public string tx_mmd_o15_f_35mo { get; set; }
    [Column("tx_mmd.o15.m.35mo")]
    public string tx_mmd_o15_m_35mo { get; set; }
    [Column("tx_mmd.u15.f.o6mo")]
    public string tx_mmd_u15_f_o6mo { get; set; }
    [Column("tx_mmd.u15.m.o6mo")]
    public string tx_mmd_u15_m_o6mo { get; set; }
    [Column("tx_mmd.o15.f.o6mo")]
    public string tx_mmd_o15_f_o6mo { get; set; }
    [Column("tx_mmd.o15.m.o6mo")]
    public string tx_mmd_o15_m_o6mo { get; set; }
    [Column("Miss_App")]
    public string Miss_App { get; set; }
    [Column("MMS_6_P")]
    public string MMS_6_P { get; set; }
    [Column("MMS_6_A")]
    public string MMS_6_A { get; set; }
    [Column("LFTU_P")]
    public string LFTU_P { get; set; }
    [Column("L_SELF_REF_P")]
    public string L_SELF_REF_P { get; set; }
    [Column("L_CTC_P")]
    public string L_CTC_P { get; set; }
    [Column("L_RTX_P")]
    public string L_RTX_P { get; set; }
    [Column("L_DXD_P")]
    public string L_DXD_P { get; set; }
    [Column("L_REFX_P")]
    public string L_REFX_P { get; set; }
    [Column("L_WRNGD_P")]
    public string L_WRNGD_P { get; set; }
    [Column("L_UNBL_P")]
    public string L_UNBL_P { get; set; }
    [Column("L_NOATTMPT_P")]
    public string L_NOATTMPT_P { get; set; }
    [Column("LFTU_A")]
    public string LFTU_A { get; set; }
    [Column("L_SELF_REF_A")]
    public string L_SELF_REF_A { get; set; }
    [Column("L_CTC_A")]
    public string L_CTC_A { get; set; }
    [Column("L_RTX_A")]
    public string L_RTX_A { get; set; }
    [Column("L_DXD_A")]
    public string L_DXD_A { get; set; }
    [Column("L_REFX_A")]
    public string L_REFX_A { get; set; }
    [Column("L_WRNGD_A")]
    public string L_WRNGD_A { get; set; }
    [Column("L_UNBL_A")]
    public string L_UNBL_A { get; set; }
    [Column("L_NOATTMPT_A")]
    public string L_NOATTMPT_A { get; set; }
    [Column("HTS_2 months")]
    public string HTS_2_months { get; set; }
    [Column("POS_preg")]
    public string POS_preg { get; set; }
    [Column("PMTCT_STAT_D")] 
    public string PMTCT_STAT_D { get; set; }
    [Column("PMTCT_STAT_N")] 
    public string PMTCT_STAT_N { get; set; }
    [Column("PMTCT_ART")] 
    public string PMTCT_ART { get; set; }
    [Column("PMTCT_EID")] 
    public string PMTCT_EID { get; set; }
    [Column("PMTCT_HEI_POS")] 
    public string PMTCT_HEI_POS { get; set; }
    [Column("PMTCT_HEI_POS_ART")] 
    public string PMTCT_HEI_POS_ART { get; set; }
    [Column("MMS_6__ELIG_P_F")] 
    public string MMS_6__ELIG_P_F { get; set; }
    [Column("MMS_6_ELIG_P_M")] 
    public string MMS_6_ELIG_P_M { get; set; }
    [Column("MMS_6_ELIG_A_F")] 
    public string MMS_6_ELIG_A_F { get; set; }
    [Column("MMS_6_ELIG_A_M")] 
    public string MMS_6_ELIG_A_M { get; set; }
    [Column("TX_TB_D")] 
    public string TX_TB_D { get; set; }
    [Column("TX_TB_N")] 
    public string TX_TB_N { get; set; }
    [Column("TB_STAT_D")] 
    public string TB_STAT_D { get; set; }
    [Column("TB_STAT_N")] 
    public string TB_STAT_N { get; set; }
    [Column("TB_STAT_POS")] 
    public string TB_STAT_POS { get; set; }
    [Column("TB_ART")] 
    public string TB_ART { get; set; }
    
    public string Upload_Batch { get; set; }
    [Column("Report Date")]
    public string Report_Date { get; set; }
    public Guid UploadBatchGuid { get; set; }
}