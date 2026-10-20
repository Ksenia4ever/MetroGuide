using Microsoft.AspNetCore.Identity;
using MetroGuide.Domain.Entities;

namespace MetroGuide.Infrastructure.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public Account? Account { get; set; }
    }
}