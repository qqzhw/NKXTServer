
using AutoMapper;
using ICIMS.BusinessManages;
using ICIMS.BusinessManages.Dtos;

namespace ICIMS.BusinessManages.Mapper
{

	/// <summary>
    /// 配置PayAudit的AutoMapper
    /// </summary>
	internal   class PayAuditMapper : Profile
    {
        public PayAuditMapper()
        { 
            CreateMap<PayAudit,PayAuditListDto>();
            CreateMap<PayAuditListDto,PayAudit>();

            CreateMap<PayAuditEditDto,PayAudit>();
            CreateMap<PayAudit,PayAuditEditDto>();

        }
	}
}
