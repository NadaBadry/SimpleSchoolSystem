using System.ComponentModel.DataAnnotations;

namespace SimpleSchoolSystem.Models
{
    public class Instructor
    {
        [Key]
        public int InstructorId { get; set; }
        [MaxLength(100)]
        [Required]
        public string? InstructorName { get; set; }
        public ICollection<StudentInstructor>?students { get; set; }
        [Required]
        public ICollection<CourseInstructor> Courses { get; set; } = new List<CourseInstructor>();
        [Required]
        public ICollection<DepartmentInstructor> Departments { get; set; }= new List<DepartmentInstructor>();
    }
}
