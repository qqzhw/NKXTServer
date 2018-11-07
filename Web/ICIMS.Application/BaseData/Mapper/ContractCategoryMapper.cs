
using AutoMapper;
using ICIMS.BaseData;
using ICIMS.BaseData.Dtos;

namespace ICIMS.BaseData.Mapper
{

	/// <summary>
    /// 配置ContractCategory的AutoMapper
    /// </summary>
	internal static class ContractCategoryMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap <ContractCategory,ContractCategoryListDto>();
            configuration.CreateMap <ContractCategoryListDto,ContractCategory>();

            configuration.CreateMap <ContractCategoryEditDto,ContractCategory>();
            configuration.CreateMap <ContractCategory,ContractCategoryEditDto>();

        }
	}
}
