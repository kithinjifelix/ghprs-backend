using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace GHPRS.Core.Entities;

[Table("StagingTBData")]
public class TBData : Entity
{
    [Column("Mechanism ID")]
    public string Mechanism_ID { get; set; }
    [Column("Partner")]
    public string Partner { get; set; }
    [Column("Reporting Month")]
    public string Reporting_Month { get; set; }
    [Column("Year")]
    public string Year { get; set; }
    [Column("Region")]
    public string Region { get; set; }
    [Column("District")] 
    public string District { get; set; }
    [Column("Health Facility")]
    public string Health_Facility { get; set; }
    [Column("Facility ID")]
    public string Facility_ID { get; set; }
    [Column("TB Detection Male 0 - 14")]
    public string TB_Detection_Male_0_14 { get; set; }
    [Column("TB Detection Male 15+")]
    public string TB_Detection_Male_15Plus { get; set; }
    [Column("TB Detection Female 0 - 14")]
    public string TB_Detection_Female_0_14 { get; set; }
    [Column("TB Detection Female 15+")]
    public string TB_Detection_Female_15Plus { get; set; }
    [Column("Bacteriological Diagnosis Coverage (Pulmonary TB) 0 - 14")]
    public string Bacteriological_Diagnosis_Coverage_Pulmonary_TB_0_14 { get; set; }
    [Column("Bacteriological Diagnosis Coverage (Pulmonary TB) 15+")]
    public string Bacteriological_Diagnosis_Coverage_Pulmonary_TB_15Plus { get; set; }
    
    public string Upload_Batch { get; set; }
    [Column("Report Date")]
    public string Report_Date { get; set; }
    public Guid UploadBatchGuid { get; set; }
}