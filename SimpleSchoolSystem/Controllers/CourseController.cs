using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimpleSchoolSystem.ServicesLayer.Dto.coursedto;
using SimpleSchoolSystem.ServicesLayer.IService;

namespace SimpleSchoolSystem.Controllers
{
    [Authorize]
    public class CourseController : Controller
    {
        private readonly ICourseService courseService;
        public CourseController(ICourseService courseService)
        {
            this.courseService = courseService;
        }
       
        public IActionResult Index()
        {
            var course = courseService.GetAll().ToList();
            return View(course);
        }
        [Authorize(Roles ="Admin")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]

        [HttpPost]
        public IActionResult Create(AllCourse C)
        {
            if (!ModelState.IsValid)
            {
                return View(C);
            }
           
            courseService.Insert(C);
            return RedirectToAction("Index");
         
        }
        [Authorize(Roles = "Admin")]

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var x = courseService.GetById(id);
            if (x == null)
            {
                return RedirectToAction("Index");
            }
            AllCourse c = new AllCourse
            {
                Name = x.Name,
                CourseID = x.CourseID,
                DepartmentId = x.DepartmentId
            };
            ViewData["DepartmentId"] = c.DepartmentId;
            return View(c);
        }
        [Authorize(Roles = "Admin")]

        [HttpPost]
        public IActionResult Edit( AllCourse course)
        {
            var x =courseService.GetById(course.CourseID);
            if (!ModelState.IsValid)
            {
                return View(course);
            }
           
               courseService.Update( course);
            
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "Admin")]

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var c=courseService.GetById(id);
            if(c != null)
            {
                return View(c);
            }
            return RedirectToAction();
        }
        [Authorize(Roles = "Admin")]

        [HttpPost]
        public IActionResult Delete(AllCourse c)
        {
            courseService.Delete(c.CourseID);
            return RedirectToAction("Index");
        }
        public IActionResult Details(int id)
        {
            var x=courseService.GetById(id);
            if(x == null)
            {
                return RedirectToAction("Index");
            }
            return View(x);
        }


    }
}
