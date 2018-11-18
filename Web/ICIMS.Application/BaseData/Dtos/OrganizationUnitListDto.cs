using System;
using System.Collections.Generic;
using System.Text;

namespace ICIMS.BaseData.Dtos
{
    public class OrganizationUnitListDto
    {
        public int Id { get; set; }

        /// <summary>
        /// TenantId of this entity.
        /// </summary>
        public virtual int? TenantId { get; set; }

        
        /// <summary>
        /// Parent <see cref="OrganizationUnit"/> Id.
        /// Null, if this OU is root.
        /// </summary>
        public virtual long? ParentId { get; set; }

        
        public virtual string Code { get; set; }


        public virtual string DisplayName { get; set; }

        /// <summary>
        /// Children of this OU.
        /// </summary>
        public virtual ICollection<OrganizationUnitListDto> Children { get; set; }
    }
}
