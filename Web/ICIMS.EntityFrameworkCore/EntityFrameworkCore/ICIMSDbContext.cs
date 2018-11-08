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
using ICIMS.EntityMapper.ContractCategorys;
using ICIMS.EntityMapper.DocumentCategorys;
using ICIMS.EntityMapper.FilesManages;
using ICIMS.EntityMapper.FunctionSubjects;
using ICIMS.EntityMapper.ItemCategorys;
using ICIMS.EntityMapper.PaymentTypes;
using ICIMS.EntityMapper.Vendors;
using ICIMS.EntityMapper.FundFroms;

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
            modelBuilder.ApplyConfiguration(new FundFromCfg());
            modelBuilder.ApplyConfiguration(new BuyCategoryCfg());
            modelBuilder.ApplyConfiguration(new ContractCategoryCfg());
            modelBuilder.ApplyConfiguration(new DocumentCategoryCfg());
            modelBuilder.ApplyConfiguration(new FilesManageCfg());
            modelBuilder.ApplyConfiguration(new FunctionSubjectCfg());
            modelBuilder.ApplyConfiguration(new ItemCategoryCfg());
            modelBuilder.ApplyConfiguration(new PaymentTypeCfg());
            modelBuilder.ApplyConfiguration(new VendorCfg());
            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<BuyCategory> BuyCategorys { get; set; }


    }
}
