using System;
using System.Collections.Generic;

namespace GHPRS.Core.Entities
{
    public class Organization : Entity
    {
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Description { get; set; }
        public OrganizationStatus Status { get; set; }
        public ICollection<User> Users { get; set; }

        public enum OrganizationStatus
        {
            Active,
            Closed
        }

    }
}
