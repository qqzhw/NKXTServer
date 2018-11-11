

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ICIMS.BusinessManages;

namespace ICIMS.EntityMapper.PayAudits
{
    public class PayAuditCfg : IEntityTypeConfiguration<PayAudit>
    {
        public void Configure(EntityTypeBuilder<PayAudit> builder)
        {

            builder.ToTable("PayAudit");
            builder.HasKey(a => a.Id);
            
	 
			builder.Property(a => a.SysGuid).HasMaxLength(64);
		 
			builder.Property(a => a.PaymentNo).HasMaxLength(100);
			builder.Property(a => a.PaymentName).HasMaxLength(ICIMSAbpefCoreConsts.EntityLengthNames.Length128);
		 
		 
			builder.Property(a => a.Remark).HasMaxLength(2000);

            builder.HasOne(a => a.Unit).WithMany().HasForeignKey(r => r.UnitId).IsRequired();
            builder.HasOne(a => a.Contract).WithMany().HasForeignKey(r => r.ContrctId).IsRequired();
            builder.HasOne(a => a.ItemDefine).WithMany().HasForeignKey(r => r.ItemDefineId).IsRequired();
            builder.HasOne(a => a.PaymentType).WithMany().HasForeignKey(r => r.PaymentTypeId).IsRequired();
        }
    }
}


