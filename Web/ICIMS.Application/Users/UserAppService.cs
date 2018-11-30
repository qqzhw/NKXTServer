using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using Abp.IdentityFramework;
using Abp.Localization;
using Abp.Runtime.Session;
using ICIMS.Authorization;
using ICIMS.Authorization.Roles;
using ICIMS.Authorization.Users;
using ICIMS.Roles.Dto;
using ICIMS.Users.Dto;
using Abp.Authorization.Users;
using Abp.Organizations;
using ICIMS.Dtos;
using Abp.AutoMapper;
using Abp.Linq.Extensions;
namespace ICIMS.Users
{
    [AbpAuthorize(PermissionNames.Pages_Users)]
    public class UserAppService : AsyncCrudAppService<User, UserDto, long, PagedResultRequestDto, CreateUserDto, UserDto>, IUserAppService
    {
        private readonly UserManager _userManager;
        private readonly RoleManager _roleManager;
        private readonly IRepository<Role> _roleRepository;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly IRepository<OrganizationUnit, long> _organizationUnitRepository;
        private readonly IRepository<UserOrganizationUnit, long> _userOrganizationUnitRepository;
        private readonly IRepository<User, long> _userRepository;
        public UserAppService(
            IRepository<User, long> repository,
            UserManager userManager,
            RoleManager roleManager, IRepository<User, long> userRepository,IRepository<OrganizationUnit, long> organizationUnitRepository, IRepository<UserOrganizationUnit, long> userOrganizationUnitRepository,
            IRepository<Role> roleRepository,
            IPasswordHasher<User> passwordHasher)
            : base(repository)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _roleRepository = roleRepository;
            _passwordHasher = passwordHasher;
            _organizationUnitRepository = organizationUnitRepository;
            _userOrganizationUnitRepository = userOrganizationUnitRepository;
            _userRepository = userRepository;
        }

        public override async Task<UserDto> Create(CreateUserDto input)
        {
            CheckCreatePermission();

            var user = ObjectMapper.Map<User>(input);

            user.TenantId = AbpSession.TenantId;
            user.IsEmailConfirmed = true;

            await _userManager.InitializeOptionsAsync(AbpSession.TenantId);

            CheckErrors(await _userManager.CreateAsync(user, input.Password));

            if (input.RoleNames.Count()>0)
            {
                CheckErrors(await _userManager.SetRoles(user, input.RoleNames));
            }
            if (input.UnitIds.Count()>0)
            {
               await _userManager.SetOrganizationUnitsAsync(user, input.UnitIds);
            }
            CurrentUnitOfWork.SaveChanges();

            return MapToEntityDto(user);
        }

        public override async Task<UserDto> Update(UserDto input)
        {
            CheckUpdatePermission();

            var user = await _userManager.GetUserByIdAsync(input.Id);

            MapToEntity(input, user);

            CheckErrors(await _userManager.UpdateAsync(user));

            if (input.RoleNames != null)
            {
                CheckErrors(await _userManager.SetRoles(user, input.RoleNames));
            }

            if(input.Units != null)
            {
                await _userManager.SetOrganizationUnitsAsync(user.Id, input.Units.Select(a=>a.Id).ToArray());
            }

            return await Get(input);
        }

        public override async Task Delete(EntityDto<long> input)
        {
            var user = await _userManager.GetUserByIdAsync(input.Id);
            await _userManager.DeleteAsync(user);
        }

        public async Task<ListResultDto<RoleDto>> GetRoles()
        {
            var roles = await _roleRepository.GetAllListAsync();
            return new ListResultDto<RoleDto>(ObjectMapper.Map<List<RoleDto>>(roles));
        }

        public async Task ChangeLanguage(ChangeUserLanguageDto input)
        {
            await SettingManager.ChangeSettingForUserAsync(
                AbpSession.ToUserIdentifier(),
                LocalizationSettingNames.DefaultLanguage,
                input.LanguageName
            );
        }

        protected override User MapToEntity(CreateUserDto createInput)
        {
            var user = ObjectMapper.Map<User>(createInput);
            user.SetNormalizedNames();
            return user;
        }

        protected override void MapToEntity(UserDto input, User user)
        {
            ObjectMapper.Map(input, user);
            user.SetNormalizedNames();
        }

        protected override  UserDto MapToEntityDto(User user)
        {
            var roles = _roleManager.Roles.Where(r => user.Roles.Any(ur => ur.RoleId == r.Id)).Select(r => r.NormalizedName);
            var userDto = base.MapToEntityDto(user);
            userDto.RoleNames = roles.ToArray();  
            return userDto;
        }

        protected override IQueryable<User> CreateFilteredQuery(PagedResultRequestDto input)
        {
            var query = Repository.GetAllIncluding(x => x.Roles); 
            return Repository.GetAllIncluding(x => x.Roles);
        }
        
        protected override async Task<User> GetEntityByIdAsync(long id)
        {
         
            var user = await Repository.GetAllIncluding(x => x.Roles).FirstOrDefaultAsync(x => x.Id == id);
           
            if (user == null)
            {
                throw new EntityNotFoundException(typeof(User), id);
            }
           
            return user;
        }
        
        protected override IQueryable<User> ApplySorting(IQueryable<User> query, PagedResultRequestDto input)
        {
            return query.OrderBy(r => r.UserName);
        }

        protected virtual void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }

        public virtual async Task<List<UnitDto>> GetUserUnitsAsync(long userId)
        {
            if (userId <1)
            {
                return null;
            }
            var items =await _userManager.GetUserOrganizationUnit(userId);
            return items.Select(o => new UnitDto() { Id = o.Id, Code = o.Code, Name = o.DisplayName }).ToList();
        }

        public async Task<UserDto> GetUserById(long id)
        {
            var user =await GetEntityByIdAsync(id);
            var userdto = MapToEntityDto(user);
            var items = await _userManager.GetUserOrganizationUnit(user.Id);
            userdto.Units= items.Select(o => new UnitDto() { Id = o.Id, Code = o.Code, Name = o.DisplayName }).ToList();
            return userdto;
        }

        public async Task CreateOrUpdateUserUnit(CreateUserUnitDto userUnitDto)
        {
            if (userUnitDto.UnitId>0&&userUnitDto.UserId>0)
            {
               await _userManager.AddToOrganizationUnitAsync(userUnitDto.UserId, userUnitDto.UnitId);
            }
            await Task.CompletedTask;
        }

        public async Task<PagedResultDto<UserDto>> GetAllUsersAsync(PagedAndSortedInputDto input)
        {
             var query =(from u in _userRepository.GetAll()  
                        join uou in _userOrganizationUnitRepository.GetAll() on u.Id equals uou.UserId
                        join ou in _organizationUnitRepository.GetAll() on uou.OrganizationUnitId equals ou.Id 
                        select  new UserDto {
                            CreationTime=u.CreationTime,
                            EmailAddress=u.EmailAddress,
                            FullName=u.FullName,
                            Id=u.Id,
                            IsActive=u.IsActive,
                            Name=u.Name,
                            Surname=u.Surname,
                            UserName=u.UserName,
                            LastLoginTime=u.LastLoginTime,
                            Unit=ou.MapTo<UnitDto>()
                        });
            var count = await query.CountAsync();

            var entityList = await query
                    .OrderBy(o=>o.Id).AsNoTracking()
                    .PageBy(input)
                    .ToListAsync();

        

            return new PagedResultDto<UserDto>(count, entityList);
        }
    }
}
