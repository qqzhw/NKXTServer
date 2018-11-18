

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ICIMS.BusinessManages;

namespace ICIMS.EntityMapper.BuinessAudits
{
    public class BuinessAuditCfg : IEntityTypeConfiguration<BuinessAudit>
    {
        public void Configure(EntityTypeBuilder<BuinessAudit> builder)
        {

            builder.ToTable("BuinessAudit");
            builder.HasKey(a => a.Id);

            builder.HasOne(o => o.Role).WithMany().HasForeignKey(a => a.RoleId);
            builder.HasOne(o => o.BuinessType).WithMany().HasForeignKey(a => a.BuinessTypeId);
           

        }
    }
}


