
using AutoMapper;
using ICIMS.BaseData;
using ICIMS.BaseData.Dtos;

namespace ICIMS.BaseData.Mapper
{

	/// <summary>
    /// 配置ContractCategory的AutoMapper
    /// </summary>
	internal   class ContractCategoryMapper : Profile
    {
        public ContractCategoryMapper()
        { 
        
            CreateMap<ContractCategory,ContractCategoryListDto>();
            CreateMap<ContractCategoryListDto,ContractCategory>();

            CreateMap<ContractCategoryEditDto,ContractCategory>();
            CreateMap<ContractCategory,ContractCategoryEditDto>();

        }
	}
}
