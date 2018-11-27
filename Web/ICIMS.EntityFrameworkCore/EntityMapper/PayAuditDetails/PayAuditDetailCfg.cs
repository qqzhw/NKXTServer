

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ICIMS.BusinessManages;

namespace ICIMS.EntityMapper.PayAuditDetails
{
    public class PayAuditDetailCfg : IEntityTypeConfiguration<PayAuditDetail>
    {
        public void Configure(EntityTypeBuilder<PayAuditDetail> builder)
        {

            builder.ToTable("PayAuditDetail");
            builder.HasKey(a => a.Id);
            
			builder.Property(a => a.FundName).HasMaxLength(50); 
			builder.Property(a => a.Remark).HasMaxLength(512);
			 
			builder.HasOne(a => a.PayAudit).WithMany().HasForeignKey(a=>a.PayAuditId);
			  

        }
    }
}


