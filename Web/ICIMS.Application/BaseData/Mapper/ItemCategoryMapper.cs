
using AutoMapper;
using ICIMS.BaseData;
using ICIMS.BaseData.Dtos;

namespace ICIMS.BaseData.Mapper
{

	/// <summary>
    /// 配置ItemCategory的AutoMapper
    /// </summary>
	internal static class ItemCategoryMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap <ItemCategory,ItemCategoryListDto>();
            configuration.CreateMap <ItemCategoryListDto,ItemCategory>();

            configuration.CreateMap <ItemCategoryEditDto,ItemCategory>();
            configuration.CreateMap <ItemCategory,ItemCategoryEditDto>();

        }
	}
}
