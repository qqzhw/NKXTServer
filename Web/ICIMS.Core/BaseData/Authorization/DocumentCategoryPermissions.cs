

namespace ICIMS.BaseData.Authorization
{
	/// <summary>
    /// 定义系统的权限名称的字符串常量。
    /// <see cref="DocumentCategoryAuthorizationProvider" />中对权限的定义.
    ///</summary>
	public static  class DocumentCategoryPermissions
	{
		/// <summary>
		/// DocumentCategory权限节点
		///</summary>
		public const string Node = "Pages.DocumentCategory";

		/// <summary>
		/// DocumentCategory查询授权
		///</summary>
		public const string Query = "Pages.DocumentCategory.Query";

		/// <summary>
		/// DocumentCategory创建权限
		///</summary>
		public const string Create = "Pages.DocumentCategory.Create";

		/// <summary>
		/// DocumentCategory修改权限
		///</summary>
		public const string Edit = "Pages.DocumentCategory.Edit";

		/// <summary>
		/// DocumentCategory删除权限
		///</summary>
		public const string Delete = "Pages.DocumentCategory.Delete";

        /// <summary>
		/// DocumentCategory批量删除权限
		///</summary>
		public const string BatchDelete = "Pages.DocumentCategory.BatchDelete";

		/// <summary>
		/// DocumentCategory导出Excel
		///</summary>
		public const string ExportExcel="Pages.DocumentCategory.ExportExcel";

		 
		 
         
    }

}

