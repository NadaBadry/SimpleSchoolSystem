using SimpleSchoolSystem.Models;
using SimpleSchoolSystem.ServicesLayer.Dto.Student;

namespace SimpleSchoolSystem.ServicesLayer.IService
{
	public interface IStudentService
	{
		IEnumerable<Student> GetAll();
		AllStudent GetById(int id);
		void Insert(AllStudent entity);
		void Update(AllStudent entity);
		void Delete(int id);

	}
}
