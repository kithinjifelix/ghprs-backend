﻿
namespace GHPRS.Core.Entities
{
    public class Lookup : Entity
    {
        public string Name { get; set; }
        public LookupType LookupType { get; set; }
    }

    public enum LookupType
    {
        Gender,
        MaritalStatus,
        County,
        Role,
        Relationship,
        FacilityLevel,
        AppointmentStatus
    }
}