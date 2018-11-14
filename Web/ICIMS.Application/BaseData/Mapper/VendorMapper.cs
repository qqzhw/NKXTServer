
using AutoMapper;
using ICIMS.BaseData;
using ICIMS.BaseData.Dtos;

namespace ICIMS.BaseData.Mapper
{

	/// <summary>
    /// 配置Vendor的AutoMapper
    /// </summary>
	internal  class VendorMapper : Profile
    {
        public VendorMapper()
        { 
       
            CreateMap<Vendor,VendorListDto>();
            CreateMap<VendorListDto,Vendor>();

            CreateMap<VendorEditDto,Vendor>();
            CreateMap<Vendor,VendorEditDto>();

        }
	}
}
