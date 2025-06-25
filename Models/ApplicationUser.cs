using Microsoft.AspNetCore.Identity;
using AUTHDEMO1.Models;
using System.ComponentModel.DataAnnotations.Schema;


namespace AUTHDEMO1.Models
{
    public class ApplicationUser : IdentityUser
    {

        public bool IsDeleted { get; set; } = false;
        public string FirstName { get; set; }
        public string LastName { get; set; }
       
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }

        [NotMapped]
        public string Role { get; set; }

    }
}
