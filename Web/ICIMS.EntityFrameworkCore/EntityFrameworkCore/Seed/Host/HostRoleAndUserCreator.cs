using System.Linq;
using Microsoft.EntityFrameworkCore;
using Abp.Authorization;
using Abp.Authorization.Roles;
using Abp.Authorization.Users;
using Abp.MultiTenancy;
using ICIMS.Authorization;
using ICIMS.Authorization.Roles;
using ICIMS.Authorization.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using ICIMS.BaseData.Authorization;
using System.Collections.Generic;
using ICIMS.BusinessManages.Authorization;

namespace ICIMS.EntityFrameworkCore.Seed.Host
{
    public class HostRoleAndUserCreator
    {
        private readonly ICIMSDbContext _context;

        public HostRoleAndUserCreator(ICIMSDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateHostRoleAndUsers();
        }

        private void CreateHostRoleAndUsers()
        {
            // Admin role for host

            var adminRoleForHost = _context.Roles.IgnoreQueryFilters().FirstOrDefault(r => r.TenantId == null && r.Name == StaticRoleNames.Host.Admin);
            if (adminRoleForHost == null)
            {
                adminRoleForHost = _context.Roles.Add(new Role(null, StaticRoleNames.Host.Admin, StaticRoleNames.Host.Admin) { IsStatic = true, IsDefault = true }).Entity;
                _context.SaveChanges();
            }

            // Grant all permissions to admin role for host

            var grantedPermissions = _context.Permissions.IgnoreQueryFilters()
                .OfType<RolePermissionSetting>()
                .Where(p => p.TenantId == null && p.RoleId == adminRoleForHost.Id)
                .Select(p => p.Name)
                .ToList();
            var authList = new List<AuthorizationProvider>();
            authList.Add(new BuyCategoryAuthorizationProvider());
            authList.Add(new ContractCategoryAuthorizationProvider()); 
            authList.Add(new DocumentCategoryAuthorizationProvider());
            authList.Add(new ProjectPropsAuthorizationProvider());
            authList.Add(new FilesManageAuthorizationProvider());
            authList.Add(new FunctionSubjectAuthorizationProvider());
            authList.Add(new FundFromAuthorizationProvider());
            authList.Add(new ItemCategoryAuthorizationProvider());
            authList.Add(new PaymentTypeAuthorizationProvider());
            authList.Add(new VendorAuthorizationProvider());
            authList.Add(new YSCategoryAuthorizationProvider());
            authList.Add(new BudgetAuthorizationProvider());
            authList.Add(new BusinessAuditAuthorizationProvider());
            authList.Add(new BusinessTypeAuthorizationProvider());
            authList.Add(new ContractAuthorizationProvider());
            authList.Add(new ItemDefineAuthorizationProvider());
            authList.Add(new PayAuditAuthorizationProvider());
            authList.Add(new ReViewDefineAuthorizationProvider());
            authList.Add(new AuditMappingAuthorizationProvider());
           
            var permissions = PermissionFinder
                .GetAllPermissions(authList.ToArray())
                .Where(p => p.MultiTenancySides.HasFlag(MultiTenancySides.Host) &&
                            !grantedPermissions.Contains(p.Name))
                .ToList();
            

            if (permissions.Any())
            {
                _context.Permissions.AddRange(
                    permissions.Select(permission => new RolePermissionSetting
                    {
                        TenantId = null,
                        Name = permission.Name,
                        IsGranted = true,
                        RoleId = adminRoleForHost.Id
                    })
                );
                _context.SaveChanges();
            }

            // Admin user for host

            var adminUserForHost = _context.Users.IgnoreQueryFilters().FirstOrDefault(u => u.TenantId == null && u.UserName == AbpUserBase.AdminUserName);
            if (adminUserForHost == null)
            {
                var user = new User
                {
                    TenantId = null,
                    UserName = AbpUserBase.AdminUserName,
                    Name = "admin",
                    Surname = "admin",
                    EmailAddress = "admin@admin.com",
                    IsEmailConfirmed = true,
                    IsActive = true
                };

                user.Password = new PasswordHasher<User>(new OptionsWrapper<PasswordHasherOptions>(new PasswordHasherOptions())).HashPassword(user, "123qwe");
                user.SetNormalizedNames();

                adminUserForHost = _context.Users.Add(user).Entity;
                _context.SaveChanges();

                // Assign Admin role to admin user
                _context.UserRoles.Add(new UserRole(null, adminUserForHost.Id, adminRoleForHost.Id));
                _context.SaveChanges();

                _context.SaveChanges();
            }
        }
    }
}
