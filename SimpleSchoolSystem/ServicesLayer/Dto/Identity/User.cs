using Microsoft.AspNetCore.Identity;

namespace SimpleSchoolSystem.ServicesLayer.Dto.Identity
{
    public class User : IdentityUser
    {
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public string? Address { get; set; }

    }
}
