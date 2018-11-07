

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
    /// PaymentType领域层的业务管理
    ///</summary>
    public class PaymentTypeManager :ICIMSDomainServiceBase, IPaymentTypeManager
    {
		
		private readonly IRepository<PaymentType,int> _repository;

		/// <summary>
		/// PaymentType的构造方法
		///</summary>
		public PaymentTypeManager(
			IRepository<PaymentType, int> repository
		)
		{
			_repository =  repository;
		}


		/// <summary>
		/// 初始化
		///</summary>
		public void InitPaymentType()
		{
			throw new NotImplementedException();
		}

		// TODO:编写领域业务代码



		 
		  
		 

	}
}
