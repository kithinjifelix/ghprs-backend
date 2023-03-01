using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GHPRS.Core.Entities.ETL;

[Table("HivStatus", Schema = "data")]
public class HivStatus
{
    // id, hiv_status
    [Key]
    public int id { get; set; }
    public string hiv_status { get; set; }
}