using Abp.Organizations;
using AutoMapper;
using ICIMS.Authorization.Users;
using System.Linq;
namespace ICIMS.Users.Dto
{
    public class UserMapProfile : Profile
    {
        public UserMapProfile()
        {
            CreateMap<UserDto, User>();
            CreateMap<UserDto, User>()
                .ForMember(x=>x.UserOrganizationUnits,opt=>opt.Ignore())
                .ForMember(x => x.Roles, opt => opt.Ignore())
                .ForMember(x => x.CreationTime, opt => opt.Ignore())
                .ForMember(x => x.LastLoginTime, opt => opt.Ignore());
            CreateMap<User, UserDto>()
                .ForMember(x => x.Roles, opt => opt.Ignore())
                .ForMember(x => x.Unit, opt => opt.Ignore());
            //.ForMember(x => x.Unit, opt => opt.MapFrom(o => o.UserOrganizationUnits.Select(x => new UnitDto() { Id = x.OrganizationUnitId }).FirstOrDefault()));


            CreateMap<CreateUserDto, User>();
            CreateMap<CreateUserDto, User>().ForMember(x => x.Roles, opt => opt.Ignore());
            CreateMap<OrganizationUnit, UnitDto>()
               .ForMember(x => x.Name, opt => opt.MapFrom(o => o.DisplayName));           
             
        }
    }
}
