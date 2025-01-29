using Microsoft.AspNetCore.Identity;

namespace CodedAPI.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string Role { get; set; }
    }
}
