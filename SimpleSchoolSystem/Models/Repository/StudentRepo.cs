using SimpleSchoolSystem.Data;
using SimpleSchoolSystem.Models.Contract;

namespace SimpleSchoolSystem.Models.Repository
{
    public class StudentRepo : BaseRepository<Student>, IStudentRepository
    {
        public StudentRepo(ApplicationDbContext _context) : base(_context)
        {
        }
    }
}
