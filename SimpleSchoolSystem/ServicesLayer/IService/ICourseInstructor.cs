using SimpleSchoolSystem.Models;

namespace SimpleSchoolSystem.ServicesLayer.IService
{
	public interface ICourseInstructor
	{
		IEnumerable<CourseInstructor> GetAll();
		CourseInstructor GetById(int id);
		void Insert(CourseInstructor entity);
		void Update(CourseInstructor entity);
		void Delete(int id);
		void Save();
	}
}
