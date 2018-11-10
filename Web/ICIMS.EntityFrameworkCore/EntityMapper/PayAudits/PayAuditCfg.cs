

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ICIMS.BusinessManages;

namespace ICIMS.EntityMapper.PayAudits
{
    public class PayAuditCfg : IEntityTypeConfiguration<PayAudit>
    {
        public void Configure(EntityTypeBuilder<PayAudit> builder)
        {

            builder.ToTable("PayAudits", ICIMSAbpefCoreConsts.SchemaNames.CMS);

            
	 
			builder.Property(a => a.SysGuid).HasMaxLength(64);
		 
			builder.Property(a => a.PaymentNo).HasMaxLength(100);
			builder.Property(a => a.PaymentName).HasMaxLength(ICIMSAbpefCoreConsts.EntityLengthNames.Length128);
		 
		 
			builder.Property(a => a.Remark).HasMaxLength(2000);
		 

        }
    }
}


