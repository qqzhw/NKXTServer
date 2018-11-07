

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
    /// FundFrom领域层的业务管理
    ///</summary>
    public class FundFromManager :ICIMSDomainServiceBase, IFundFromManager
    {
		
		private readonly IRepository<FundFrom,int> _repository;

		/// <summary>
		/// FundFrom的构造方法
		///</summary>
		public FundFromManager(
			IRepository<FundFrom, int> repository
		)
		{
			_repository =  repository;
		}

        public Task CreateAsync(FundFrom fundFrom)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<FundFrom>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<FundFrom> GetAsync(int id)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// 初始化
        ///</summary>
        public void InitFundFrom()
		{
			throw new NotImplementedException();
		}

        public Task UpdateAsync(FundFrom fundFrom)
        {
            throw new NotImplementedException();
        }

        // TODO:编写领域业务代码







    }
}
