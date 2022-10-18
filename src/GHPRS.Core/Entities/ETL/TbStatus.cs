using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GHPRS.Core.Entities.ETL;

[Table("TbStatus", Schema = "data")]
public class TbStatus
{
    [Key]
    public int id { get; set; }
    public string tb_status { get; set; }
}