using Microsoft.AspNetCore.Identity;

namespace GHPRS.Core.Entities
{
    public class User : IdentityUser
    {
        public int PersonId { get; set; }
        public virtual Person Person { get; set; }
    }
}
