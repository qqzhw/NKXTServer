
using AutoMapper;
using ICIMS.BusinessManages;
using ICIMS.BusinessManages.Dtos;

namespace ICIMS.BusinessManages.Mapper
{

	/// <summary>
    /// 配置BusinessAudit的AutoMapper
    /// </summary>
	internal static class BusinessAuditMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap <BusinessAudit,BusinessAuditListDto>();
            configuration.CreateMap <BusinessAuditListDto,BusinessAudit>();

            configuration.CreateMap <BusinessAuditEditDto,BusinessAudit>();
            configuration.CreateMap <BusinessAudit,BusinessAuditEditDto>();

        }
	}
}
