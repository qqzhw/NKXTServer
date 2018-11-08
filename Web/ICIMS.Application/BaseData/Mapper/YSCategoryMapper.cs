
using AutoMapper;
using ICIMS.BaseData;
using ICIMS.BaseData.Dtos;

namespace ICIMS.BaseData.Mapper
{

	/// <summary>
    /// 配置YSCategory的AutoMapper
    /// </summary>
	internal static class YSCategoryMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap <YSCategory,YSCategoryListDto>();
            configuration.CreateMap <YSCategoryListDto,YSCategory>();

            configuration.CreateMap <YSCategoryEditDto,YSCategory>();
            configuration.CreateMap <YSCategory,YSCategoryEditDto>();

        }
	}
}
