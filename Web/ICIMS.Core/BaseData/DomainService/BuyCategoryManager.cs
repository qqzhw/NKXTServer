

using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Abp.Linq;
using Abp.Linq.Extensions;
using Abp.Extensions;
using Abp.UI;
using Abp.Domain.Repositories;
using Abp.Domain.Services;

using ICIMS;
using ICIMS.BaseData;


namespace ICIMS.BaseData.DomainService
{
    /// <summary>
    /// BuyCategory领域层的业务管理
    ///</summary>
    public class BuyCategoryManager :ICIMSDomainServiceBase, IBuyCategoryManager
    {
		
		private readonly IRepository<BuyCategory,int> _repository;

		/// <summary>
		/// BuyCategory的构造方法
		///</summary>
		public BuyCategoryManager(
			IRepository<BuyCategory, int> repository
		)
		{
			_repository =  repository;
		}

         
       

        public Task CreateAsync(BuyCategory buyCategory)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<BuyCategory>> GetAllAsync(BuyCategory buyCategory)
        {
            throw new NotImplementedException();
        }

       

        public Task<BuyCategory> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        


        /// <summary>
        /// 初始化
        ///</summary>
        public void InitBuyCategory()
		{
			throw new NotImplementedException();
		}

       

        public Task UpdateAsync(BuyCategory buyCategory)
        {
            throw new NotImplementedException();
        }

        // TODO:编写领域业务代码







    }
}
