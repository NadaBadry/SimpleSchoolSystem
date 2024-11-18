using System.ComponentModel.DataAnnotations;

namespace SimpleSchoolSystem.Models
{
    public class Department
    {
        [Key]
        public int DepartmentId {  get; set; }
        [MaxLength(100)]
        public string? DepartmentName {  get; set; }
        public ICollection<Student> Students { get; set; } = new List<Student>();
        public ICollection<Course> Courses { get; set; } = new List<Course>();
        public ICollection<Instructor> Instructors { get; set; } = new List<Instructor>();


    }
}
