using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using ICIMS.Configuration;

namespace ICIMS.Web.Host.Startup
{
    [DependsOn(
       typeof(ICIMSWebCoreModule))]
    public class ICIMSWebHostModule: AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public ICIMSWebHostModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(ICIMSWebHostModule).GetAssembly());
        }
    }
}
