using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleSchoolSystem.ServicesLayer.Dto.coursedto
{
    public class AllCourse
    {
        [Key]
        public int CourseID { get; set; }
        [MaxLength(100)]
        public string? Name { get; set; }
        //[ForeignKey("Department")]
        public int DepartmentId { get; set; }

    }
}
