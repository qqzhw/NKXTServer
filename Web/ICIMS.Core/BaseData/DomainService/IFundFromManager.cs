

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp;
using Abp.Domain.Services;
using ICIMS.BaseData;


namespace ICIMS.BaseData.DomainService
{
    public interface IFundFromManager : IDomainService
    {

        /// <summary>
        /// 初始化方法
        ///</summary>
        void InitFundFrom();

        Task<FundFrom> GetAsync(int id);

        Task CreateAsync(FundFrom fundFrom);

        Task UpdateAsync(FundFrom fundFrom);

        Task DeleteAsync(int id);
         
        Task<IList<FundFrom>> GetAllAsync();
         

    }
}
