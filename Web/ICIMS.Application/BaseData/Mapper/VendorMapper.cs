
using AutoMapper;
using ICIMS.BaseData;
using ICIMS.BaseData.Dtos;

namespace ICIMS.BaseData.Mapper
{

	/// <summary>
    /// 配置Vendor的AutoMapper
    /// </summary>
	internal static class VendorMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap <Vendor,VendorListDto>();
            configuration.CreateMap <VendorListDto,Vendor>();

            configuration.CreateMap <VendorEditDto,Vendor>();
            configuration.CreateMap <Vendor,VendorEditDto>();

        }
	}
}
