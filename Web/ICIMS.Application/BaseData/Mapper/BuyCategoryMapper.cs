
using AutoMapper;
using ICIMS.BaseData;
using ICIMS.BaseData.Dtos;

namespace ICIMS.BaseData.Mapper
{

	/// <summary>
    /// 配置BuyCategory的AutoMapper
    /// </summary>
	public partial class BuyCategoryMapper:Profile
    {
        public BuyCategoryMapper()
        {
            CreateMap<BuyCategory, BuyCategoryListDto>();
            CreateMap<BuyCategoryListDto, BuyCategory>();

            CreateMap<BuyCategoryEditDto, BuyCategory>();
            CreateMap<BuyCategory, BuyCategoryEditDto>();
        }
        
	}
}
