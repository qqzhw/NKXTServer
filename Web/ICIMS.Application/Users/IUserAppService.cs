using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Organizations;
using ICIMS.Authorization.Users;
using ICIMS.Dtos;
using ICIMS.Roles.Dto;
using ICIMS.Users.Dto;

namespace ICIMS.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedResultRequestDto, CreateUserDto, UserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();

        Task ChangeLanguage(ChangeUserLanguageDto input);

        Task<UnitDto> GetUserUnitAsync(long userId);

        Task<UserDto> GetUserById(long id);
        Task CreateOrUpdateUserUnit(CreateUserUnitDto userUnitDto);
        Task<PagedResultDto<UserDto>> GetAllUsersAsync(PagedAndSortedInputDto pageDto);
    }
}
