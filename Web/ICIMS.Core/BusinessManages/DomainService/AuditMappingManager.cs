

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
    /// AuditMapping领域层的业务管理
    ///</summary>
    public class AuditMappingManager :ICIMSDomainServiceBase, IAuditMappingManager
    {
		
		private readonly IRepository<AuditMapping,int> _repository;

		/// <summary>
		/// AuditMapping的构造方法
		///</summary>
		public AuditMappingManager(
			IRepository<AuditMapping, int> repository
		)
		{
			_repository =  repository;
		}


		/// <summary>
		/// 初始化
		///</summary>
		public void InitAuditMapping()
		{
			throw new NotImplementedException();
		}

		// TODO:编写领域业务代码



		 
		  
		 

	}
}
