

namespace ICIMS.BusinessManages.Authorization
{
	/// <summary>
    /// 定义系统的权限名称的字符串常量。
    /// <see cref="BudgetAuthorizationProvider" />中对权限的定义.
    ///</summary>
	public static  class BudgetPermissions
	{
		/// <summary>
		/// Budget权限节点
		///</summary>
		public const string Node = "Pages.Budget";

		/// <summary>
		/// Budget查询授权
		///</summary>
		public const string Query = "Pages.Budget.Query";

		/// <summary>
		/// Budget创建权限
		///</summary>
		public const string Create = "Pages.Budget.Create";

		/// <summary>
		/// Budget修改权限
		///</summary>
		public const string Edit = "Pages.Budget.Edit";

		/// <summary>
		/// Budget删除权限
		///</summary>
		public const string Delete = "Pages.Budget.Delete";

        /// <summary>
		/// Budget批量删除权限
		///</summary>
		public const string BatchDelete = "Pages.Budget.BatchDelete";

		/// <summary>
		/// Budget导出Excel
		///</summary>
		public const string ExportExcel="Pages.Budget.ExportExcel";

		 
		 
         
    }

}

