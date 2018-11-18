

namespace ICIMS.BusinessManages.Authorization
{
	/// <summary>
    /// 定义系统的权限名称的字符串常量。
    /// <see cref="AuditMappingAuthorizationProvider" />中对权限的定义.
    ///</summary>
	public static  class AuditMappingPermissions
	{
		/// <summary>
		/// AuditMapping权限节点
		///</summary>
		public const string Node = "Pages.AuditMapping";

		/// <summary>
		/// AuditMapping查询授权
		///</summary>
		public const string Query = "Pages.AuditMapping.Query";

		/// <summary>
		/// AuditMapping创建权限
		///</summary>
		public const string Create = "Pages.AuditMapping.Create";

		/// <summary>
		/// AuditMapping修改权限
		///</summary>
		public const string Edit = "Pages.AuditMapping.Edit";

		/// <summary>
		/// AuditMapping删除权限
		///</summary>
		public const string Delete = "Pages.AuditMapping.Delete";

        /// <summary>
		/// AuditMapping批量删除权限
		///</summary>
		public const string BatchDelete = "Pages.AuditMapping.BatchDelete";

		/// <summary>
		/// AuditMapping导出Excel
		///</summary>
		public const string ExportExcel="Pages.AuditMapping.ExportExcel";

		 
		 
         
    }

}

