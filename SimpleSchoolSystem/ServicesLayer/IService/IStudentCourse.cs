using SimpleSchoolSystem.Models;

namespace SimpleSchoolSystem.ServicesLayer.IService
{
	public interface IStudentCourse
	{
		IEnumerable<StudentCourse> GetAll();
		StudentCourse GetById(int id);
		void Insert(StudentCourse entity);
		void Update(StudentCourse entity);
		void Delete(int id);
		void Save();
	}
}
