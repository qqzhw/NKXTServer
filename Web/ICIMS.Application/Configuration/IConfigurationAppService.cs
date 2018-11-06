using System.Threading.Tasks;
using ICIMS.Configuration.Dto;

namespace ICIMS.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
