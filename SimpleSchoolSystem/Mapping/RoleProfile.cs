using AutoMapper;
using Microsoft.AspNetCore.Identity;
using SimpleSchoolSystem.ServicesLayer.Dto.Identity;
using SimpleSchoolSystem.ServicesLayer.Dto.Role;

namespace SimpleSchoolSystem.Mapping
{
    public class RoleProfile:Profile
    {
        public RoleProfile()
        {
            CreateMap<IdentityRole, GetRoles>();
            CreateMap<IdentityRole, UpdateRole>().ReverseMap();
            CreateMap<IdentityRole, GetRoleById>();
            CreateMap<User, ManageUserInRoleModel>()
                .ForMember(des => des.UserId, op => op.MapFrom(src => src.Id))
                .ForMember(des => des.UserName, op => op.MapFrom(src => src.UserName));


        }
    }
}
