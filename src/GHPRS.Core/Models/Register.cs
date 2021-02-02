using System;
using System.ComponentModel.DataAnnotations;

namespace GHPRS.Core.Model
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "User Name is required")]
        public string Username { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Role Id is required")]
        public int RoleId { get; set; }
        public int OrganizationId { get; set; }
        public string PhoneNumber { get; set; }

        public string Name { get; set; }
        public int GenderId { get; set; }
        public int MaritalStatusId { get; set; }

        public DateTime DateOfBirth { get; set; }

    }
}