using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GHPRS.Core.Entities.ETL;

[Table("PlhivEstimates", Schema = "data")]
public class PlhivEstimate
{
    // id, council_id, indicator, fiscal_year, age_dis_id,
    // sex_dis_id, hiv_status_id, disaggregate, other_dis,
    // data_source_id, targets
    [Key] public int id { get; set; }
    public string council_id { get; set; }
    public string indicator { get; set; }
    public int fiscal_year { get; set; }
    public int age_dis_id { get; set; }
    public int sex_dis_id { get; set; }
    public int hiv_status_id { get; set; }
    public string disaggregate { get; set; }
    public string other_dis { get; set; }
    public int data_source_id { get; set; }
    public double targets { get; set; }
}