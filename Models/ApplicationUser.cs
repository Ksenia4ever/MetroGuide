using Microsoft.AspNetCore.Identity;

namespace MetroGuide.Models
{
    public class ApplicationUser : IdentityUser
    {
        public Account? Account { get; set; }
    }
}