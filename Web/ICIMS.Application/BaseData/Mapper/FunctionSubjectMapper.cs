
using AutoMapper;
using ICIMS.BaseData;
using ICIMS.BaseData.Dtos;

namespace ICIMS.BaseData.Mapper
{

	/// <summary>
    /// 配置FunctionSubject的AutoMapper
    /// </summary>
	internal   class FunctionSubjectMapper : Profile
    {
        public FunctionSubjectMapper()
        { 
            CreateMap<FunctionSubject,FunctionSubjectListDto>();
            CreateMap<FunctionSubjectListDto,FunctionSubject>();

            CreateMap<FunctionSubjectEditDto,FunctionSubject>();
            CreateMap<FunctionSubject,FunctionSubjectEditDto>();

        }
	}
}
