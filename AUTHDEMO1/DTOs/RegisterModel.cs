using System.ComponentModel.DataAnnotations;

public class RegisterModel
{
   

    [Required, EmailAddress]
    public string Email { get; set; }

    [Required]
    public string Password { get; set; }

    public string? ConfirmPassword { get; set; } // optional

    //public string? Role { get; set; }

    public string? UserName { get; set; }
}
