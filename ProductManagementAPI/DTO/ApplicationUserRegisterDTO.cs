using System.ComponentModel.DataAnnotations;

namespace ProductManagementAPI.DTO
{
    public class ApplicationUserRegisterDTO
    {
        [Required]
        [MinLength(6, ErrorMessage = "UserName must be at least 6 characters long.")]
        public string UserName { get; set; }
        [Required]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters long.")]
        public string Password { get; set; }
        [EmailAddress]
        public string Name { get; set; }
        public string LastName { get; set; }
        public string? Email { get; set; }
        public string? Phone {  get; set; }
    }
}
