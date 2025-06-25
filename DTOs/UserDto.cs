using AUTHDEMO1.DTOs;

public class UserDto
{
    public string Id { get; set; } // if for single user
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Role { get; set; }
    public bool IsActive { get; set; }

    // For list return:
    public List<UserViewModel> Users { get; set; }     // for GetAllAsync
    public int TotalUsers { get; set; }
}

