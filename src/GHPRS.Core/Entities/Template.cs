using System;

namespace GHPRS.Core.Entities
{
    public class Template : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Byte[] File { get; set; }
        public string ContentType { get; set; }
    }
}
