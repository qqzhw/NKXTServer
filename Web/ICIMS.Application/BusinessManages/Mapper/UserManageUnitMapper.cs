
using AutoMapper;
using ICIMS.BusinessManages;
using ICIMS.BusinessManages.Dtos;

namespace ICIMS.BusinessManages.Mapper
{

	/// <summary>
    /// 配置UserManageUnit的AutoMapper
    /// </summary>
	internal static class UserManageUnitMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap <UserManageUnit,UserManageUnitListDto>();
            configuration.CreateMap <UserManageUnitListDto,UserManageUnit>();

            configuration.CreateMap <UserManageUnitEditDto,UserManageUnit>();
            configuration.CreateMap <UserManageUnit,UserManageUnitEditDto>();

        }
	}
}
