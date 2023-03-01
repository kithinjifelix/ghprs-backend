using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GHPRS.Core.Entities.ETL;

[Table("DataSources", Schema = "data")]
public class DataSource
{
    // id, source_name
    [Key]
    public int id { get; set; }
    public string source_name { get; set; }
}