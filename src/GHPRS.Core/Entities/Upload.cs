﻿using System;

namespace GHPRS.Core.Entities
{
    public class Upload : Entity
    {
        public string Name { get; set; }
        public string FileExtension { get; set; }
        public Byte[] File { get; set; }
        public string ContentType { get; set; }
        public UploadStatus Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Comments { get; set; }
        public virtual User User { get; set; }
        public virtual Template Template { get; set; }
    }

    public enum UploadStatus
    {
        pending,
        Approved,
        Rejected
    }
}
