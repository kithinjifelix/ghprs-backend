using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace GHPRS.Core.Models
{
    public class MetabaseUser
    {
        [Required(ErrorMessage = "First Name is required")]
        [JsonPropertyName("first_name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name is required")]
        [JsonPropertyName("last_name")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "email is required")]
        [JsonPropertyName("email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [JsonPropertyName("password")]
        public string Password { get; set; }
        [JsonPropertyName("group_ids")]
        public int[] GroupIds { get; set; }
        [JsonPropertyName("login_attributes")]
        public int[] LoginAttributes { get; set; }
    }
}