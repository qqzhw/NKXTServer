
using AutoMapper;
using ICIMS.BaseData;
using ICIMS.BaseData.Dtos;

namespace ICIMS.BaseData.Mapper
{

	/// <summary>
    /// 配置DocumentCategory的AutoMapper
    /// </summary>
	internal static class DocumentCategoryMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap <DocumentCategory,DocumentCategoryListDto>();
            configuration.CreateMap <DocumentCategoryListDto,DocumentCategory>();

            configuration.CreateMap <DocumentCategoryEditDto,DocumentCategory>();
            configuration.CreateMap <DocumentCategory,DocumentCategoryEditDto>();

        }
	}
}
