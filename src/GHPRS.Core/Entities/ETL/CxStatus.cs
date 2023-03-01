using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GHPRS.Core.Entities.ETL;

[Table("CxStatus", Schema = "data")]
public class CxStatus
{
    [Key]
    public int id { get; set; }
    public string cx_status { get; set; }
}