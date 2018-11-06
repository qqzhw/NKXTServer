using System.Threading.Tasks;
using Abp.Application.Services;
using ICIMS.Sessions.Dto;

namespace ICIMS.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
