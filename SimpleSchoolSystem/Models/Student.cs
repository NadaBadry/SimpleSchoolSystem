using System.ComponentModel.DataAnnotations;

namespace SimpleSchoolSystem.Models
{
    public class Student
    {
        [Key]
        public int StudentId {  get; set; }
        [MaxLength(100)]
        public string? StudentName { get; set; }
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Please enter Email ID")]
        public string? StudentEmail { get; set; }
        public int departmentId {  get; set; }
        public Department? department { get; set; }
        public ICollection<StudentCourse> courses { get; set; } = new List<StudentCourse>();
        public ICollection<StudentInstructor>Instructors { get; set; }= new List<StudentInstructor>();
        

    }
}
