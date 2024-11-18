using SimpleSchoolSystem.Models;
using SimpleSchoolSystem.Models.Contract;
using SimpleSchoolSystem.ServicesLayer.Dto.coursedto;
using SimpleSchoolSystem.ServicesLayer.IService;

namespace SimpleSchoolSystem.ServicesLayer.Service
{
    public class CourseService:ICourseService
    {
        private readonly ICourseRepository courseRepository;

        public CourseService(ICourseRepository course)
        {
            this.courseRepository = course;
        }
        public IEnumerable<AllCourse> GetAll()
        {
            return courseRepository.GetAll().Select(x => new AllCourse
            {
                CourseID = x.CourseID,
                Name = x.Name,
                DepartmentId=x.DepartmentId

            });
        }

        public AllCourse GetById(int id)
        {
            Course c= courseRepository.GetById(id);
            if (c != null)
            {
                return new AllCourse
                {
                    CourseID = c.CourseID,
                    Name = c.Name,
                    DepartmentId = c.DepartmentId
                };
            }
            return null;
        }

        public void Insert(AllCourse entity)
        {
            var x = new Course
            {
                Name = entity.Name,
                CourseID = entity.CourseID,
                DepartmentId=entity.DepartmentId

            };
            courseRepository.Insert(x);
            courseRepository.save();

        }

      

        public void Update(AllCourse entity)
        {
            var x = courseRepository.GetById(entity.CourseID);
            if (x != null)
            {
                x.Name = entity.Name;
                x.CourseID = entity.CourseID;
                x.DepartmentId = entity.DepartmentId;
            }

            courseRepository.Update(x);
            courseRepository.save();
           
        }

        public void Delete(int id)
        {
            courseRepository.Delete(id);
            courseRepository.save();
        }

        
    }
}
