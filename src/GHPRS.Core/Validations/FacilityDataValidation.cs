using Newtonsoft.Json;

namespace GHPRS.Core.Validations;

public class FacilityDataValidation
{
    [JsonProperty("Priority Tier (1, 2, 3, 4)")]
    public string Priority_Tier { get; set; }
    [JsonProperty("Month")]
    public string Month { get; set; }
    [JsonProperty("Year")]
    public string Year { get; set; }
    [JsonProperty("MECHANISM ID", Required = Required.Always)]
    public string MECHANISM_ID { get; set; }
    [JsonProperty("Partner")]
    public string Partner { get; set; }
    [JsonProperty("Agency")]
    public string Agency { get; set; }
    [JsonProperty("Region")]
    public string Region { get; set; }
    [JsonProperty("District")]
    public string District { get; set; }
    [JsonProperty("Council")]
    public string Council { get; set; }
    [JsonProperty("Ward")]
    public string Ward { get; set; }
    [JsonProperty("Site Name")]
    public string Site_Name { get; set; }
    [JsonProperty("Site ID (from DATIM)")]
    public string Site_id { get; set; }
    [JsonProperty("CLIENT_A_TX_NEW", Required = Required.Always, DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string CLIENT_A_TX_NEW { get; set; }
    [JsonProperty("CLIENT_A_TX_CURR", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string CLIENT_A_TX_CURR { get; set; }
    [JsonProperty("CONTACT_A", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string CONTACT_A { get; set; }
    [JsonProperty("IPV_HX_SCREEN", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string IPV_HX_SCREEN { get; set; }
    [JsonProperty("KNOWN_POS_A", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string KNOWN_POS_A { get; set; }
    [JsonProperty("NEG_A", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string NEG_A { get; set; }
    [JsonProperty("POS_A", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string POS_A { get; set; }
    [JsonProperty("CONTACT_PEDS", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string CONTACT_PEDS { get; set; }
    [JsonProperty("KNOWN_POS_PEDS", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string KNOWN_POS_PEDS { get; set; }
    [JsonProperty("NEG_PEDS", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string NEG_PEDS { get; set; }
    [JsonProperty("POS_PEDS", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string POS_PEDS { get; set; }
    [JsonProperty("OPD_P", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string OPD_P { get; set; }
    [JsonProperty("OPD_A", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string OPD_A { get; set; }
    [JsonProperty("SCREEN_A", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string SCREEN_A { get; set; }
    [JsonProperty("SCREEN_ELIG_A", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string SCREEN_ELIG_A { get; set; }
    [JsonProperty("SCREEN_HTS_A", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string SCREEN_HTS_A { get; set; }
    [JsonProperty("SCREEN_HTS_POS_A", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string SCREEN_HTS_POS_A { get; set; }
    [JsonProperty("LCM_A", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string LCM_A { get; set; }
    [JsonProperty("REFILL", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string REFILL { get; set; }
    [JsonProperty("SDI_0_7", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string SDI_0_7 { get; set; }
    [JsonProperty("SDI_8_14", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string SDI_8_14 { get; set; }
    [JsonProperty("SDI_15", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string SDI_15 { get; set; }
    [JsonProperty("TX_PREV", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string TX_PREV { get; set; }
    [JsonProperty("TX_CURR", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string TX_CURR { get; set; }
    [JsonProperty("XFER_IN", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string XFER_IN { get; set; }
    [JsonProperty("XFER_OUT", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string XFER_OUT { get; set; }
    [JsonProperty("XFER_DEATH", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string XFER_DEATH { get; set; }
    [JsonProperty("MMS_1", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string MMS_1 { get; set; }
    [JsonProperty("MMS_2", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string MMS_2 { get; set; }
    [JsonProperty("MMS_3", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string MMS_3 { get; set; }
    [JsonProperty("TB_PREV_D", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string TB_PREV_D { get; set; }
    [JsonProperty("TB_PREV_N", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string TB_PREV_N { get; set; }
    [JsonProperty("TB_PREV_NEW", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string TB_PREV_NEW { get; set; }
    [JsonProperty("VL_ELIG_P", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string VL_ELIG_P { get; set; }
    [JsonProperty("VL_D_P", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string VL_D_P { get; set; }
    [JsonProperty("VL_N_P", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string VL_N_P { get; set; }
    [JsonProperty("VL_ELIG _A ", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string VL_ELIG_A { get; set; }
    [JsonProperty("VL_D_A", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string VL_D_A { get; set; }
    [JsonProperty("VL_N_A", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string VL_N_A { get; set; }
    [JsonProperty("HTS_F_A", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string HTS_F_A { get; set; }
    [JsonProperty("HTS_M_A")]
    public string HTS_M_A { get; set; }
    [JsonProperty("HTS_F_P")]
    public string HTS_F_P { get; set; }
    [JsonProperty("HTS_M_P")]
    public string HTS_M_P { get; set; }
    [JsonProperty("POS_F_A")]
    public string POS_F_A { get; set; }
    [JsonProperty("POS_M_A")]
    public string POS_M_A { get; set; }
    [JsonProperty("POS_F_P")]
    public string POS_F_P { get; set; }
    [JsonProperty("POS_M_P")]
    public string POS_M_P { get; set; }
    [JsonProperty("TX_NEW_F_A")]
    public string TX_NEW_F_A { get; set; }
    [JsonProperty("TX_NEW_M_A")]
    public string TX_NEW_M_A { get; set; }
    [JsonProperty("TX_NEW_F_P")]
    public string TX_NEW_F_P { get; set; }
    [JsonProperty("TX_NEW_M_P")]
    public string TX_NEW_M_P { get; set; }
    [JsonProperty("vmmc_circ.u15.m", Required = Required.Always)]
    public string vmmc_circ_u15_m { get; set; }
    [JsonProperty("vmmc_circ.o15.m")]
    public string vmmc_circ_o15_m { get; set; }
    [JsonProperty("prep_new.u15.f")]
    public string prep_new_u15_f { get; set; }
    [JsonProperty("prep_new.u15.m")]
    public string prep_new_u15_m { get; set; }
    [JsonProperty("prep_new.o15.f")]
    public string prep_new_o15_f { get; set; }
    [JsonProperty("prep_new.o15.m")]
    public string prep_new_o15_m { get; set; }
    [JsonProperty("tx_curr.u15.f")]
    public string tx_curr_u15_f { get; set; }
    [JsonProperty("tx_curr.u15.m")]
    public string tx_curr_u15_m { get; set; }
    [JsonProperty("tx_curr.o15.f")]
    public string tx_curr_o15_f { get; set; }
    [JsonProperty("tx_curr.o15.m")]
    public string tx_curr_o15_m { get; set; }
    [JsonProperty("tx_mmd.u15.f.u3mo")]
    public string tx_mmd_u15_f_u3mo { get; set; }
    [JsonProperty("tx_mmd.u15.m.u3mo")]
    public string tx_mmd_u15_m_u3mo { get; set; }
    [JsonProperty("tx_mmd.o15.f.u3mo")]
    public string tx_mmd_o15_f_u3mo { get; set; }
    [JsonProperty("tx_mmd.o15.m.u3mo")]
    public string tx_mmd_o15_m_u3mo { get; set; }
    [JsonProperty("tx_mmd.u15.f.35mo")]
    public string tx_mmd_u15_f_35mo { get; set; }
    [JsonProperty("tx_mmd.u15.m.35mo")]
    public string tx_mmd_u15_m_35mo { get; set; }
    [JsonProperty("tx_mmd.o15.f.35mo")]
    public string tx_mmd_o15_f_35mo { get; set; }
    [JsonProperty("tx_mmd.o15.m.35mo")]
    public string tx_mmd_o15_m_35mo { get; set; }
    [JsonProperty("tx_mmd.u15.f.o6mo")]
    public string tx_mmd_u15_f_o6mo { get; set; }
    [JsonProperty("tx_mmd.u15.m.o6mo")]
    public string tx_mmd_u15_m_o6mo { get; set; }
    [JsonProperty("tx_mmd.o15.f.o6mo")]
    public string tx_mmd_o15_f_o6mo { get; set; }
    [JsonProperty("tx_mmd.o15.m.o6mo")]
    public string tx_mmd_o15_m_o6mo { get; set; }
    [JsonProperty("Miss_App")]
    public string Miss_App { get; set; }
    [JsonProperty("MMS_6_P")]
    public string MMS_6_P { get; set; }
    [JsonProperty("MMS_6_A")]
    public string MMS_6_A { get; set; }
    [JsonProperty("LFTU_P")]
    public string LFTU_P { get; set; }
    [JsonProperty("L_SELF_REF_P")]
    public string L_SELF_REF_P { get; set; }
    [JsonProperty("L_CTC_P")]
    public string L_CTC_P { get; set; }
    [JsonProperty("L_RTX_P")]
    public string L_RTX_P { get; set; }
    [JsonProperty("L_DXD_P")]
    public string L_DXD_P { get; set; }
    [JsonProperty("L_REFX_P")]
    public string L_REFX_P { get; set; }
    [JsonProperty("L_WRNGD_P")]
    public string L_WRNGD_P { get; set; }
    [JsonProperty("L_UNBL_P")]
    public string L_UNBL_P { get; set; }
    [JsonProperty("L_NOATTMPT_P")]
    public string L_NOATTMPT_P { get; set; }
    [JsonProperty("LFTU_A")]
    public string LFTU_A { get; set; }
    [JsonProperty("L_SELF_REF_A")]
    public string L_SELF_REF_A { get; set; }
    [JsonProperty("L_CTC_A")]
    public string L_CTC_A { get; set; }
    [JsonProperty("L_RTX_A")]
    public string L_RTX_A { get; set; }
    [JsonProperty("L_DXD_A")]
    public string L_DXD_A { get; set; }
    [JsonProperty("L_REFX_A")]
    public string L_REFX_A { get; set; }
    [JsonProperty("L_WRNGD_A")]
    public string L_WRNGD_A { get; set; }
    [JsonProperty("L_UNBL_A")]
    public string L_UNBL_A { get; set; }
    [JsonProperty("L_NOATTMPT_A")]
    public string L_NOATTMPT_A { get; set; }
    [JsonProperty("HTS_2 months")]
    public string HTS_2_months { get; set; }
    [JsonProperty("POS_preg")]
    public string POS_preg { get; set; }
}