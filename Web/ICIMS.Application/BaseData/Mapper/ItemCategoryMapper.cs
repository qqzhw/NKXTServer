
using AutoMapper;
using ICIMS.BaseData;
using ICIMS.BaseData.Dtos;

namespace ICIMS.BaseData.Mapper
{

	/// <summary>
    /// 配置ItemCategory的AutoMapper
    /// </summary>
	internal   class ItemCategoryMapper : Profile
    {
        public ItemCategoryMapper()
        { 
        
            CreateMap<ItemCategory,ItemCategoryListDto>();
            CreateMap<ItemCategoryListDto,ItemCategory>();

            CreateMap<ItemCategoryEditDto,ItemCategory>();
            CreateMap<ItemCategory,ItemCategoryEditDto>();

        }
	}
}
