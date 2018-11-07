

namespace ICIMS.BaseData.Authorization
{
	/// <summary>
    /// 定义系统的权限名称的字符串常量。
    /// <see cref="ContractCategoryAuthorizationProvider" />中对权限的定义.
    ///</summary>
	public static  class ContractCategoryPermissions
	{
		/// <summary>
		/// ContractCategory权限节点
		///</summary>
		public const string Node = "Pages.ContractCategory";

		/// <summary>
		/// ContractCategory查询授权
		///</summary>
		public const string Query = "Pages.ContractCategory.Query";

		/// <summary>
		/// ContractCategory创建权限
		///</summary>
		public const string Create = "Pages.ContractCategory.Create";

		/// <summary>
		/// ContractCategory修改权限
		///</summary>
		public const string Edit = "Pages.ContractCategory.Edit";

		/// <summary>
		/// ContractCategory删除权限
		///</summary>
		public const string Delete = "Pages.ContractCategory.Delete";

        /// <summary>
		/// ContractCategory批量删除权限
		///</summary>
		public const string BatchDelete = "Pages.ContractCategory.BatchDelete";

		/// <summary>
		/// ContractCategory导出Excel
		///</summary>
		public const string ExportExcel="Pages.ContractCategory.ExportExcel";

		 
		 
         
    }

}

