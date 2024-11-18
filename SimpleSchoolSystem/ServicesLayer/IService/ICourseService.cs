using SimpleSchoolSystem.Models;
using SimpleSchoolSystem.ServicesLayer.Dto.coursedto;

namespace SimpleSchoolSystem.ServicesLayer.IService
{
    public interface ICourseService
    {
        IEnumerable<AllCourse>? GetAll();
        AllCourse? GetById(int id);
        void Insert(AllCourse entity);
        void Update(AllCourse entity);
        void Delete(int id);
      
    }
}
