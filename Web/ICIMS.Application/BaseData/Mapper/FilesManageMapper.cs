
using AutoMapper;
using ICIMS.BaseData;
using ICIMS.BaseData.Dtos;

namespace ICIMS.BaseData.Mapper
{

	/// <summary>
    /// 配置FilesManage的AutoMapper
    /// </summary>
	internal static class FilesManageMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap <FilesManage,FilesManageListDto>();
            configuration.CreateMap <FilesManageListDto,FilesManage>();

            configuration.CreateMap <FilesManageEditDto,FilesManage>();
            configuration.CreateMap <FilesManage,FilesManageEditDto>();

        }
	}
}
