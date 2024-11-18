using System.ComponentModel.DataAnnotations;

namespace SimpleSchoolSystem.ServicesLayer.Dto.Role
{
    public class AddRole
    {
        [Required]
        public string Name { get; set; }
    }
}
