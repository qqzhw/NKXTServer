

namespace ICIMS.BaseData.Authorization
{
	/// <summary>
    /// 定义系统的权限名称的字符串常量。
    /// <see cref="FunctionSubjectAuthorizationProvider" />中对权限的定义.
    ///</summary>
	public static  class FunctionSubjectPermissions
	{
		/// <summary>
		/// FunctionSubject权限节点
		///</summary>
		public const string Node = "Pages.FunctionSubject";

		/// <summary>
		/// FunctionSubject查询授权
		///</summary>
		public const string Query = "Pages.FunctionSubject.Query";

		/// <summary>
		/// FunctionSubject创建权限
		///</summary>
		public const string Create = "Pages.FunctionSubject.Create";

		/// <summary>
		/// FunctionSubject修改权限
		///</summary>
		public const string Edit = "Pages.FunctionSubject.Edit";

		/// <summary>
		/// FunctionSubject删除权限
		///</summary>
		public const string Delete = "Pages.FunctionSubject.Delete";

        /// <summary>
		/// FunctionSubject批量删除权限
		///</summary>
		public const string BatchDelete = "Pages.FunctionSubject.BatchDelete";

		/// <summary>
		/// FunctionSubject导出Excel
		///</summary>
		public const string ExportExcel="Pages.FunctionSubject.ExportExcel";

		 
		 
         
    }

}

