using SimpleSchoolSystem.Data;
using SimpleSchoolSystem.Models.Contract;

namespace SimpleSchoolSystem.Models.Repository
{
    public class StudentCourseRepo : BaseRepository<StudentCourse>, IStudentCourse
    {
        public StudentCourseRepo(ApplicationDbContext _context) : base(_context)
        {
        }
    }
}
