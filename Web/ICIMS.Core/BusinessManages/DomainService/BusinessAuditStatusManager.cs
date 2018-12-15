

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
using ICIMS.BusinessManages;


namespace ICIMS.BusinessManages.DomainService
{
    /// <summary>
    /// BusinessAuditStatus领域层的业务管理
    ///</summary>
    public class BusinessAuditStatusManager :ICIMSDomainServiceBase, IBusinessAuditStatusManager
    {
		
		private readonly IRepository<BusinessAuditStatus,int> _repository;

		/// <summary>
		/// BusinessAuditStatus的构造方法
		///</summary>
		public BusinessAuditStatusManager(
			IRepository<BusinessAuditStatus, int> repository
		)
		{
			_repository =  repository;
		}


		/// <summary>
		/// 初始化
		///</summary>
		public void InitBusinessAuditStatus()
		{
			throw new NotImplementedException();
		}

		// TODO:编写领域业务代码



		 
		  
		 

	}
}
