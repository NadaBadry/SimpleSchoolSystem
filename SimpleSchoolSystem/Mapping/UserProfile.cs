using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using SimpleSchoolSystem.ServicesLayer.Dto.Account;
using SimpleSchoolSystem.ServicesLayer.Dto.Identity;
using SimpleSchoolSystem.ServicesLayer.Dto.User;

namespace SimpleSchoolSystem.Mapping
{
    public class UserProfile:Profile

    {
        public UserProfile()
        {
            CreateMap<Registration, User>().ForMember(des => des.UserName, op => op.MapFrom(src => src.UserName))
                .ForMember(des => des.Email, op => op.MapFrom(src => src.Email));
            CreateMap<User,UserViewModel>().ForMember(des => des.Name, op => op.MapFrom(src => Thread.CurrentThread.CurrentCulture.TwoLetterISOLanguageName.StartsWith("ar")?src.NameAr:src.NameEn));
            CreateMap<User,updateUser>().ReverseMap();
            CreateMap<User, GetUserByIdViewModel>();
            CreateMap<IdentityRole, ManageRoleInUserViewModel>().ForMember(des => des.RoleId, op => op.MapFrom(src => src.Id))
                .ForMember(des => des.RoleName, op => op.MapFrom(src => src.Name));

        }
    }
}
