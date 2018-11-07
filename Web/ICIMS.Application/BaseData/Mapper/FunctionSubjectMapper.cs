
using AutoMapper;
using ICIMS.BaseData;
using ICIMS.BaseData.Dtos;

namespace ICIMS.BaseData.Mapper
{

	/// <summary>
    /// 配置FunctionSubject的AutoMapper
    /// </summary>
	internal static class FunctionSubjectMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap <FunctionSubject,FunctionSubjectListDto>();
            configuration.CreateMap <FunctionSubjectListDto,FunctionSubject>();

            configuration.CreateMap <FunctionSubjectEditDto,FunctionSubject>();
            configuration.CreateMap <FunctionSubject,FunctionSubjectEditDto>();

        }
	}
}
