
using AutoMapper;
using ICIMS.BusinessManages;
using ICIMS.BusinessManages.Dtos;

namespace ICIMS.BusinessManages.Mapper
{

	/// <summary>
    /// 配置Budget的AutoMapper
    /// </summary>
	internal static class BudgetMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap <Budget,BudgetListDto>();
            configuration.CreateMap <BudgetListDto,Budget>();

            configuration.CreateMap <BudgetEditDto,Budget>();
            configuration.CreateMap <Budget,BudgetEditDto>();

        }
	}
}
