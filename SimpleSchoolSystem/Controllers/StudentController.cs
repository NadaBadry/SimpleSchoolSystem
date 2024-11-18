using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimpleSchoolSystem.ServicesLayer.Dto.Student;
using SimpleSchoolSystem.ServicesLayer.IService;

namespace SimpleSchoolSystem.Controllers
{
    [Authorize]
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;
        public StudentController(IStudentService _studentService)
        {
            this._studentService = _studentService;
        }
        
        public IActionResult Index()
        {
            var student = _studentService.GetAll().ToList();
            return View(student);
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]

        [HttpPost]
        public IActionResult Create(AllStudent student)
        {
            if (!ModelState.IsValid)
            {
                return View(student);
            }
          
            _studentService.Insert(student);
            return RedirectToAction("Index");

        }
        [Authorize(Roles = "Admin")]

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var x = _studentService.GetById(id);
            if (x == null)
            {
                return RedirectToAction("Index");
            }
            AllStudent c = new AllStudent
            {
              StudentId=x.StudentId,
              StudentName=x.StudentName,
              StudentEmail=x.StudentEmail,
              departmentId=x.departmentId
            };
            ViewData["DepartmentId"] = c.departmentId;
            return View(c);
        }
        [Authorize(Roles = "Admin")]

        [HttpPost]
        public IActionResult Edit( AllStudent s)
        {
            var x=_studentService.GetById(s.StudentId);
            if(x == null)return RedirectToAction("Index");
            _studentService.Update(s);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            var s = _studentService.GetById(id);
            if(s!=null)
            {
                return View(s);
            }
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "Admin")]

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var x= _studentService.GetById(id);
            if (x != null)
            {
                return View(x);
            }
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "Admin")]

        [HttpPost]
        public IActionResult Delete(AllStudent s)
        {
            _studentService.Delete(s.StudentId);
            return RedirectToAction("Index");
        }
    }
}
