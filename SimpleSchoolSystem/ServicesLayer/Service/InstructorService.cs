using SimpleSchoolSystem.Models.Contract;
using SimpleSchoolSystem.Models;
using SimpleSchoolSystem.ServicesLayer.IService;
using SimpleSchoolSystem.ServicesLayer.Dto.Instructor;

namespace SimpleSchoolSystem.ServicesLayer.Service
{
    public class InstructorService: IInstructorService

    {
        private readonly IInstructorRepository instructorRepository;

        public InstructorService(IInstructorRepository instructorRepository)
        {
           this.instructorRepository = instructorRepository;
        }
        public IEnumerable<GetInstructor> GetAll()
        {
            return instructorRepository.GetAll().Select(x => new GetInstructor
            {
                InstructorId=x.InstructorId,
                InstructorName=x.InstructorName

            });
        }

        public GetInstructor GetById(int id)
        {
            var x=instructorRepository.GetById(id);
            if (x != null)
            {
                return new GetInstructor
                {
                    InstructorId=x.InstructorId,
                    InstructorName=x.InstructorName
                    
                };
            }
            return null;
        }

        public void Insert(GetInstructor entity)
        {
            var x = new Instructor
            {
               InstructorId = entity.InstructorId,
               InstructorName=entity.InstructorName
            };
            instructorRepository.Insert(x);
            instructorRepository.save();

        }



        public void Update( GetInstructor entity)
        {
            var x = instructorRepository.GetById(entity.InstructorId);
            if (x != null)
            {
                x.InstructorId = entity.InstructorId;
                x.InstructorName = entity.InstructorName;


                instructorRepository.Update(x);
                instructorRepository.save();
            }

        }

        public void Delete(int id)
        {
            instructorRepository.Delete(id);
            instructorRepository.save();
        }


    }
}
