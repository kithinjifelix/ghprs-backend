using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GHPRS.Core.Entities.ETL;

[Table("Mechanisms", Schema = "data")]
public class Mechanism
{
    // id, mech_code, mech_name, prime_partner, funding_agency
    [Key]
    public int id { get; set; }
    public int mech_code { get; set; }
    public string mech_name { get; set; }
    public string prime_partner { get; set; }
    public string funding_agency { get; set; }
}