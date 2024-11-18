using Microsoft.AspNetCore.Identity;
using SimpleSchoolSystem.Data;
using SimpleSchoolSystem.ServicesLayer.Dto.Identity;

namespace SimpleSchoolSystem.DJ
{
    public static class IdentityDJ
    {
        public static IServiceCollection AddIdentityDependencyInjection(this IServiceCollection services)
        {
            services.AddIdentity<User, IdentityRole>(op =>
            {
                //password
                op.Password.RequireDigit = true;
                op.Password.RequireLowercase = true;
                op.Password.RequiredLength = 8;
                //lockout
                op.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1);
                op.Lockout.MaxFailedAccessAttempts = 5;
                op.Lockout.AllowedForNewUsers = true;
                //user
                op.User.RequireUniqueEmail = true;
                //sign in setting
                op.SignIn.RequireConfirmedPhoneNumber = false;
            }).AddEntityFrameworkStores<ApplicationDbContext>();
            return services;
        }
    }
}
