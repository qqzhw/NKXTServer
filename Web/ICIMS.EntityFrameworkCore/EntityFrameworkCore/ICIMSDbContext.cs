using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using ICIMS.Authorization.Roles;
using ICIMS.Authorization.Users;
using ICIMS.MultiTenancy;
using ICIMS.EntityMapper.BuyCategorys;
using System.Reflection;
using System.Linq;
using System;
using ICIMS.BaseData;

namespace ICIMS.EntityFrameworkCore
{
    public class ICIMSDbContext : AbpZeroDbContext<Tenant, Role, User, ICIMSDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public ICIMSDbContext(DbContextOptions<ICIMSDbContext> options)
            : base(options)
        {
             
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //dynamically load all entity and query type configurations
            var typeConfigurations = Assembly.GetExecutingAssembly().GetTypes().Where(type =>
                (type.BaseType?.IsGenericType ?? false)
                    && (type.BaseType.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>)
                        || type.BaseType.GetGenericTypeDefinition() == typeof(IQueryTypeConfiguration<>)));

            //foreach (var typeConfiguration in typeConfigurations)
            //{
            //    var configuration = Activator.CreateInstance(typeConfiguration);
            //    configuration.ApplyConfiguration(modelBuilder);
            //}
            modelBuilder.ApplyConfiguration(new BuyCategoryCfg());

            base.OnModelCreating(modelBuilder);
        }
        
    }
}
