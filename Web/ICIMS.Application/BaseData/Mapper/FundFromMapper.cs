
using AutoMapper;
using ICIMS.BaseData;
using ICIMS.BaseData.Dtos;

namespace ICIMS.BaseData.Mapper
{

	/// <summary>
    /// 配置FundFrom的AutoMapper
    /// </summary>
	internal static class FundFromMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap <FundFrom,FundFromListDto>();
            configuration.CreateMap <FundFromListDto,FundFrom>();

            configuration.CreateMap <FundFromEditDto,FundFrom>();
            configuration.CreateMap <FundFrom,FundFromEditDto>();

        }
	}
}
