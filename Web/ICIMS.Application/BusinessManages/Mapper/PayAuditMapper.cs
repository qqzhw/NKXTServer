
using AutoMapper;
using ICIMS.BusinessManages;
using ICIMS.BusinessManages.Dtos;

namespace ICIMS.BusinessManages.Mapper
{

	/// <summary>
    /// 配置PayAudit的AutoMapper
    /// </summary>
	internal static class PayAuditMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap <PayAudit,PayAuditListDto>();
            configuration.CreateMap <PayAuditListDto,PayAudit>();

            configuration.CreateMap <PayAuditEditDto,PayAudit>();
            configuration.CreateMap <PayAudit,PayAuditEditDto>();

        }
	}
}
