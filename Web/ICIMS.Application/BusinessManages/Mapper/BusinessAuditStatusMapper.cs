
using AutoMapper;
using ICIMS.BusinessManages;
using ICIMS.BusinessManages.Dtos;

namespace ICIMS.BusinessManages.Mapper
{

	/// <summary>
    /// 配置BusinessAuditStatus的AutoMapper
    /// </summary>
	public partial class BusinessAuditStatusMapper : Profile
    {
        public BusinessAuditStatusMapper()
        {

            CreateMap<BusinessAuditStatus, BusinessAuditStatusListDto>();
            CreateMap<BusinessAuditStatusListDto, BusinessAuditStatus>();

            CreateMap<BusinessAuditStatusEditDto, BusinessAuditStatus>();
            CreateMap<BusinessAuditStatus, BusinessAuditStatusEditDto>();

        }
    }
     
}
