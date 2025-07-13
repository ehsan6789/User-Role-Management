using Microsoft.AspNetCore.Identity;
namespace AUTHDEMO1.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }  // ✅ Add this
        public string LastName { get; set; }   // ✅ Add this
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; } = false;
        public DateTime CreatedDate { get; set; }
    }
}

