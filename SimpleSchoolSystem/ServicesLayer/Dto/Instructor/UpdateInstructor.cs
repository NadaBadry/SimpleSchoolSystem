using System.ComponentModel.DataAnnotations;

namespace SimpleSchoolSystem.ServicesLayer.Dto.Instructor
{
    public class UpdateInstructor
    {
        [MaxLength(100)]
        [Required]
        public string? InstructorName { get; set; }
    }
}
