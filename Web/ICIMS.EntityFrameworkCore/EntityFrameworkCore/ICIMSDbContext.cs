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
using ICIMS.EntityMapper.YSCategorys;
using ICIMS.EntityMapper.ItemDefines;
using ICIMS.EntityMapper.Budgets;
using ICIMS.EntityMapper.Contracts;
using ICIMS.EntityMapper.PayAudits;
using ICIMS.EntityMapper.ReViewDefines;
using ICIMS.BusinessManages;
using ICIMS.EntityMapper.AuditMappings;
using ICIMS.EntityMapper.BuinessAudits;
using ICIMS.EntityMapper.BusinessTypes;

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
            modelBuilder.ApplyConfiguration(new YSCategoryCfg());
            modelBuilder.ApplyConfiguration(new ItemDefineCfg());
            modelBuilder.ApplyConfiguration(new ReViewDefineCfg());
            modelBuilder.ApplyConfiguration(new BudgetCfg());
            modelBuilder.ApplyConfiguration(new ContractCfg());
            modelBuilder.ApplyConfiguration(new PayAuditCfg());
            modelBuilder.ApplyConfiguration(new BusinessAuditCfg());
            modelBuilder.ApplyConfiguration(new AuditMappingCfg());
            modelBuilder.ApplyConfiguration(new BusinessTypeCfg());

            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<BuyCategory> BuyCategorys { get; set; }
        public virtual DbSet<YSCategory> YSCategory { get; set; }
        public virtual DbSet<FundFrom> FundFrom { get; set; }
        public virtual DbSet<ContractCategory> ContractCategory { get; set; }

        public virtual DbSet<DocumentCategory> DocumentCategory { get; set; }
        public virtual DbSet<FilesManage> FilesManage { get; set; }

        public virtual DbSet<ItemCategory> ItemCategory { get; set; }

        public virtual DbSet<FunctionSubject> FunctionSubject { get; set; }
        public virtual DbSet<PaymentType> PaymentTypes { get; set; }

        public virtual DbSet<Vendor> Vendor { get; set; }
        public virtual DbSet<ItemDefine> ItemDefine { get; set; }
        public virtual DbSet<ReViewDefine> ReViewDefine { get; set; }
        public virtual DbSet<Budget> Budget { get; set; }
        public virtual DbSet<Contract> Contract { get; set; }
        public virtual DbSet<PayAudit> PayAudit { get; set; }
        public virtual DbSet<BusinessAudit> BusinessAudit { get; set; }
        public virtual DbSet<AuditMapping> AuditMapping { get; set; }
        public virtual DbSet<BusinessType> BusinessType { get; set; }
         
    }
}
