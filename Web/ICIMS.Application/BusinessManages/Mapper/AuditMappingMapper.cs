
using AutoMapper;
using ICIMS.BusinessManages;
using ICIMS.BusinessManages.Dtos;

namespace ICIMS.BusinessManages.Mapper
{

	/// <summary>
    /// 配置AuditMapping的AutoMapper
    /// </summary>
	public partial  class AuditMappingMapper:Profile
    {
        public AuditMappingMapper()
        {
            CreateMap<AuditMapping, AuditMappingListDto>()
             .ForMember(model => model.BusinessTypeName, options => options.MapFrom(o => o.BusinessAudit.BusinessTypeName))
                .ForMember(model => model.RoleName, options => options.MapFrom(o => o.BusinessAudit.Name))
                .ForMember(model => model.RoleId, options => options.MapFrom(o => o.BusinessAudit.RoleId))
                .ForMember(model => model.AuditUserName, options =>options.MapFrom(o=>o.User.Name));
            CreateMap <AuditMappingListDto,AuditMapping>()
                .ForMember(model => model.BusinessAudit, options => options.Ignore())
                .ForMember(model => model.User, options => options.Ignore());

            CreateMap<AuditMappingEditDto, AuditMapping>();
            CreateMap<AuditMapping, AuditMappingEditDto>();
              

        }
	}
}
