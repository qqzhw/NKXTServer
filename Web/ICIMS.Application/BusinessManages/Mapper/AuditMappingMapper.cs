
using AutoMapper;
using ICIMS.BusinessManages;
using ICIMS.BusinessManages.Dtos;

namespace ICIMS.BusinessManages.Mapper
{

	/// <summary>
    /// 配置AuditMapping的AutoMapper
    /// </summary>
	internal static class AuditMappingMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap <AuditMapping,AuditMappingListDto>();
            configuration.CreateMap <AuditMappingListDto,AuditMapping>();

            configuration.CreateMap <AuditMappingEditDto,AuditMapping>();
            configuration.CreateMap <AuditMapping,AuditMappingEditDto>();

        }
	}
}
