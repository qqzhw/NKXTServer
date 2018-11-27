
using AutoMapper;
using ICIMS.BusinessManages;
using ICIMS.BusinessManages.Dtos;

namespace ICIMS.BusinessManages.Mapper
{

	/// <summary>
    /// 配置PayAuditDetail的AutoMapper
    /// </summary>
	internal static class PayAuditDetailMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap <PayAuditDetail,PayAuditDetailListDto>();
            configuration.CreateMap <PayAuditDetailListDto,PayAuditDetail>();

            configuration.CreateMap <PayAuditDetailEditDto,PayAuditDetail>();
            configuration.CreateMap <PayAuditDetail,PayAuditDetailEditDto>();

        }
	}
}
