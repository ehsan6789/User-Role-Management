
namespace AUTHDEMO1.DTOs
{
    public class UserDto
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }
        public bool IsActive { get; set; }
        public List<UserViewModel> Users { get; internal set; }
        public int TotalUsers { get; internal set; }
    }
}

