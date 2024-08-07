using System.ComponentModel.DataAnnotations;

namespace ProductManagementAPI.DTO
{
    public class AssignRoleDTO
    {
        [Required]
        public string UserName { get; set; }
    }

}
