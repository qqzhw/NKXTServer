

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ICIMS.BusinessManages;

namespace ICIMS.EntityMapper.AuditMappings
{
    public class AuditMappingCfg : IEntityTypeConfiguration<AuditMapping>
    {
        public void Configure(EntityTypeBuilder<AuditMapping> builder)
        {

            builder.ToTable("AuditMappings"); 
            builder.HasKey(a => a.Id);
            builder.HasOne(a => a.BuinessAudit).WithMany().HasForeignKey(a => a.BuinessAuditId);
        }
    }
}


