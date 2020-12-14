using System;

namespace GHPRS.Core.Entities
{
    public class Person : Entity
    {
        public string Name { get; set; }
        public int GenderId { get; set; }
        public int MaritalStatusId { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
