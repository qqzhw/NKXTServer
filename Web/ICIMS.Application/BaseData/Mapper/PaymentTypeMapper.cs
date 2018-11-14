
using AutoMapper;
using ICIMS.BaseData;
using ICIMS.BaseData.Dtos;

namespace ICIMS.BaseData.Mapper
{

	/// <summary>
    /// 配置PaymentType的AutoMapper
    /// </summary>
	internal  class PaymentTypeMapper : Profile
    {
        public PaymentTypeMapper()
        { 
        
            CreateMap<PaymentType,PaymentTypeListDto>();
            CreateMap<PaymentTypeListDto,PaymentType>();

            CreateMap<PaymentTypeEditDto,PaymentType>();
            CreateMap<PaymentType,PaymentTypeEditDto>();

        }
	}
}
