
using AutoMapper; 
using ICIMS.BussinesManages.Dtos;

namespace ICIMS.BussinesManages.Mapper
{

	/// <summary>
    /// 配置BusinessType的AutoMapper
    /// </summary>
	internal static class BusinessTypeMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap <BusinessType,BusinessTypeListDto>();
            configuration.CreateMap <BusinessTypeListDto,BusinessType>();

            configuration.CreateMap <BusinessTypeEditDto,BusinessType>();
            configuration.CreateMap <BusinessType,BusinessTypeEditDto>();

        }
	}
}
