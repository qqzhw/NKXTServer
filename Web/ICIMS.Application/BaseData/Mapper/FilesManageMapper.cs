
using AutoMapper;
using ICIMS.BaseData;
using ICIMS.BaseData.Dtos;

namespace ICIMS.BaseData.Mapper
{

	/// <summary>
    /// 配置FilesManage的AutoMapper
    /// </summary>
	internal  class FilesManageMapper : Profile
    {
        public FilesManageMapper()
        { 
         
            CreateMap<FilesManage,FilesManageListDto>();
            CreateMap<FilesManageListDto,FilesManage>();

            CreateMap<FilesManageEditDto,FilesManage>();
            CreateMap<FilesManage,FilesManageEditDto>();
            CreateMap<FilesManageInput, FilesManage>();
            CreateMap<FilesManage, FilesManageInput>();
        }
	}
}
