
using AutoMapper;
using ICIMS.BusinessManages;
using ICIMS.BusinessManages.Dtos;

namespace ICIMS.BusinessManages.Mapper
{

	/// <summary>
    /// 配置ItemDefine的AutoMapper
    /// </summary>
	internal   class ItemDefineMapper : Profile
    {
        public ItemDefineMapper()
        { 
      
            CreateMap<ItemDefine,ItemDefineListDto>();
            CreateMap<ItemDefineListDto,ItemDefine>();

            CreateMap<ItemDefineEditDto,ItemDefine>();
            CreateMap<ItemDefine,ItemDefineEditDto>();

        }
	}
}
