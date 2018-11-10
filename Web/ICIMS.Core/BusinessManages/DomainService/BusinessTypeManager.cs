

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
 


namespace ICIMS.BussinesManages.DomainService
{
    /// <summary>
    /// BusinessType领域层的业务管理
    ///</summary>
    public class BusinessTypeManager :ICIMSDomainServiceBase, IBusinessTypeManager
    {
		
		private readonly IRepository<BusinessType,int> _repository;

		/// <summary>
		/// BusinessType的构造方法
		///</summary>
		public BusinessTypeManager(
			IRepository<BusinessType, int> repository
		)
		{
			_repository =  repository;
		}


		/// <summary>
		/// 初始化
		///</summary>
		public void InitBusinessType()
		{
			throw new NotImplementedException();
		}

		// TODO:编写领域业务代码



		 
		  
		 

	}
}
