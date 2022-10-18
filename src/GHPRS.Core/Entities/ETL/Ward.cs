using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GHPRS.Core.Entities.ETL;

[Table("Wards", Schema = "data")]
public class Ward
{
    // id, name, council_id
    [Key] public string id { get; set; }
    public string name { get; set; }
    public string council_id { get; set; }
}