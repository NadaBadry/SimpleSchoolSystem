using SimpleSchoolSystem.Data;
using SimpleSchoolSystem.Models.Contract;

namespace SimpleSchoolSystem.Models.Repository
{
    public class DepartmentInstructorRepo : BaseRepository<DepartmentInstructor>, IDepartmentInstructor
    {
        public DepartmentInstructorRepo(ApplicationDbContext _context) : base(_context)
        {
        }
    }
}
