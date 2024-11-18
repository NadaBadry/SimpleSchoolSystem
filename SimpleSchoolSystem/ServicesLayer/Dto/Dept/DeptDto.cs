using System.ComponentModel.DataAnnotations;

namespace SimpleSchoolSystem.ServicesLayer.Dto.Dept
{
    public class DeptDto
    {
        [Key]
        public int DepartmentId { get; set; }
        [MaxLength(100)]
        [Required]
        public string? departmentName {  get; set; }
    }
}
