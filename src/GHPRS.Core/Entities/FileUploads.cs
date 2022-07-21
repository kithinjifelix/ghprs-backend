using System;
using System.Collections.Generic;
using System.Text;

namespace GHPRS.Core.Entities
{
    public class FileUploads : Entity
    {
        public string Name { get; set; }
        public string ContentType { get; set; }
        public byte[] File { get; set; }
        public virtual User User { get; set; }
        public DateTime UploadDate { get; set; }
        public string Status { get; set; }
    }
}
