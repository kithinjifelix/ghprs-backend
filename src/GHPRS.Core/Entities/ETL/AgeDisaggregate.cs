using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GHPRS.Core.Entities.ETL;

[Table("AgeDisaggregates", Schema = "data")]
public class AgeDisaggregate
{
    [Key]
    public int id { get; set; }
    public string age_dis { get; set; }
}