using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GHPRS.Core.Entities.ETL;

[Table("Modalities", Schema = "data")]
public class Modality
{
    // id, modality
    [Key] public int id { get; set; }
    public string modality { get; set; }
}