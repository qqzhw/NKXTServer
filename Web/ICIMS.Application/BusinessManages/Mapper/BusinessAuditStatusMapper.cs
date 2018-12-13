
using AutoMapper;
using ICIMS.BusinessManages;
using ICIMS.BusinessManages.Dtos;

namespace ICIMS.BusinessManages.Mapper
{

	/// <summary>
    /// 配置BusinessAuditStatus的AutoMapper
    /// </summary>
	internal static class BusinessAuditStatusMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap <BusinessAuditStatus,BusinessAuditStatusListDto>();
            configuration.CreateMap <BusinessAuditStatusListDto,BusinessAuditStatus>();

            configuration.CreateMap <BusinessAuditStatusEditDto,BusinessAuditStatus>();
            configuration.CreateMap <BusinessAuditStatus,BusinessAuditStatusEditDto>();

        }
	}
}
