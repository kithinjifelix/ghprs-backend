using System.ComponentModel.DataAnnotations;

namespace GHPRS.Core.Models
{
    public class ResetPassword
    {
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}