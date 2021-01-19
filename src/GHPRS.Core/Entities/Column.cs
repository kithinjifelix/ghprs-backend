using System;
using System.Collections.Generic;
using System.Text;

namespace GHPRS.Core.Entities
{
    public class Column : Entity
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public virtual Template Template { get; set; }
    }
}
