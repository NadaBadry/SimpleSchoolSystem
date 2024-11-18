using Microsoft.EntityFrameworkCore;
using SimpleSchoolSystem.Data;
using SimpleSchoolSystem.Models.Contract;

namespace SimpleSchoolSystem.Models.Repository
{
    public class CourseRepo : BaseRepository<Course>, ICourseRepository
    {
        public CourseRepo(ApplicationDbContext _context) : base(_context)
        {
        }
		public virtual IEnumerable<Course>? GetAll()
		{
			return _dbSet.Include(c=>c.Department).ToList();
		}
	}
}
