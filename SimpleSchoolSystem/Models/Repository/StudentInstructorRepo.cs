using SimpleSchoolSystem.Data;
using SimpleSchoolSystem.Models.Contract;

namespace SimpleSchoolSystem.Models.Repository
{
    public class StudentInstructorRepo : BaseRepository<StudentInstructor>, IStudentInstructor
    {
        public StudentInstructorRepo(ApplicationDbContext _context) : base(_context)
        {
        }
    }
}
