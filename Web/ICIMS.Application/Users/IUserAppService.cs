using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Organizations;
using ICIMS.Authorization.Users;
using ICIMS.Roles.Dto;
using ICIMS.Users.Dto;

namespace ICIMS.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedResultRequestDto, CreateUserDto, UserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();

        Task ChangeLanguage(ChangeUserLanguageDto input);

        Task<List<UnitDto>> GetOrganizationUnitsAsync(User user);

        Task<UserDto> GetUserById(long id);
        Task CreateOrUpdateUserUnit(CreateUserUnitDto userUnitDto);
    }
}
