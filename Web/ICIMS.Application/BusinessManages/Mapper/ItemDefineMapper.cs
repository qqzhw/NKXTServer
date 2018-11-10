
using AutoMapper;
using ICIMS.BusinessManages;
using ICIMS.BusinessManages.Dtos;

namespace ICIMS.BusinessManages.Mapper
{

	/// <summary>
    /// 配置ItemDefine的AutoMapper
    /// </summary>
	internal static class ItemDefineMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap <ItemDefine,ItemDefineListDto>();
            configuration.CreateMap <ItemDefineListDto,ItemDefine>();

            configuration.CreateMap <ItemDefineEditDto,ItemDefine>();
            configuration.CreateMap <ItemDefine,ItemDefineEditDto>();

        }
	}
}
