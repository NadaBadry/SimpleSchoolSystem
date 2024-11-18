using SimpleSchoolSystem.Models;
using SimpleSchoolSystem.ServicesLayer.Dto.Instructor;

namespace SimpleSchoolSystem.ServicesLayer.IService
{
	public interface IInstructorService
    {
		IEnumerable<GetInstructor> GetAll();
        GetInstructor GetById(int id);
		void Insert(GetInstructor entity);
		void Update(GetInstructor entity);
		void Delete(int id);
	}
}
