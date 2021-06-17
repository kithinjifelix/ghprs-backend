using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace GHPRS.Core.Entities
{
    public class User : IdentityUser
    {
        public int PersonId { get; set; }
        public virtual Person Person { get; set; }
        public virtual ICollection<Upload> Uploads { get; set; }
        public int OrganizationId { get; set; }
        public virtual Organization Organization { get; set; }
        [NotMapped]
        public int RoleId { get; set; }
    }
}