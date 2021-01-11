using System;
using System.Collections.Generic;
using System.Text;

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
