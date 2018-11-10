

namespace ICIMS.BusinessManages.Authorization
{
	/// <summary>
    /// 定义系统的权限名称的字符串常量。
    /// <see cref="ContractAuthorizationProvider" />中对权限的定义.
    ///</summary>
	public static  class ContractPermissions
	{
		/// <summary>
		/// Contract权限节点
		///</summary>
		public const string Node = "Pages.Contract";

		/// <summary>
		/// Contract查询授权
		///</summary>
		public const string Query = "Pages.Contract.Query";

		/// <summary>
		/// Contract创建权限
		///</summary>
		public const string Create = "Pages.Contract.Create";

		/// <summary>
		/// Contract修改权限
		///</summary>
		public const string Edit = "Pages.Contract.Edit";

		/// <summary>
		/// Contract删除权限
		///</summary>
		public const string Delete = "Pages.Contract.Delete";

        /// <summary>
		/// Contract批量删除权限
		///</summary>
		public const string BatchDelete = "Pages.Contract.BatchDelete";

		/// <summary>
		/// Contract导出Excel
		///</summary>
		public const string ExportExcel="Pages.Contract.ExportExcel";

		 
		 
         
    }

}

