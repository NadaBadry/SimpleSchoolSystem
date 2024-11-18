using SimpleSchoolSystem.Models;
using SimpleSchoolSystem.Models.Contract;
using SimpleSchoolSystem.ServicesLayer.Dto.Dept;
using SimpleSchoolSystem.ServicesLayer.IService;

namespace SimpleSchoolSystem.ServicesLayer.Service
{
	public class DepartmentS : IDepartmentS
	{ 
		private readonly IDepartmentR departmentR;
        public DepartmentS(IDepartmentR departmentR)
        {
            this.departmentR = departmentR;
        }

		public void Delete(int id)
		{
			departmentR.Delete(id);
			//departmentR.Save();
		}

		public IEnumerable<GetAllDept> GetAll()
		{
			return departmentR.GetAll().Select(d =>
				new GetAllDept
				{
					DepartmentId=d.DepartmentId,
					DepartmentName = d.DepartmentName
				}
			);
		}

		public GetAllDept GetById(int id)
		{
			var x=departmentR.GetById(id);
			if(x!= null)
			{
				return new GetAllDept
				{
					DepartmentId = x.DepartmentId,
					DepartmentName = x.DepartmentName
				};
			}
			return null;
		}

		public void Insert(DeptDto entity)
		{
			var x = new Department
			{
				DepartmentName = entity.departmentName
			};
			departmentR.Insert(x);
			departmentR.save();
		}

	

		public void Update(int id,DeptDto entity)
		{
			var x = departmentR.GetById(id);
			if (x != null)
			{
				x.DepartmentId=entity.DepartmentId;
				x.DepartmentName=entity.departmentName;
			}
			departmentR.Update(x);
			departmentR.save();
		}
	}
}
