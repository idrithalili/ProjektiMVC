using Microsoft.AspNetCore.Identity;

namespace Projekti.Models
{
    public class ApplicationUser : IdentityUser
    {
        public DateTime BirthDate { get; set; }
        public char Gender { get; set; }
    }
}
