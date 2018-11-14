
using AutoMapper;
using ICIMS.BusinessManages;
using ICIMS.BusinessManages.Dtos;

namespace ICIMS.BusinessManages.Mapper
{

	/// <summary>
    /// 配置ReViewDefine的AutoMapper
    /// </summary>
	internal   class ReViewDefineMapper : Profile
    {
        public ReViewDefineMapper()
        { 
            CreateMap<ReViewDefine,ReViewDefineListDto>();
            CreateMap<ReViewDefineListDto,ReViewDefine>();

            CreateMap<ReViewDefineEditDto,ReViewDefine>();
            CreateMap<ReViewDefine,ReViewDefineEditDto>();

        }
	}
}
