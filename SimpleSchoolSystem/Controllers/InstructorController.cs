using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimpleSchoolSystem.ServicesLayer.Dto.Instructor;
using SimpleSchoolSystem.ServicesLayer.IService;
using System.Diagnostics.Contracts;

namespace SimpleSchoolSystem.Controllers
{
    [Authorize]
    public class InstructorController : Controller
    {
        private readonly IInstructorService _instructorService;
        public InstructorController( IInstructorService _instructorService)
        {
            this._instructorService = _instructorService;
        }
        public IActionResult Index()
        {
            var x=_instructorService.GetAll().ToList();
            return View(x);
        }
        [Authorize(Roles = "Admin")]

        public IActionResult Create()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]

        [HttpPost]
        public IActionResult Create(GetInstructor instructor)
        {
            if(!ModelState.IsValid)return View(instructor);
            _instructorService.Insert(instructor);
            return RedirectToAction("Index");

        }
        [Authorize(Roles = "Admin")]

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var x=_instructorService.GetById(id);
            if(x==null)
            {
                return RedirectToAction("Index");
            }
            GetInstructor z = new GetInstructor
            {
               InstructorId=x.InstructorId,
                InstructorName=x.InstructorName,
            };
            return View(z);
        }
        [Authorize(Roles = "Admin")]

        [HttpPost]
        public IActionResult Edit(GetInstructor instructor)
        {
            var x = _instructorService.GetById(instructor.InstructorId);
            if (x == null) { return RedirectToAction("Index"); }
            _instructorService.Update(instructor);
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "Admin")]

        [HttpGet]
        public IActionResult Details(int id)
        {
            var x = _instructorService.GetById(id);
            if (x != null) return View(x);
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "Admin")]

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var x=_instructorService.GetById(id);
            if (x!=null) return View(x);
            return RedirectToAction("Index");

        }
        [Authorize(Roles = "Admin")]

        [HttpPost]
        public IActionResult Delete(GetInstructor x)
        {
          _instructorService.Delete(x.InstructorId) ;
           return RedirectToAction("Index");

        }
    }
}
