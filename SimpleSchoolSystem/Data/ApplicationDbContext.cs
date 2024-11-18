using Microsoft.EntityFrameworkCore;
using SimpleSchoolSystem.Models;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.General;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using IdentityDbContext = Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityDbContext;
using SimpleSchoolSystem.ServicesLayer.Dto.Identity;
namespace SimpleSchoolSystem.Data
{
    public class ApplicationDbContext:IdentityDbContext
    { 
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>option):
            base(option)
        {
            
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<StudentCourse> StudentsCourses { get; set; }
        public DbSet<CourseInstructor> CoursesInstructors { get;set; }
        public DbSet<DepartmentInstructor> DepartmentsInstructors { get;set;}
        public DbSet<StudentInstructor>StudentInstructors { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
         
            modelBuilder.Entity<CourseInstructor>().HasKey(e => new { e.CourseId,e.InstructorId });
            modelBuilder.Entity<StudentInstructor>().HasKey(e => new { e.StudentId,e.InstructorId });
            modelBuilder.Entity<DepartmentInstructor>().HasKey(e => new { e.DepartmentId,e.InstructorId });
            modelBuilder.Entity<StudentCourse>().HasKey(e => new { e.StudentId,e.CourseId });


            base.OnModelCreating(modelBuilder);
        }
        public DbSet<SimpleSchoolSystem.ServicesLayer.Dto.Student.AllStudent> AllStudent { get; set; } = default!;
        public DbSet<SimpleSchoolSystem.ServicesLayer.Dto.Instructor.GetInstructor> GetInstructor { get; set; } = default!;
        public DbSet<SimpleSchoolSystem.ServicesLayer.Dto.coursedto.AllCourse> AllCourse { get; set; } = default!;

    }
}
