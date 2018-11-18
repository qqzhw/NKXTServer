
using AutoMapper;
using ICIMS.BusinessManages;
using ICIMS.BusinessManages.Dtos;

namespace ICIMS.BusinessManages.Mapper
{

	/// <summary>
    /// 配置BuinessAudit的AutoMapper
    /// </summary>
	internal static class BuinessAuditMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap <BuinessAudit,BuinessAuditListDto>();
            configuration.CreateMap <BuinessAuditListDto,BuinessAudit>();

            configuration.CreateMap <BuinessAuditEditDto,BuinessAudit>();
            configuration.CreateMap <BuinessAudit,BuinessAuditEditDto>();

        }
	}
}
