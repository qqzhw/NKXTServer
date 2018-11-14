
using AutoMapper;
using ICIMS.BaseData;
using ICIMS.BaseData.Dtos;

namespace ICIMS.BaseData.Mapper
{

	/// <summary>
    /// 配置FundFrom的AutoMapper
    /// </summary>
	internal  class FundFromMapper : Profile
    {
        public FundFromMapper()
        { 
            CreateMap<FundFrom,FundFromListDto>();
            CreateMap<FundFromListDto,FundFrom>();

            CreateMap<FundFromEditDto,FundFrom>();
            CreateMap<FundFrom,FundFromEditDto>();

        }
	}
}
