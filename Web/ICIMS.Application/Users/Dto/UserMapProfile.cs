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
               .ForMember(x => x.Units, opt => opt.MapFrom(o => o.UserOrganizationUnits.Select(x => new UnitDto() { Id = x.OrganizationUnitId })));
                
               
            CreateMap<CreateUserDto, User>();
            CreateMap<CreateUserDto, User>().ForMember(x => x.Roles, opt => opt.Ignore());
        }
    }
}
