using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace GHPRS.Core.Entities;

[Table("StagingTBData")]
public class TBData : Entity
{
    // New Column name
    // --- Year
    // --- Priority_Tier
    // --- Month
    // --- MECHANISM ID
    // --- Partner
    // --- Agency
    // --- Region
    // --- District
    // --- Council
    // --- Ward
    // --- Site Name
    // --- Site_ID
    // TB_Detection_Male_0-14
    // TB_Detection_Male_15+
    // TB_Detection_Female_0-14
    // TB_Detection_Female_15+
    // Pulmonary_TB_0-14
    // Pulmonary_TB_15+

    [Column("MECHANISM ID")]
    public string Mechanism_ID { get; set; }
    [Column("Partner")]
    public string Partner { get; set; }
    [Column("Month")]
    public string Reporting_Month { get; set; }
    [Column("Year")]
    public string Year { get; set; }
    [Column("Region")]
    public string Region { get; set; }
    [Column("District")] 
    public string District { get; set; }
    [Column("Site Name")]
    public string Health_Facility { get; set; }
    [Column("Site_ID")]
    public string Facility_ID { get; set; }
    [Column("Priority_Tier")] 
    public string Priority_Tier { get; set; }
    [Column("Agency")] 
    public string Agency { get; set; }
    [Column("Council")] 
    public string Council { get; set; }
    [Column("Ward")] 
    public string Ward { get; set; }
    
    [Column("TB_Detection_Male_0-14")]
    public string TB_Detection_Male_0_14 { get; set; }
    [Column("TB_Detection_Male_15+")]
    public string TB_Detection_Male_15Plus { get; set; }
    [Column("TB_Detection_Female_0-14")]
    public string TB_Detection_Female_0_14 { get; set; }
    [Column("TB_Detection_Female_15+")]
    public string TB_Detection_Female_15Plus { get; set; }
    [Column("Pulmonary_TB_0-14")]
    public string Bacteriological_Diagnosis_Coverage_Pulmonary_TB_0_14 { get; set; }
    [Column("Pulmonary_TB_15+")]
    public string Bacteriological_Diagnosis_Coverage_Pulmonary_TB_15Plus { get; set; }
    
    public string Upload_Batch { get; set; }
    [Column("Report Date")]
    public string Report_Date { get; set; }
    public Guid UploadBatchGuid { get; set; }
}