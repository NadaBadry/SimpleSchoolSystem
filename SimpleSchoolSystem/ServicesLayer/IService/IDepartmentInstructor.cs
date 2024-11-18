using SimpleSchoolSystem.Models;

namespace SimpleSchoolSystem.ServicesLayer.IService
{
	public interface IDepartmentInstructor
	{
		IEnumerable<DepartmentInstructor> GetAll();
		DepartmentInstructor GetById(int id);
		void Insert(DepartmentInstructor entity);
		void Update(DepartmentInstructor entity);
		void Delete(int id);
		void Save();
	}
}
