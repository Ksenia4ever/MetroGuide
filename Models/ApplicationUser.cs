using Microsoft.AspNetCore.Identity;

namespace MetroGuide.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; } = string.Empty;
    }
}