using Microsoft.AspNetCore.Identity;

namespace Binding.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? Address { get; set; }


         
    }
}
