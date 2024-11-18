using SimpleSchoolSystem.Models;
using SimpleSchoolSystem.Models.Contract;
using SimpleSchoolSystem.ServicesLayer.Dto.Student;
using SimpleSchoolSystem.ServicesLayer.IService;

namespace SimpleSchoolSystem.ServicesLayer.Service
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        public StudentService(IStudentRepository _studentRepository) { 
        this._studentRepository = _studentRepository;
        }
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Student> GetAll()
        {
            return _studentRepository.GetAll().Select(s => new Student
            {
                StudentId = s.StudentId,
                StudentName = s.StudentName,
                StudentEmail = s.StudentEmail,
                departmentId = s.departmentId

            }


             );
        }

        public AllStudent GetById(int id)
        {
           var s=_studentRepository.GetById(id);
            if(s!=null)
            {
                new AllStudent
                {
                    StudentId = s.StudentId,
                    StudentName = s.StudentName,
                    StudentEmail = s.StudentEmail,
                    departmentId = s.departmentId
                };
            }
            return null;
        }

        public void Insert(AllStudent entity)
        {
            var student = new Student
            {
               // StudentId = entity.StudentId,
                StudentName = entity.StudentName,
                StudentEmail = entity.StudentEmail,
                departmentId = entity.departmentId
                
            };
            
           _studentRepository.Insert(student);
            _studentRepository.save();

        }

        public void Update( AllStudent entity)
        {
            var x = _studentRepository.GetById(entity.StudentId);
            if (x != null)
            {
                x.StudentName = entity.StudentName;
                x.StudentEmail = entity.StudentEmail;
                x.StudentId = entity.StudentId;
                x.StudentId = entity.StudentId;

                _studentRepository.Update(x);
                _studentRepository.save();
            }
        }
    }
}
