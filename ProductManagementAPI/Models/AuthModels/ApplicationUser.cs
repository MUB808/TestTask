using Microsoft.AspNetCore.Identity;

namespace ProductManagementAPI.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public string? Phone { get; set; }
    }
}
