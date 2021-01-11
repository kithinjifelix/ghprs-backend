﻿using System;

namespace GHPRS.Core.Entities
{
    public class Upload : Entity
    {
        public string Name { get; set; }
        public Byte[] File { get; set; }
        public string ContentType { get; set; }
        public UploadStatus Status { get; set; }
        public string Comments { get; set; }
    }

    public enum UploadStatus
    {
        pending,
        Approved,
        Rejected
    }
}
