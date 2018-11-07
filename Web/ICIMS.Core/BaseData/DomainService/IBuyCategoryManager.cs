

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp;
using Abp.Domain.Services;
using ICIMS.Authorization.Users;
using ICIMS.BaseData;


namespace ICIMS.BaseData.DomainService
{
    public interface IBuyCategoryManager : IDomainService
    {

        /// <summary>
        /// 初始化方法
        ///</summary>
        void InitBuyCategory();


        Task<BuyCategory> GetAsync(int id);

        Task CreateAsync(BuyCategory buyCategory);

        Task UpdateAsync(BuyCategory buyCategory);

        Task DeleteAsync(int id);

       

        Task<IReadOnlyList<BuyCategory>> GetAllAsync(BuyCategory buyCategory);




    }
}
