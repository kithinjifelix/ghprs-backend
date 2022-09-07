using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace GHPRS.Core.Entities
{
    public class WorkSheet : Entity
    {
        [JsonProperty("SheetName")]
        public string Name { get; set; }
        public string Range { get; set; }
        public string TableName { get; set; }
        public virtual Template Template { get; set; }
        public int TemplateId { get; set; }
        public virtual ICollection<Column> Columns { get; set; }

        public void GenerateDatabaseTableName(string name, string templateName, decimal templateVersion)
        {
            TableName = $"{templateName.Replace(" ", "").Replace("-", "_")}_v{templateVersion}.{name.Replace(" ", "").Replace("-", "_")}";
        }
    }
}
