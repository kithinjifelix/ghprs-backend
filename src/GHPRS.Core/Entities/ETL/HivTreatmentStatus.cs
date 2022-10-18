using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GHPRS.Core.Entities.ETL;

[Table("HivTreatmentStatus", Schema = "data")]
public class HivTreatmentStatus
{
    // id, hiv_tx_status
    [Key] public int id { get; set; }
    public string hiv_tx_status { get; set; }
}