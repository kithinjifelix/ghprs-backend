using System.ComponentModel.DataAnnotations.Schema;

namespace GHPRS.Core.Entities;

[Table("stg_facility_data")]
public class FacilityData : Entity
{
    public string Priority_Tier { get; set; }
    public string Month { get; set; }
    public string Year { get; set; }
    public string MECHANISM_ID { get; set; }
    public string Partner { get; set; }

    public string Agency { get; set; }

    public string Region { get; set; }

    public string District { get; set; }

    public string Council { get; set; }

    public string Ward { get; set; }

    public string Site_Name { get; set; }

    public string Site_id { get; set; }

    public string CLIENT_A_TX_NEW { get; set; }

    public string CLIENT_A_TX_CURR { get; set; }

    public string CONTACT_A { get; set; }

    public string IPV_HX_SCREEN { get; set; }

    public string KNOWN_POS_A { get; set; }

    public string NEG_A { get; set; }

    public string POS_A { get; set; }

    public string CONTACT_PEDS { get; set; }

    public string KNOWN_POS_PEDS { get; set; }

    public string NEG_PEDS { get; set; }

    public string POS_PEDS { get; set; }

    public string OPD_P { get; set; }

    public string OPD_A { get; set; }

    public string SCREEN_A { get; set; }

    public string SCREEN_ELIG_A { get; set; }

    public string SCREEN_HTS_A { get; set; }

    public string SCREEN_HTS_POS_A { get; set; }

    public string LCM_A { get; set; }

    public string REFILL { get; set; }

    public string SDI_0_7 { get; set; }

    public string SDI_8_14 { get; set; }

    public string SDI_15 { get; set; }

    public string TX_PREV { get; set; }

    public string TX_CURR { get; set; }

    public string XFER_IN { get; set; }

    public string XFER_OUT { get; set; }

    public string XFER_DEATH { get; set; }

    public string MMS_1 { get; set; }

    public string MMS_2 { get; set; }

    public string MMS_3 { get; set; }

    public string TB_PREV_D { get; set; }

    public string TB_PREV_N { get; set; }

    public string TB_PREV_NEW { get; set; }

    public string VL_ELIG_P { get; set; }

    public string VL_D_P { get; set; }

    public string VL_N_P { get; set; }

    public string VL_ELIG_A { get; set; }

    public string VL_D_A { get; set; }

    public string VL_N_A { get; set; }

    public string HTS_F_A { get; set; }

    public string HTS_M_A { get; set; }

    public string HTS_F_P { get; set; }

    public string HTS_M_P { get; set; }

    public string POS_F_A { get; set; }

    public string POS_M_A { get; set; }

    public string POS_F_P { get; set; }

    public string POS_M_P { get; set; }

    public string TX_NEW_F_A { get; set; }

    public string TX_NEW_M_A { get; set; }

    public string TX_NEW_F_P { get; set; }

    public string TX_NEW_M_P { get; set; }

    public string vmmc_circ_u15_m { get; set; }

    public string vmmc_circ_o15_m { get; set; }

    public string prep_new_u15_f { get; set; }

    public string prep_new_u15_m { get; set; }

    public string prep_new_o15_f { get; set; }

    public string prep_new_o15_m { get; set; }

    public string tx_curr_u15_f { get; set; }

    public string tx_curr_u15_m { get; set; }

    public string tx_curr_o15_f { get; set; }

    public string tx_curr_o15_m { get; set; }

    public string tx_mmd_u15_f_u3mo { get; set; }
    public string tx_mmd_u15_m_u3mo { get; set; }
    public string tx_mmd_o15_f_u3mo { get; set; }
    public string tx_mmd_o15_m_u3mo { get; set; }
    public string tx_mmd_u15_f_35mo { get; set; }
    public string tx_mmd_u15_m_35mo { get; set; }
    public string tx_mmd_o15_f_35mo { get; set; }
    public string tx_mmd_o15_m_35mo { get; set; }
    public string tx_mmd_u15_f_o6mo { get; set; }
    public string tx_mmd_u15_m_o6mo { get; set; }
    public string tx_mmd_o15_f_o6mo { get; set; }
    public string tx_mmd_o15_m_o6mo { get; set; }

    public string Miss_App { get; set; }

    public string MMS_6_P { get; set; }

    public string MMS_6_A { get; set; }

    public string LFTU_P { get; set; }

    public string L_SELF_REF_P { get; set; }

    public string L_CTC_P { get; set; }

    public string L_RTX_P { get; set; }

    public string L_DXD_P { get; set; }

    public string L_REFX_P { get; set; }

    public string L_WRNGD_P { get; set; }

    public string L_UNBL_P { get; set; }

    public string L_NOATTMPT_P { get; set; }

    public string LFTU_A { get; set; }

    public string L_SELF_REF_A { get; set; }

    public string L_CTC_A { get; set; }

    public string L_RTX_A { get; set; }

    public string L_DXD_A { get; set; }

    public string L_REFX_A { get; set; }

    public string L_WRNGD_A { get; set; }

    public string L_UNBL_A { get; set; }

    public string L_NOATTMPT_A { get; set; }

    public string HTS_2_months { get; set; }

    public string POS_preg { get; set; }
}