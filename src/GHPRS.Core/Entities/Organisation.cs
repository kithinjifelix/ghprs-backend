using System;
using System.Collections.Generic;
using System.Text;

namespace GHPRS.Core.Entities
{
    public class Organisation : Entity
    {
        public String Name { get; set; }
        public String Shortname { get; set; }
        public String Description { get; set; }
        public OrganisationStatus Status { get; set; }

        public enum OrganisationStatus
        {
            Active,
            Closed
        }

    }
}
