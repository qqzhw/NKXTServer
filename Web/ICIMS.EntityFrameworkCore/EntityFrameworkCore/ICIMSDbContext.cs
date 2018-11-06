using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using ICIMS.Authorization.Roles;
using ICIMS.Authorization.Users;
using ICIMS.MultiTenancy;

namespace ICIMS.EntityFrameworkCore
{
    public class ICIMSDbContext : AbpZeroDbContext<Tenant, Role, User, ICIMSDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public ICIMSDbContext(DbContextOptions<ICIMSDbContext> options)
            : base(options)
        {
        }
    }
}
