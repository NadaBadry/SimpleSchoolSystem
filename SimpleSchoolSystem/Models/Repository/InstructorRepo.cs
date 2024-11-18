using SimpleSchoolSystem.Data;
using SimpleSchoolSystem.Models.Contract;

namespace SimpleSchoolSystem.Models.Repository
{
    public class InstructorRepo : BaseRepository<Instructor>, IInstructorRepository
    {
        public InstructorRepo(ApplicationDbContext _context) : base(_context)
        {
        }
    }
}
