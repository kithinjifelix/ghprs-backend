using System;
using System.Collections.Generic;
using System.Text;

namespace GHPRS.Core.Entities
{
    public class WorkSheet : Entity
    {
        public WorkSheet ()
        {
            TableName = GenerateDatabaseTableName(Name, Template.Name);
        }
        public string Name { get; set; }
        public string Range { get; set; }
        public string TableName { get; set; }
        public virtual Template Template { get; set; }
        public virtual ICollection<Column> Columns { get; set; }

        private string GenerateDatabaseTableName(string name, string templateName)
        {
            string TableName = $"{templateName.Replace(" ", "").Replace("-", "_")}.{name.Replace(" ", "").Replace("-", "_")}";
            return TableName;
        }
    }
}
