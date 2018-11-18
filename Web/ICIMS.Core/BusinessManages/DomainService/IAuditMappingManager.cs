

using System;
using System.Threading.Tasks;
using Abp;
using Abp.Domain.Services;
using ICIMS.BusinessManages;


namespace ICIMS.BusinessManages.DomainService
{
    public interface IAuditMappingManager : IDomainService
    {

        /// <summary>
        /// 初始化方法
        ///</summary>
        void InitAuditMapping();



		 
      
         

    }
}
