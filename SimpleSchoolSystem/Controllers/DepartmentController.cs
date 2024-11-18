using Humanizer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimpleSchoolSystem.Models;
using SimpleSchoolSystem.ServicesLayer.Dto.Dept;
using SimpleSchoolSystem.ServicesLayer.Dto.Student;
using SimpleSchoolSystem.ServicesLayer.IService;

namespace SimpleSchoolSystem.Controllers
{
	[Authorize]
	public class DepartmentController : Controller
	{
		private readonly IDepartmentS departmentS;
		public DepartmentController(IDepartmentS departmentS)
		{
			this.departmentS = departmentS;
		}
		public IActionResult Index()
		{
			var dept = departmentS.GetAll().ToList();
			return View(dept);
		}
		[Authorize(Roles ="Admin")]
		public IActionResult Create()
		{
			return View();
        }
				
		[Authorize(Roles ="Admin")]

        [HttpPost]
		public IActionResult Create(DeptDto Dept)
		{
			if(!ModelState.IsValid)
			{
				return View(Dept);
			}
			departmentS.Insert(Dept);
			return RedirectToAction("Index");
		}
        [Authorize(Roles = "Admin")]

        [HttpGet]
		public IActionResult Delete(int id)
		{
			var d=departmentS.GetById(id);
			if(d!=null)return View(d);
			return RedirectToAction("Index");
		}
		[HttpPost]
		public IActionResult Delete(GetAllDept dept)
		{
			departmentS.Delete(dept.DepartmentId);
			return RedirectToAction("Index");
		}
        [Authorize(Roles = "Admin")]

        [HttpGet]
		public IActionResult Edit(int id)
		{
			var x = departmentS.GetById(id);
			if (x == null)
			{
				return RedirectToAction("Index");
			}
			DeptDto dept = new DeptDto()
			{
				DepartmentId=x.DepartmentId,
				departmentName=x.DepartmentName
			};
			return View(dept);

		}
        [Authorize(Roles = "Admin")]

        [HttpPost]
		public IActionResult Edit(int id, DeptDto d)
		{
			var x = departmentS.GetById(id);
			if(!ModelState.IsValid)
			{
				return View(d);
			}
			if (x!= null)
			{
				if (x.DepartmentId == d.DepartmentId)
				{
					departmentS.Update(id, d);
					RedirectToAction("Index");
				}
				//return View(d);
				
			}
			return RedirectToAction("Index");

        }
		public IActionResult Details(int id)
		{
			var x=departmentS.GetById(id);
			if(x!=null)
			{
				return View(x);
			}
			return RedirectToAction("Index");
		}
    }
}
