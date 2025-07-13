using System.ComponentModel.DataAnnotations;

namespace AUTHDEMO1.DTOs
{
    public class UserViewModel
    {
        [Required]
        public string Id { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public string Fullname => $"{FirstName} {LastName}";

        //[Display(Name = "Department")]
        //public string Department { get; set; }

        [Required]
        [Display(Name = "Role")]
        public string Role { get; set; }

        public bool IsActive { get; set; } = true;

        // Only required for new users
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
