using SimpleSchoolSystem.Models;

namespace SimpleSchoolSystem.ServicesLayer.IService
{
	public interface IstudentInstructor
	{
		IEnumerable<StudentInstructor> GetAll();
		StudentInstructor GetById(int id);
		void Insert(StudentInstructor entity);
		void Update(StudentInstructor entity);
		void Delete(int id);
		void Save();
	}
}
