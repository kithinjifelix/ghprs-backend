using System;
using System.Collections.Generic;

namespace GHPRS.Core.Entities
{
    public class Template : Entity
    {
        public string Name { get; set; }
        public string FileExtension { get; set; }
        public string Description { get; set; }
        public Byte[] File { get; set; }
        public string ContentType { get; set; }
        public decimal Version { get; set; }
        public TemplateStatus Status { get; set; }
        public ReportingFrequency Frequency { get; set; }

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
    }
}
