using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace GHPRS.Core.Entities;

[Table("stg_community_data")]
public class CommunityData : Entity
{
    [JsonProperty("Month")] public string Month { get; set; }
    [JsonProperty("Partner")] public string Partner { get; set; }
    [JsonProperty("Agency")] public string Agency { get; set; }
    [JsonProperty("Region")] public string Region { get; set; }
    [JsonProperty("District")] public string District { get; set; }
    [JsonProperty("Council")] public string Council { get; set; }
    [JsonProperty("Ward")] public string Ward { get; set; }
    [JsonProperty("Site ID/ward ID (from DATIM)")] public string SiteId { get; set; }
    [JsonProperty("CLIENT_A_TX_NEW")] public string CLIENT_A_TX_NEW { get; set; }
    [JsonProperty("CLIENT_A_TX_CURR")] public string CLIENT_A_TX_CURR { get; set; }
    [JsonProperty("CONTACT_A")] public string CONTACT_A { get; set; }
    [JsonProperty("IPV_HX_SCREEN")] public string IPV_HX_SCREEN { get; set; }
    [JsonProperty("KNOWN_POS_A")] public string KNOWN_POS_A { get; set; }
    [JsonProperty("NEG_A")] public string NEG_A { get; set; }
    [JsonProperty("POS_A")] public string POS_A { get; set; }
    [JsonProperty("CONTACT_PEDS")] public string CONTACT_PEDS { get; set; }
    [JsonProperty("KNOWN_POS_PEDS")] public string KNOWN_POS_PEDS { get; set; }
    [JsonProperty("NEG_PEDS")] public string NEG_PEDS { get; set; }
    [JsonProperty("POS_PEDS")] public string POS_PEDS { get; set; }
    [JsonProperty("HTS_PWID")] public string HTS_PWID { get; set; }
    [JsonProperty("POS_PWID")] public string POS_PWID { get; set; }
    [JsonProperty("CTC_SEX")] public string CTC_SEX { get; set; }
    [JsonProperty("CTC_PWID")] public string CTC_PWID { get; set; }
    [JsonProperty("CTC_CHILD")] public string CTC_CHILD { get; set; }
    [JsonProperty("TX_NEW_SEX")] public string TX_NEW_SEX { get; set; }
    [JsonProperty("TX_NEW_PWID")] public string TX_NEW_PWID { get; set; }
    [JsonProperty("TX_NEW_CHILD")] public string TX_NEW_CHILD { get; set; }
    [JsonProperty("SCREEN_M")] public string SCREEN_M { get; set; }
    [JsonProperty("SCREEN_F")] public string SCREEN_F { get; set; }
    [JsonProperty("SCREEN_PEDS")] public string SCREEN_PEDS { get; set; }
    [JsonProperty("SCREEN_ELIG_M")] public string SCREEN_ELIG_M { get; set; }
    [JsonProperty("SCREEN_ELIG_F")] public string SCREEN_ELIG_F { get; set; }
    [JsonProperty("SCREEN_ELIG_PEDS")] public string SCREEN_ELIG_PEDS { get; set; }
    [JsonProperty("SCREEN_HTS_M")] public string SCREEN_HTS_M { get; set; }
    [JsonProperty("SCREEN_HTS_F")] public string SCREEN_HTS_F { get; set; }
    [JsonProperty("SCREEN_HTS_PEDS")] public string SCREEN_HTS_PEDS { get; set; }
    [JsonProperty("SCREEN_HTS_POS_M")] public string SCREEN_HTS_POS_M { get; set; }
    [JsonProperty("SCREEN_HTS_POS_F")] public string SCREEN_HTS_POS_F { get; set; }
    [JsonProperty("SCREEN_HTS_POS_PEDS")] public string SCREEN_HTS_POS_PEDS { get; set; }
    [JsonProperty("HTS_M_A")] public string HTS_M_A { get; set; }
    [JsonProperty("HTS_F_A")] public string HTS_F_A { get; set; }
    [JsonProperty("HTS_M_P")] public string HTS_M_P { get; set; }
    [JsonProperty("HTS_F_P")] public string HTS_F_P { get; set; }
    [JsonProperty("POS_M_A")] public string POS_M_A { get; set; }
    [JsonProperty("POS_F_A")] public string POS_F_A { get; set; }
    [JsonProperty("POS_M_P")] public string POS_M_P { get; set; }
    [JsonProperty("POS_F_P")] public string POS_F_P { get; set; }
    [JsonProperty("CTC_M_A")] public string CTC_M_A { get; set; }
    [JsonProperty("CTC_F_A")] public string CTC_F_A { get; set; }
    [JsonProperty("CTC_M_P")] public string CTC_M_P { get; set; }
    [JsonProperty("CTC_F_P")] public string CTC_F_P { get; set; }
    [JsonProperty("LFTU")] public string LFTU { get; set; }
    [JsonProperty("L_SELF_REF")] public string L_SELF_REF { get; set; }
    [JsonProperty("L_CTC")] public string L_CTC { get; set; }
    [JsonProperty("L_RTX")] public string L_RTX { get; set; }
    [JsonProperty("L_DXD")] public string L_DXD { get; set; }
    [JsonProperty("L_REFX")] public string L_REFX { get; set; }
    [JsonProperty("L_WRNGD")] public string L_WRNGD { get; set; }
    [JsonProperty("L_UNBL")] public string L_UNBL { get; set; }
    [JsonProperty("L_NOATTMPT")] public string L_NOATTMPT { get; set; }

    public int FileUploadsId { get; set; }
    public virtual FileUploads FileUploads { get; set; }
}