using SimpleSchoolSystem.Data;
using SimpleSchoolSystem.Models.Contract;

namespace SimpleSchoolSystem.Models.Repository
{
    public class DepartmentRepo : BaseRepository<Department>, IDepartmentR
    {
        public DepartmentRepo(ApplicationDbContext _context) : base(_context)
        {
        }
    }
}
