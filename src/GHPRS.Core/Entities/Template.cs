using System;
using System.Collections.Generic;

namespace GHPRS.Core.Entities
{
    public class Template : Entity
    {
        public Template()
        {
            TableName = GenerateDatabaseTableName(Name);
        }
        public string Name { get; set; }
        public string FileExtension { get; set; }
        public string Description { get; set; }
        public Byte[] File { get; set; }
        public string ContentType { get; set; }
        public decimal Version { get; set; }
        public TemplateStatus Status { get; set; }
        public ReportingFrequency Frequency { get; set; }

        public string TableName { get; set; }
        public virtual ICollection<Column> Columns { get; set; }

        public enum TemplateStatus
        {
            Active,
            Archived
        }

        public enum ReportingFrequency
        {
            Weekly,
            Monthly,
            Querterly,
            Yearly,
            Adhoc
        }

        private string GenerateDatabaseTableName(string name)
        {
            string TableName = name.Replace(" ", "").Replace("-", "_");
            return TableName;
        }

    }
}
