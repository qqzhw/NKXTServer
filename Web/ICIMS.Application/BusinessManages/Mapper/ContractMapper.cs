
using AutoMapper;
using ICIMS.BusinessManages;
using ICIMS.BusinessManages.Dtos;

namespace ICIMS.BusinessManages.Mapper
{

	/// <summary>
    /// 配置Contract的AutoMapper
    /// </summary>
	internal   class ContractMapper : Profile
    {
        public ContractMapper()
        { 
            CreateMap<Contract,ContractListDto>();
            CreateMap<ContractListDto,Contract>();

            CreateMap<ContractEditDto,Contract>();
            CreateMap<Contract,ContractEditDto>();

        }
	}
}
