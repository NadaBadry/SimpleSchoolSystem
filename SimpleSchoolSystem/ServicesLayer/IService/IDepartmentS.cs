using SimpleSchoolSystem.Models;
using SimpleSchoolSystem.ServicesLayer.Dto.Dept;

namespace SimpleSchoolSystem.ServicesLayer.IService
{
	public interface IDepartmentS
	{
		IEnumerable<GetAllDept> GetAll();
		GetAllDept? GetById(int id);
		void Insert(DeptDto entity);
		void Update(int id,DeptDto entity);
		void Delete(int id);
		
	}
}
