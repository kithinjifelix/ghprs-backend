using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace GHPRS.Core.Entities.ETL;

[Table("Sites", Schema = "data")]
public class Site
{
    // id, name, is_military, is_dreams, ward_id
    public string id { get; set; }
    public string name { get; set; }
    public Char is_military { get; set; }
    public Char is_dreams { get; set; }
    public string ward_id { get; set; }
}