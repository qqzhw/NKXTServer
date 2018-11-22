
using AutoMapper;
using ICIMS.BusinessManages;
using ICIMS.BusinessManages.Dtos;

namespace ICIMS.BusinessManages.Mapper
{

	/// <summary>
    /// 配置BusinessType的AutoMapper
    /// </summary>
	public partial class BusinessTypeMapper:Profile
    {
        public BusinessTypeMapper()
        { 
       
            CreateMap <BusinessType,BusinessTypeListDto>();
            CreateMap <BusinessTypeListDto,BusinessType>();

            CreateMap <BusinessTypeEditDto,BusinessType>();
            CreateMap <BusinessType,BusinessTypeEditDto>();

        }
	}
}
