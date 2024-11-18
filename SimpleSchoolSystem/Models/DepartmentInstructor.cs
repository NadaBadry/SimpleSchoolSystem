namespace SimpleSchoolSystem.Models
{
    public class DepartmentInstructor
    {
        public int DepartmentId {  get; set; }
        public int InstructorId {  get; set; }
        public Instructor? Instructor { get; set; }
        public Department? Department { get; set; }
    }
}
