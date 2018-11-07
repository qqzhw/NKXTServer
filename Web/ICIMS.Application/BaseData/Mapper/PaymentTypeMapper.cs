
using AutoMapper;
using ICIMS.BaseData;
using ICIMS.BaseData.Dtos;

namespace ICIMS.BaseData.Mapper
{

	/// <summary>
    /// 配置PaymentType的AutoMapper
    /// </summary>
	internal static class PaymentTypeMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap <PaymentType,PaymentTypeListDto>();
            configuration.CreateMap <PaymentTypeListDto,PaymentType>();

            configuration.CreateMap <PaymentTypeEditDto,PaymentType>();
            configuration.CreateMap <PaymentType,PaymentTypeEditDto>();

        }
	}
}
