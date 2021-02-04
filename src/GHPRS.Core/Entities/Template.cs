namespace GHPRS.Core.Entities
{
    public class Template : Entity
    {
        public enum ReportingFrequency
        {
            Weekly,
            Monthly,
            Quarterly,
            Yearly,
            Adhoc
        }

        public enum TemplateStatus
        {
            NotConfigured,
            Active,
            Archived
        }

        public string Name { get; set; }
        public string FileExtension { get; set; }
        public string Description { get; set; }
        public byte[] File { get; set; }
        public string ContentType { get; set; }
        public decimal Version { get; set; }
        public TemplateStatus Status { get; set; }
        public ReportingFrequency Frequency { get; set; }
    }
}