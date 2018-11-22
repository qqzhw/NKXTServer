
using AutoMapper;
using ICIMS.BusinessManages;
using ICIMS.BusinessManages.Dtos;

namespace ICIMS.BusinessManages.Mapper
{

	/// <summary>
    /// 配置BusinessAudit的AutoMapper
    /// </summary>
	public partial class BusinessAuditMapper: Profile
    {
        public BusinessAuditMapper()
        { 
       
             CreateMap <BusinessAudit,BusinessAuditListDto>();
             CreateMap <BusinessAuditListDto,BusinessAudit>();

            CreateMap <BusinessAuditEditDto,BusinessAudit>();
            CreateMap <BusinessAudit,BusinessAuditEditDto>();

        }
	}
}
