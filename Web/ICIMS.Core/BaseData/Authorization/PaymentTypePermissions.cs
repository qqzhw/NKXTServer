

namespace ICIMS.BaseData.Authorization
{
	/// <summary>
    /// 定义系统的权限名称的字符串常量。
    /// <see cref="PaymentTypeAuthorizationProvider" />中对权限的定义.
    ///</summary>
	public static  class PaymentTypePermissions
	{
		/// <summary>
		/// PaymentType权限节点
		///</summary>
		public const string Node = "Pages.PaymentType";

		/// <summary>
		/// PaymentType查询授权
		///</summary>
		public const string Query = "Pages.PaymentType.Query";

		/// <summary>
		/// PaymentType创建权限
		///</summary>
		public const string Create = "Pages.PaymentType.Create";

		/// <summary>
		/// PaymentType修改权限
		///</summary>
		public const string Edit = "Pages.PaymentType.Edit";

		/// <summary>
		/// PaymentType删除权限
		///</summary>
		public const string Delete = "Pages.PaymentType.Delete";

        /// <summary>
		/// PaymentType批量删除权限
		///</summary>
		public const string BatchDelete = "Pages.PaymentType.BatchDelete";

		/// <summary>
		/// PaymentType导出Excel
		///</summary>
		public const string ExportExcel="Pages.PaymentType.ExportExcel";

		 
		 
         
    }

}

