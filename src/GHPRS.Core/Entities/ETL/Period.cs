using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GHPRS.Core.Entities.ETL;

[Table("Periods", Schema = "data")]
public class Period
{
    // id, modality
    [Key] public int id { get; set; }
    public string modality { get; set; }
}