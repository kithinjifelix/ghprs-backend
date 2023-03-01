using System;

namespace GHPRS.Core.Entities
{
    public class Upload : Entity
    {
        public string Name { get; set; }
        public string FileExtension { get; set; }
        public byte[] File { get; set; }
        public string ContentType { get; set; }
        public UploadStatus Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Comments { get; set; }
        public string UploadBatch { get; set; }
        public virtual User User { get; set; }
        public virtual Template Template { get; set; }
        public bool IsProcessed { get; set; } = false;
        public Guid UploadBatchGuid { get; set; }
        public string UploadStatus { get; set; }
        public int OrganizationId { get; set; }
        public virtual Organization Organization { get; set; }

        public void GenerateUploadBatch()
        {
            UploadBatch = $"{Template.Name.Replace(" ", "").Replace("-", "_")}_{User.OrganizationId}_{StartDate}_{EndDate}";
        }
    }

    public enum UploadStatus
    {
        Pending,
        Approved,
        Rejected,
        OverWritten
    }
}