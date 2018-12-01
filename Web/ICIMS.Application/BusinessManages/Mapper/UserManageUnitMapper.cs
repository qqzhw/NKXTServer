
using AutoMapper;
using ICIMS.BusinessManages;
using ICIMS.BusinessManages.Dtos;

namespace ICIMS.BusinessManages.Mapper
{

	/// <summary>
    /// 配置UserManageUnit的AutoMapper
    /// </summary>
	internal   class UserManageUnitMapper: Profile
    {
        public UserManageUnitMapper()
        { 
            CreateMap <UserManageUnit,UserManageUnitListDto>();
            CreateMap <UserManageUnitListDto,UserManageUnit>();

            CreateMap <UserManageUnitEditDto,UserManageUnit>();
            CreateMap <UserManageUnit,UserManageUnitEditDto>();

        }
	}
}
