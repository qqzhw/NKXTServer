using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using ICIMS.Authorization;

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
