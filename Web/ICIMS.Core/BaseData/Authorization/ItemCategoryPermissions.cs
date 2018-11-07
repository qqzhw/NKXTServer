

namespace ICIMS.BaseData.Authorization
{
	/// <summary>
    /// 定义系统的权限名称的字符串常量。
    /// <see cref="ItemCategoryAuthorizationProvider" />中对权限的定义.
    ///</summary>
	public static  class ItemCategoryPermissions
	{
		/// <summary>
		/// ItemCategory权限节点
		///</summary>
		public const string Node = "Pages.ItemCategory";

		/// <summary>
		/// ItemCategory查询授权
		///</summary>
		public const string Query = "Pages.ItemCategory.Query";

		/// <summary>
		/// ItemCategory创建权限
		///</summary>
		public const string Create = "Pages.ItemCategory.Create";

		/// <summary>
		/// ItemCategory修改权限
		///</summary>
		public const string Edit = "Pages.ItemCategory.Edit";

		/// <summary>
		/// ItemCategory删除权限
		///</summary>
		public const string Delete = "Pages.ItemCategory.Delete";

        /// <summary>
		/// ItemCategory批量删除权限
		///</summary>
		public const string BatchDelete = "Pages.ItemCategory.BatchDelete";

		/// <summary>
		/// ItemCategory导出Excel
		///</summary>
		public const string ExportExcel="Pages.ItemCategory.ExportExcel";

		 
		 
         
    }

}

