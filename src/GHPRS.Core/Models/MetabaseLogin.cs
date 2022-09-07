using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace GHPRS.Core.Models
{
    public class MetabaseLogin
    {
        [Required(ErrorMessage = "Username is required")]
        [JsonPropertyName("username")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [JsonPropertyName("password")]
        public string Password { get; set; }
    }
}