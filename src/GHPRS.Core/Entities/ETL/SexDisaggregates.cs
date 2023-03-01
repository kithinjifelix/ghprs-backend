using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GHPRS.Core.Entities.ETL;

[Table("SexDisaggregates", Schema = "data")]
public class SexDisaggregates
{
    // id, sex_dis
    [Key]
    public int id { get; set; }
    public string sex_dis { get; set; }
}