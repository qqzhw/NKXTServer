

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ICIMS.BusinessManages;

namespace ICIMS.EntityMapper.BuinessAudits
{
    public class BusinessAuditCfg : IEntityTypeConfiguration<BusinessAudit>
    {
        public void Configure(EntityTypeBuilder<BusinessAudit> builder)
        {

            builder.ToTable("BusinessAudit");
            builder.HasKey(a => a.Id);

            builder.HasOne(o => o.Role).WithMany().HasForeignKey(a => a.RoleId);
            builder.HasOne(o => o.BusinessType).WithMany().HasForeignKey(a => a.BusinessTypeId);
           

        }
    }
}


