using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using ICIMS.Configuration.Dto;

namespace ICIMS.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : ICIMSAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
