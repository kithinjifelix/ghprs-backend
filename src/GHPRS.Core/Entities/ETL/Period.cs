using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GHPRS.Core.Entities.ETL;

[Table("Periods", Schema = "data")]
public class Period
{
    // period_id, period, calendar_year, period_type, date, fiscal_year, fiscal_year_2, fy_quarter, fy_semester
    [Key] public string period_id { get; set; }
    public string period { get; set; }
    public int calendar_year { get; set; }
    public string period_type { get; set; }
    public DateTime date { get; set; }
    public string fiscal_year { get; set; }
    public int fiscal_year_2 { get; set; }
    public string fy_quarter { get; set; }
    public string fy_semester { get; set; }
}