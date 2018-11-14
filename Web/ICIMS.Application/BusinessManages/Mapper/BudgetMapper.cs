
using AutoMapper;
using ICIMS.BusinessManages;
using ICIMS.BusinessManages.Dtos;

namespace ICIMS.BusinessManages.Mapper
{

    /// <summary>
    /// 配置Budget的AutoMapper
    /// </summary>
    public partial  class BudgetMapper : Profile
    {
        public BudgetMapper()
        {
            CreateMap<Budget, BudgetListDto>();
            CreateMap<BudgetListDto, Budget>();

            CreateMap<BudgetEditDto, Budget>()
                .ForMember(model => model.YsCategory, options => options.Ignore())
                .ForMember(model => model.Unit, options => options.Ignore())
                .ForMember(model => model.BuyCategory, options => options.Ignore())
                .ForMember(model => model.FunctionSubject, options => options.Ignore())
                .ForMember(model => model.DeleterUserId, options => options.Ignore())
                .ForMember(model => model.DeletionTime, options => options.Ignore())
                //.ForMember(model => model.IsDeleted, options => options.Ignore())
                .ForMember(model => model.LastModificationTime, options => options.Ignore())
                .ForMember(model => model.LastModifierUserId, options => options.Ignore())
                .ForMember(model => model.CreationTime, options => options.Ignore())
                .ForMember(model => model.CreatorUserId, options => options.Ignore());


            CreateMap<Budget, BudgetEditDto>();
        }
    }
}
