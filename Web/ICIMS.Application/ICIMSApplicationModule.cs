using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using ICIMS.Authorization;
using ICIMS.BaseData.Authorization;
using ICIMS.BusinessManages.Authorization;

namespace ICIMS
{
    [DependsOn(
        typeof(ICIMSCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class ICIMSApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<ICIMSAuthorizationProvider>();
            Configuration.Authorization.Providers.Add<BuyCategoryAuthorizationProvider>();
            Configuration.Authorization.Providers.Add<ContractCategoryAuthorizationProvider>();
            Configuration.Authorization.Providers.Add<DocumentCategoryAuthorizationProvider>();
            Configuration.Authorization.Providers.Add<ProjectPropsAuthorizationProvider>();
            Configuration.Authorization.Providers.Add<FilesManageAuthorizationProvider>();
            Configuration.Authorization.Providers.Add<FunctionSubjectAuthorizationProvider>();
            Configuration.Authorization.Providers.Add<FundFromAuthorizationProvider>();
            Configuration.Authorization.Providers.Add<ItemCategoryAuthorizationProvider>();
            Configuration.Authorization.Providers.Add<PaymentTypeAuthorizationProvider>();
            Configuration.Authorization.Providers.Add<VendorAuthorizationProvider>();
            Configuration.Authorization.Providers.Add<YSCategoryAuthorizationProvider>();
            Configuration.Authorization.Providers.Add<BudgetAuthorizationProvider>();
            Configuration.Authorization.Providers.Add<BusinessAuditAuthorizationProvider>();
            Configuration.Authorization.Providers.Add<BusinessTypeAuthorizationProvider>();
            Configuration.Authorization.Providers.Add<ContractAuthorizationProvider>();
            Configuration.Authorization.Providers.Add<ItemDefineAuthorizationProvider>();
            Configuration.Authorization.Providers.Add<PayAuditAuthorizationProvider>();
            Configuration.Authorization.Providers.Add<ReViewDefineAuthorizationProvider>();
            Configuration.Authorization.Providers.Add<AuditMappingAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(ICIMSApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddProfiles(thisAssembly)
            );
        }
    }
}
