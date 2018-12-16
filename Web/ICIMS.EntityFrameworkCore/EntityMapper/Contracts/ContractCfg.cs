

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ICIMS.BusinessManages;

namespace ICIMS.EntityMapper.Contracts
{
    public class ContractCfg : IEntityTypeConfiguration<Contract>
    {
        public void Configure(EntityTypeBuilder<Contract> builder)
        {

            builder.ToTable("Contract");
            builder.HasKey(a => a.Id);
			builder.Property(a => a.SysGuid).HasMaxLength(ICIMSAbpefCoreConsts.EntityLengthNames.Length64);
			 
			builder.Property(a => a.ContractName).HasMaxLength(ICIMSAbpefCoreConsts.EntityLengthNames.Length128);
			 
			builder.Property(a => a.Warining).HasMaxLength(200);
			 
			builder.Property(a => a.Remark).HasMaxLength(2000);
            builder.HasOne(a => a.ItemDefine).WithMany().HasForeignKey(r => r.ItemDefineId).IsRequired();
           // builder.HasOne(a => a.Unit).WithMany().HasForeignKey(r => r.UnitId);
            builder.HasOne(a => a.ContractCategory).WithMany().HasForeignKey(r => r.ContractCategoryId).IsRequired();
            builder.HasOne(a => a.Vendor).WithMany().HasForeignKey(r => r.VendorId).IsRequired();
            builder.HasOne(a => a.CreatorUser).WithMany().HasForeignKey(r => r.CreatorUserId);
            builder.HasOne(a => a.AuditUser).WithMany().HasForeignKey(r => r.AuditUserId);
        }
    }
}


