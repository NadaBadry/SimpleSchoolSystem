using System.ComponentModel.DataAnnotations;

namespace SimpleSchoolSystem.Models
{
    public class Course
    {
        [Key]
        public int CourseID { get; set; }
        [MaxLength(100)]
        public string? Name { get; set; }
        public int DepartmentId {  get; set; }
        public Department? Department { get; set; }
        public ICollection<CourseInstructor> Instructors { get; set; } = new List<CourseInstructor>();
        public ICollection<StudentCourse> Students { get; set; }= new List<StudentCourse>();

    }
}
