using System.ComponentModel.DataAnnotations.Schema;

namespace GHPRS.Core.Entities;

[Table("StagingPLHIVData")]
public class PLHIVData : Entity
{
    public string operatingunit { get; set; }
    public string operatingunituid { get; set; }
    public string country { get; set; }
    public string snu1 { get; set; }
    public string snu1uid { get; set; }
    public string psnu { get; set; }
    public string psnuuid { get; set; }
    public string snuprioritization { get; set; }
    public string indicator { get; set; }
    public string numeratordenom { get; set; }
    public string indicatortype { get; set; }
    public string disaggregate { get; set; }
    public string standardizeddisaggregate { get; set; }
    public string categoryoptioncomboname { get; set; }
    public string ageasentered { get; set; }
    public string age_2018 { get; set; }
    public string age_2019 { get; set; }
    public string trendscoarse { get; set; }
    public string sex { get; set; }
    public string statushiv { get; set; }
    public string otherdisaggregate { get; set; }
    public string fiscal_year { get; set; }
    public string targets { get; set; }
    public string qtr4 { get; set; }
    public string source_name { get; set; }
    
    public int FileUploadsId { get; set; }
    public virtual FileUploads FileUploads { get; set; }
}