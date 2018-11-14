
using AutoMapper;
using ICIMS.BaseData;
using ICIMS.BaseData.Dtos;

namespace ICIMS.BaseData.Mapper
{

	/// <summary>
    /// 配置DocumentCategory的AutoMapper
    /// </summary>
	internal   class DocumentCategoryMapper : Profile
    {
        public DocumentCategoryMapper()
        { 
        
            CreateMap<DocumentCategory,DocumentCategoryListDto>();
            CreateMap<DocumentCategoryListDto,DocumentCategory>();

            CreateMap<DocumentCategoryEditDto,DocumentCategory>();
            CreateMap<DocumentCategory,DocumentCategoryEditDto>();

        }
	}
}
