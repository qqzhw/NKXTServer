

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
    /// PayAuditDetail领域层的业务管理
    ///</summary>
    public class PayAuditDetailManager :ICIMSDomainServiceBase, IPayAuditDetailManager
    {
		
		private readonly IRepository<PayAuditDetail,int> _repository;

		/// <summary>
		/// PayAuditDetail的构造方法
		///</summary>
		public PayAuditDetailManager(
			IRepository<PayAuditDetail, int> repository
		)
		{
			_repository =  repository;
		}


		/// <summary>
		/// 初始化
		///</summary>
		public void InitPayAuditDetail()
		{
			throw new NotImplementedException();
		}

		// TODO:编写领域业务代码



		 
		  
		 

	}
}
