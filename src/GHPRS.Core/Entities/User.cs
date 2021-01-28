using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace GHPRS.Core.Entities
{
    public class User : IdentityUser
    {
        public int PersonId { get; set; }
        public virtual Person Person { get; set; }
        public virtual ICollection<Upload> Uploads { get; set; }
        public int OrganisationId { get; set; }
        public virtual Organisation Organisation { get; set; }
    }
}
