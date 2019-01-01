using System;
using System.Collections.Generic;
using System.Text;

namespace ICIMS.BaseData.Authorization
{
    public class ProjectPropsPermissions
    {
        /// <summary>
		/// DocumentCategory权限节点
		///</summary>
		public const string Node = "Pages.ProjectProps";

        /// <summary>
        /// DocumentCategory查询授权
        ///</summary>
        public const string Query = "Pages.ProjectProps.Query";

        /// <summary>
        /// DocumentCategory创建权限
        ///</summary>
        public const string Create = "Pages.ProjectProps.Create";

        /// <summary>
        /// DocumentCategory修改权限
        ///</summary>
        public const string Edit = "Pages.ProjectProps.Edit";

        /// <summary>
        /// DocumentCategory删除权限
        ///</summary>
        public const string Delete = "Pages.ProjectProps.Delete";

        /// <summary>
		/// DocumentCategory批量删除权限
		///</summary>
		public const string BatchDelete = "Pages.ProjectProps.BatchDelete";

        /// <summary>
        /// DocumentCategory导出Excel
        ///</summary>
        public const string ExportExcel = "Pages.ProjectProps.ExportExcel";
    }
}
