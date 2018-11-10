
using AutoMapper;
using ICIMS.BusinessManages;
using ICIMS.BusinessManages.Dtos;

namespace ICIMS.BusinessManages.Mapper
{

	/// <summary>
    /// 配置ReViewDefine的AutoMapper
    /// </summary>
	internal static class ReViewDefineMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap <ReViewDefine,ReViewDefineListDto>();
            configuration.CreateMap <ReViewDefineListDto,ReViewDefine>();

            configuration.CreateMap <ReViewDefineEditDto,ReViewDefine>();
            configuration.CreateMap <ReViewDefine,ReViewDefineEditDto>();

        }
	}
}
