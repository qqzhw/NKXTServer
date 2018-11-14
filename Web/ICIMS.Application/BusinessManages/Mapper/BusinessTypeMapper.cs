
using AutoMapper; 
using ICIMS.BussinesManages.Dtos;

namespace ICIMS.BussinesManages.Mapper
{

	/// <summary>
    /// 配置BusinessType的AutoMapper
    /// </summary>
	internal   class BusinessTypeMapper : Profile
    {
        public BusinessTypeMapper()
        { 
        
            CreateMap<BusinessType,BusinessTypeListDto>();
            CreateMap<BusinessTypeListDto,BusinessType>();

            CreateMap<BusinessTypeEditDto,BusinessType>();
            CreateMap<BusinessType,BusinessTypeEditDto>();

        }
	}
}
