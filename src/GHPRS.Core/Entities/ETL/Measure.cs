using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GHPRS.Core.Entities.ETL;

[Table("Measures", Schema = "data")]
public class Measure
{
    // id, org_unit_id, reported_at, indicator, num_or_den, period_id,
    // mechanism_id, age_dis_id, sex_dis_id, hiv_status_id, tb_status_id, cx_status_id, hiv_tx_status_id,
    // disaggregate, other_dis, other_dis_sub,
    // modality_id, data_source_id, value, is_target, plhiv_estimate
    [Key] public int id { get; set; }
    public string org_unit_id { get; set; }
    public string reported_at { get; set; }
    public string indicator { get; set; }
    public string num_or_den { get; set; }
    public string period_id { get; set; }
    public int mechanism_id { get; set; }
    public int age_dis_id { get; set; }
    public int sex_dis_id { get; set; }
    public int hiv_status_id { get; set; }
    public int tb_status_id { get; set; }
    public int cx_status_id { get; set; }
    public int hiv_tx_status_id { get; set; }
    public string disaggregate { get; set; }
    public string other_dis { get; set; }
    public string other_dis_sub { get; set; }
    public int modality_id { get; set; }
    public int data_source_id { get; set; }
    public double value { get; set; }
    public string is_target { get; set; }
    public string plhiv_estimate { get; set; }
}