using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SimpleSchoolSystem.Data;
using SimpleSchoolSystem.DJ;
using SimpleSchoolSystem.Models.Contract;
using SimpleSchoolSystem.Models.Repository;
using SimpleSchoolSystem.ServicesLayer.IService;
using SimpleSchoolSystem.ServicesLayer.Service;

namespace SimpleSchoolSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("cs")));
            builder.Services.AddScoped<IDepartmentR,DepartmentRepo>();
            builder.Services.AddScoped<IDepartmentS, DepartmentS>();
            builder.Services.AddScoped<ICourseRepository, CourseRepo>();
            builder.Services.AddScoped<ICourseService,CourseService>();
            builder.Services.AddScoped<IStudentRepository,StudentRepo>();
            builder.Services.AddScoped<IStudentService,StudentService>();   
            builder.Services.AddScoped<IInstructorRepository,InstructorRepo>();
            builder.Services.AddScoped<IInstructorService,InstructorService>();
            builder.Services.AddIdentityDependencyInjection();
            builder.Services.AddLocalization(op=>op.ResourcesPath="Resources");
            builder.Services.AddAutoMapper(typeof(Program));
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
