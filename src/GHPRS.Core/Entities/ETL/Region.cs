using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GHPRS.Core.Entities.ETL;

[Table("Regions", Schema = "data")]
public class Region
{
    // id, name
    [Key]
    public string id { get; set; }
    public string name { get; set; }
}