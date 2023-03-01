using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GHPRS.Core.Entities.ETL;

[Table("Councils", Schema = "data")]
public class Council
{
    // id, name, snu_prioritization, region_id
    [Key]
    public string id { get; set; }
    public string name { get; set; }
    public string snu_prioritization { get; set; }
    public string region_id { get; set; }
}