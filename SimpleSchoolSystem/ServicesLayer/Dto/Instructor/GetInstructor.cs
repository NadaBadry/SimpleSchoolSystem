using System.ComponentModel.DataAnnotations;

namespace SimpleSchoolSystem.ServicesLayer.Dto.Instructor
{
    public class GetInstructor
    {
        [Key]
        public int InstructorId { get; set; }
        [MaxLength(100)]
        [Required]
        public string? InstructorName { get; set; }
    }
}
