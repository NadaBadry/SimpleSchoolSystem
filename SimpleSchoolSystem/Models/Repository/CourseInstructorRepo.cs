using SimpleSchoolSystem.Data;
using SimpleSchoolSystem.Models.Contract;

namespace SimpleSchoolSystem.Models.Repository
{
    public class CourseInstructorRepo : BaseRepository<CourseInstructor>, ICourseInstructor
    {
        public CourseInstructorRepo(ApplicationDbContext _context) : base(_context)
        {
        }
    }
}
