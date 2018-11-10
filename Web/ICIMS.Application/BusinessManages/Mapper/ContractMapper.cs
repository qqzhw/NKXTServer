
using AutoMapper;
using ICIMS.BusinessManages;
using ICIMS.BusinessManages.Dtos;

namespace ICIMS.BusinessManages.Mapper
{

	/// <summary>
    /// 配置Contract的AutoMapper
    /// </summary>
	internal static class ContractMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap <Contract,ContractListDto>();
            configuration.CreateMap <ContractListDto,Contract>();

            configuration.CreateMap <ContractEditDto,Contract>();
            configuration.CreateMap <Contract,ContractEditDto>();

        }
	}
}
