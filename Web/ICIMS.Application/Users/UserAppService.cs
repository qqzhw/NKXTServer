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
using ICIMS.BusinessManages;
using Abp.Domain.Uow;

namespace ICIMS.Users
{
   
    public class UserAppService : AsyncCrudAppService<User, UserDto, long, PagedResultRequestDto, CreateUserDto, UserDto>, IUserAppService
    {
        private readonly UserManager _userManager;
        private readonly RoleManager _roleManager;
        private readonly IRepository<Role> _roleRepository;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly IRepository<OrganizationUnit, long> _organizationUnitRepository;
        private readonly IRepository<UserOrganizationUnit, long> _userOrganizationUnitRepository;
        private readonly IRepository<UserManageUnit> _usermanagerUnitRepository;
        private readonly IRepository<User, long> _userRepository;
        public UserAppService(
            IRepository<User, long> repository,
            UserManager userManager,
            RoleManager roleManager, IRepository<User, long> userRepository, IRepository<OrganizationUnit, long> organizationUnitRepository, IRepository<UserOrganizationUnit, long> userOrganizationUnitRepository,
            IRepository<Role> roleRepository, IRepository<UserManageUnit> usermanagerUnitRepository,
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
            _usermanagerUnitRepository = usermanagerUnitRepository;
        }
        [AbpAuthorize(PermissionNames.Pages_Users)]
        public override async Task<UserDto> Create(CreateUserDto input)
        {
            CheckCreatePermission();

            var user = ObjectMapper.Map<User>(input);

            user.TenantId = AbpSession.TenantId;
            user.IsEmailConfirmed = true;

            await _userManager.InitializeOptionsAsync(AbpSession.TenantId);

            CheckErrors(await _userManager.CreateAsync(user, input.Password));


            if (input.Unit != null)
            {
                await _userManager.SetOrganizationUnitsAsync(user, input.Unit.Id);
            }
            CurrentUnitOfWork.SaveChanges();

            return await MapToNewEntityDto(user);
        }

        public async virtual Task<bool> ChangePasswordAsync(ChangePasswordDto dto)
        {
            var user = await _userManager.GetUserByIdAsync(dto.Id);
            CheckErrors(await _userManager.ChangePasswordAsync(user, dto.Password));

            return true;
        }

        public override async Task<UserDto> Update(UserDto input)
        {
            CheckUpdatePermission();

            var user = await _userManager.GetUserByIdAsync(input.Id);

            MapToEntity(input, user);

            CheckErrors(await _userManager.UpdateAsync(user));

            if (input.Roles != null)
            {
                CheckErrors(await _userManager.SetRoles(user, input.Roles.Select(o => o.Name).ToArray()));
            }
            if (input.Unit != null)
            {
                await _userManager.SetOrganizationUnitsAsync(user.Id, input.Unit.Id);
            }
            if (input.Units != null)
            {
                var entity = await GetEntityByIdAsync(input.Id);
                var oris = _usermanagerUnitRepository.GetAll().Where(a => a.UserId == input.Id);
                await _usermanagerUnitRepository.DeleteAsync(a => a.UserId == input.Id);
                foreach (var unit in input.Units)
                {
                    UserManageUnit one = new UserManageUnit();
                    one.UserId = input.Id;
                    one.UnitId = unit.Id;
                    one.TenantId = entity.TenantId;
                    await _usermanagerUnitRepository.InsertAsync(one);
                }

            }
            var rs = await Get(input);
            rs.Unit = input.Unit;
            rs.Units = input.Units;
            return rs;
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

        protected override UserDto MapToEntityDto(User user)
        {
            var roles = _roleManager.Roles.Include(o => o.Permissions).Where(r => user.Roles.Any(ur => ur.RoleId == r.Id));
            var userDto = base.MapToEntityDto(user);
            userDto.Roles = roles.Select(o => o.MapTo<RoleDto>()).ToList();
            // var unit = _userManager.GetUserOrganizationUnit(user.Id);
            return userDto;
        }

        private async Task<UserDto> MapToNewEntityDto(User user)
        {
            var roles = _roleManager.Roles.Include(o => o.Permissions).Where(r => user.Roles.Any(ur => ur.RoleId == r.Id));
            var userDto = base.MapToEntityDto(user);
            userDto.Roles = new List<RoleDto>();
            var units = await _userManager.GetUserOrganizationUnit(user.Id);
            var unit = units.FirstOrDefault();
            if (unit != null)
            {
                userDto.Unit = new UnitDto { Id = unit.Id, Code = unit.Code, Name = unit.DisplayName };
            }
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

        public virtual async Task<UnitDto> GetUserUnitAsync(long userId)
        {
            if (userId < 1)
            {
                return null;
            }
            var items = await _userManager.GetUserOrganizationUnit(userId);
            return items.FirstOrDefault().MapTo<UnitDto>();
        }

        public async Task<UserDto> GetUserById(long id)
        {
            var user = await GetEntityByIdAsync(id);
            var userdto = MapToEntityDto(user);
            var items = await _userManager.GetUserOrganizationUnit(user.Id);
            userdto.Unit = items.FirstOrDefault().MapTo<UnitDto>();
            var units = await GetUserManagerUnits(id);//用户管理部门
            userdto.Units = units.MapTo<List<UnitDto>>();
            return userdto;
        }
        public virtual async Task<List<OrganizationUnit>> GetUserManagerUnits(long userId)
        {
            var query = from uou in _usermanagerUnitRepository.GetAll()
                        join ou in _organizationUnitRepository.GetAll() on uou.UnitId equals ou.Id
                        where uou.UserId == userId
                        select ou;
            return await Task.FromResult(query.ToList());
        }
        public async Task CreateOrUpdateUserUnit(CreateUserUnitDto userUnitDto)
        {
            if (userUnitDto.UnitId > 0 && userUnitDto.UserId > 0)
            {
                await _userManager.AddToOrganizationUnitAsync(userUnitDto.UserId, userUnitDto.UnitId);
            }
            await Task.CompletedTask;
        }
        
        public async Task<PagedResultDto<UserDto>> GetAllUsersAsync(PagedAndSortedInputDto input)
        {
            var query = from u in _userRepository.GetAllIncluding().Include(u => u.Roles)
                        join uou in _userOrganizationUnitRepository.GetAll() on u.Id equals uou.UserId
                        join ou in _organizationUnitRepository.GetAll() on uou.OrganizationUnitId equals ou.Id                      
                        select new
                        {
                            CreationTime = u.CreationTime,
                            EmailAddress = u.EmailAddress,
                            FullName = u.FullName,
                            Id = u.Id,
                            IsActive = u.IsActive,
                            Name = u.Name,
                            Surname = u.Surname,
                            UserName = u.UserName,
                            LastLoginTime = u.LastLoginTime,
                            Unit = ou.MapTo<UnitDto>(),
                            u.Roles
                        };

            //var query1 = from o in _roleManager.Roles.Where(r =>query.Roles.Any(ur => ur.RoleId == r.Id))
            //             join p in query on o.Id equals p.Roles.FirstOrDefault(u=>u.RoleId == u.Id)
            //       select 
            //           new UserDto {
            //               CreationTime = p.CreationTime,
            //               EmailAddress = p.EmailAddress,
            //               FullName = p.FullName,
            //               Id = p.Id,
            //               IsActive = p.IsActive,
            //               Name = p.Name,
            //               Surname = p.Surname,
            //               UserName = p.UserName,
            //               LastLoginTime = p.LastLoginTime,
            //               Unit = p.Unit,
            //           };

            var count = await query.CountAsync();

            var entityList = await query
                    .OrderBy(o => o.Id).AsNoTracking()
                    .PageBy(input)
                    .ToListAsync();
            var roles = _roleRepository.GetAll().ToList();
            List<UserDto> dto = new List<UserDto>();
            foreach (var item in entityList)
            {
                var userDto = new UserDto()
                {
                    EmailAddress = item.EmailAddress,
                    FullName = item.FullName,
                    Id = item.Id,
                    IsActive = item.IsActive,
                    LastLoginTime = item.LastLoginTime,
                    Name = item.Name,
                    Surname = item.Surname,
                    Unit = item.Unit,
                    UserName = item.UserName,
                    CreationTime = item.CreationTime,
                    Roles = roles.Where(o => item.Roles.Any(r => r.RoleId == o.Id)).Select(p => p.MapTo<RoleDto>()).ToList(),
                };
                var units = await GetUserManagerUnits(item.Id);
                userDto.Units = units.Select(a => new UnitDto { Id = a.Id, Code = a.Code, Name = a.DisplayName }).ToList();
                dto.Add(userDto);
            }

            return new PagedResultDto<UserDto>(count, dto);
        }

        private RoleDto CreateRoleDto(int roleId)
        {
            var roleDto = new RoleDto();
            var query = _roleRepository.Get(roleId);
            if (query != null)
            {
                roleDto = query.MapTo<RoleDto>();
            }
            return roleDto;
        }
    }
}
