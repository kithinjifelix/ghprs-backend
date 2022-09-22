using System;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace GHPRS.Core.Entities;

[Table("StagingCommunityData")]
public class CommunityData : Entity
{ 
    [Column("Month")]
    public string Month { get; set; }
    [Column("Year")]
    public string Year { get; set; }
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
    [Column("Site ID/ ward ID (from DATIM)")]
    public string SiteId { get; set; }
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
    [Column("HTS_PWID")]
    public string HTS_PWID { get; set; }
    [Column("POS_PWID")]
    public string POS_PWID { get; set; }
    [Column("CTC_SEX")]
    public string CTC_SEX { get; set; }
    [Column("CTC_PWID")]
    public string CTC_PWID { get; set; }
    [Column("CTC_CHILD")]
    public string CTC_CHILD { get; set; }
    [Column("TX_NEW_SEX")]
    public string TX_NEW_SEX { get; set; }
    [Column("TX_NEW_PWID")]
    public string TX_NEW_PWID { get; set; }
    [Column("TX_NEW_CHILD")]
    public string TX_NEW_CHILD { get; set; }
    [Column("SCREEN_M")]
    public string SCREEN_M { get; set; }
    [Column("SCREEN_F")]
    public string SCREEN_F { get; set; }
    [Column("SCREEN_PEDS")]
    public string SCREEN_PEDS { get; set; }
    [Column("SCREEN_ELIG_M")]
    public string SCREEN_ELIG_M { get; set; }
    [Column("SCREEN_ELIG_F")]
    public string SCREEN_ELIG_F { get; set; }
    [Column("SCREEN_ELIG_PEDS")]
    public string SCREEN_ELIG_PEDS { get; set; }
    [Column("SCREEN_HTS_M")]
    public string SCREEN_HTS_M { get; set; }
    [Column("SCREEN_HTS_F")]
    public string SCREEN_HTS_F { get; set; }
    [Column("SCREEN_HTS_PEDS")]
    public string SCREEN_HTS_PEDS { get; set; }
    [Column("SCREEN_HTS_POS_M")]
    public string SCREEN_HTS_POS_M { get; set; }
    [Column("SCREEN_HTS_POS_F")]
    public string SCREEN_HTS_POS_F { get; set; }
    [Column("SCREEN_HTS_POS_PEDS")]
    public string SCREEN_HTS_POS_PEDS { get; set; }
    [Column("HTS_M_A")]
    public string HTS_M_A { get; set; }
    [Column("HTS_F_A")]
    public string HTS_F_A { get; set; }
    [Column("HTS_M_P")]
    public string HTS_M_P { get; set; }
    [Column("HTS_F_P")]
    public string HTS_F_P { get; set; }
    [Column("POS_M_A")]
    public string POS_M_A { get; set; }
    [Column("POS_F_A")]
    public string POS_F_A { get; set; }
    [Column("POS_M_P")]
    public string POS_M_P { get; set; }
    [Column("POS_F_P")]
    public string POS_F_P { get; set; }
    [Column("CTC_M_A")]
    public string CTC_M_A { get; set; }
    [Column("CTC_F_A")]
    public string CTC_F_A { get; set; }
    [Column("CTC_M_P")]
    public string CTC_M_P { get; set; }
    [Column("CTC_F_P")]
    public string CTC_F_P { get; set; }
    [Column("LFTU")]
    public string LFTU { get; set; }
    [Column("L_SELF_REF")]
    public string L_SELF_REF { get; set; }
    [Column("L_CTC")]
    public string L_CTC { get; set; }
    [Column("L_RTX")]
    public string L_RTX { get; set; }
    [Column("L_DXD")]
    public string L_DXD { get; set; }
    [Column("L_REFX")]
    public string L_REFX { get; set; }
    [Column("L_WRNGD")]
    public string L_WRNGD { get; set; }
    [Column("L_UNBL")]
    public string L_UNBL { get; set; }
    [Column("L_NOATTMPT")]
    public string L_NOATTMPT { get; set; }
    [Column("PrEP Screen_FSW")] 
    public string PrEP_Screen_FSW { get; set; }
    [Column("PrEP Eligible_FSW")] 
    public string PrEP_Eligible_FSW { get; set; } 
    [Column("PrEP_NEW-FSW")]
    public string PrEP_NEW_FSW { get; set; }
    [Column("PrEP Screen-PWID")] 
    public string PrEP_Screen_PWID { get; set; }
    [Column("PrEP Eligible-PWID")] 
    public string PrEP_Eligible_PWID { get; set; }
    [Column("PrEP_NEW-PWID")] 
    public string PrEP_NEW_PWID { get; set; }
    [Column("PrEP Screen-MSM")] 
    public string PrEP_Screen_MSM { get; set; }
    [Column("PrEP Eligible-MSM")] 
    public string PrEP_Eligible_MSM { get; set; }
    [Column("PrEP Screen-AGY(15-19)")] 
    public string PrEP_Screen_AGY_15_19 { get; set; }
    [Column("PrEP Eligible-AGY(15-19)")]
    public string PrEP_Eligible_AGY_15_19 { get; set; }
    [Column("PrEP_NEW-AGYW(15-19)")]
    public string PrEP_NEW_AGYW_15_19 { get; set; }
    [Column("PrEP Eligible-AGY(20-24)")]
    public string PrEP_Eligible_AGY_20_24 { get; set; }
    [Column("PrEP_NEW-AGYW(20-24)")]
    public string PrEP_NEW_AGYW_20_24 { get; set; }
    [Column("PrEP Screen-TG")] 
    public string PrEP_Screen_TG { get; set; }
    [Column("PrEP Eligible-TG")] 
    public string PrEP_Eligible_TG { get; set; }
    [Column("PrEP_NEW-TG")] 
    public string PrEP_NEW_TG { get; set; }
    [Column("PrEP Screen-Serodiscordant Couple")]
    public string PrEP_Screen_Serodiscordant_Couple { get; set; }
    [Column("PrEP Eligible-Serodiscordant Couple")]
    public string PrEP_Eligible_Serodiscordant_Couple { get; set; }
    [Column("PrEP_NEW-Serodiscordant Couple")]
    public string PrEP_NEW_Serodiscordant_Couple { get; set; }
    [Column("PrEP Screen-Pregnant& Breastfeeding Women")]
    public string PrEP_Screen_Pregnant_Breastfeeding_Women { get; set; }
    [Column("PrEP Eligible-Pregnant& Breastfeeding Women")]
    public string PrEP_Eligible_Pregnant_Breastfeeding_Women { get; set; }
    [Column("PrEP_NEW-Pregnant& Breastfeeding Women")]
    public string PrEP_NEW_Pregnant_Breastfeeding_Women { get; set; }
    [Column("PrEP_CT-FSW")] 
    public string PrEP_CT_FSW { get; set; }
    [Column("PrEP_CT-PWID")] 
    public string PrEP_CT_PWID { get; set; }
    [Column("PrEP_CT-MSM")] 
    public string PrEP_CT_MSM { get; set; }
    [Column("PrEP_CT-AGYW")] 
    public string PrEP_CT_AGYW { get; set; }
    [Column("PrEP_CT-TG")] 
    public string PrEP_CT_TG { get; set; }
    [Column("PrEP_CT-Serodiscordant Couple")]
    public string PrEP_CT_Serodiscordant_Couple { get; set; }
    [Column("PrEP_CT-Pregnant& Breastfeeding Women")]
    public string PrEP_CT_Pregnant_Breastfeeding_Women { get; set; }

    public string Upload_Batch { get; set; }
    [Column("Report Date")]
    public string Report_Date { get; set; }

    public Guid UploadBatchGuid { get; set; }
}