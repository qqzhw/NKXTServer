
using AutoMapper;
using ICIMS.BaseData;
using ICIMS.BaseData.Dtos;

namespace ICIMS.BaseData.Mapper
{

	/// <summary>
    /// 配置YSCategory的AutoMapper
    /// </summary>
	internal  class YSCategoryMapper : Profile
    {
        public YSCategoryMapper()
        {
             
            CreateMap<YSCategory,YSCategoryListDto>();
            CreateMap<YSCategoryListDto,YSCategory>();

            CreateMap<YSCategoryEditDto,YSCategory>();
            CreateMap<YSCategory,YSCategoryEditDto>();

        }
	}
}
