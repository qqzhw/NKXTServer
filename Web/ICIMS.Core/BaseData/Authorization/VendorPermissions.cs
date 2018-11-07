

namespace ICIMS.BaseData.Authorization
{
	/// <summary>
    /// 定义系统的权限名称的字符串常量。
    /// <see cref="VendorAuthorizationProvider" />中对权限的定义.
    ///</summary>
	public static  class VendorPermissions
	{
		/// <summary>
		/// Vendor权限节点
		///</summary>
		public const string Node = "Pages.Vendor";

		/// <summary>
		/// Vendor查询授权
		///</summary>
		public const string Query = "Pages.Vendor.Query";

		/// <summary>
		/// Vendor创建权限
		///</summary>
		public const string Create = "Pages.Vendor.Create";

		/// <summary>
		/// Vendor修改权限
		///</summary>
		public const string Edit = "Pages.Vendor.Edit";

		/// <summary>
		/// Vendor删除权限
		///</summary>
		public const string Delete = "Pages.Vendor.Delete";

        /// <summary>
		/// Vendor批量删除权限
		///</summary>
		public const string BatchDelete = "Pages.Vendor.BatchDelete";

		/// <summary>
		/// Vendor导出Excel
		///</summary>
		public const string ExportExcel="Pages.Vendor.ExportExcel";

		 
		 
         
    }

}

