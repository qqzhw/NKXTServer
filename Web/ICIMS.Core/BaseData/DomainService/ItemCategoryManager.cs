

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
    /// ItemCategory领域层的业务管理
    ///</summary>
    public class ItemCategoryManager :ICIMSDomainServiceBase, IItemCategoryManager
    {
		
		private readonly IRepository<ItemCategory,int> _repository;

		/// <summary>
		/// ItemCategory的构造方法
		///</summary>
		public ItemCategoryManager(
			IRepository<ItemCategory, int> repository
		)
		{
			_repository =  repository;
		}


		/// <summary>
		/// 初始化
		///</summary>
		public void InitItemCategory()
		{
			throw new NotImplementedException();
		}

		// TODO:编写领域业务代码



		 
		  
		 

	}
}
