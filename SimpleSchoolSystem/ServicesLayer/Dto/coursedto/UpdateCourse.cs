using System.ComponentModel.DataAnnotations;

namespace SimpleSchoolSystem.ServicesLayer.Dto.coursedto
{
    public class UpdateCourse
    {
        [MaxLength(100)]
        public string? Name { get; set; }
        public int DepartmentId { get; set; }
    }
}
