using Microsoft.AspNetCore.Identity;

namespace Projekti.Models
{
    public class UserViewModel : ApplicationUser
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
    }
}
