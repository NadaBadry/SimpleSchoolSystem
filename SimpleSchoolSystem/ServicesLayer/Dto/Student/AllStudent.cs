using SimpleSchoolSystem.Models;
using System.ComponentModel.DataAnnotations;

namespace SimpleSchoolSystem.ServicesLayer.Dto.Student
{
    public class AllStudent
    {
        [Key]
        public int StudentId { get; set; }
        [MaxLength(100)]
        public string? StudentName { get; set; }
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Please enter Email ID")]
        public string? StudentEmail { get; set; }
        public int departmentId { get; set; }
       // public Department? department { get; set; }
    }
}
