

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ICIMS.BusinessManages;

namespace ICIMS.EntityMapper.ReViewDefines
{
    public class ReViewDefineCfg : IEntityTypeConfiguration<ReViewDefine>
    {
        public void Configure(EntityTypeBuilder<ReViewDefine> builder)
        {

            builder.ToTable("ReViewDefine");
            builder.HasKey(a => a.Id);
            builder.Property(a => a.SysGuid).HasMaxLength(64);

            builder.Property(a => a.ReViewNo).HasMaxLength(100);
			builder.Property(a => a.ReViewName).HasMaxLength(ICIMSAbpefCoreConsts.EntityLengthNames.Length128);
			builder.Property(a => a.ReViewDocNo).HasMaxLength(50); 
			builder.Property(a => a.Remark).HasMaxLength(2000);

            builder.HasOne(a => a.ItemDefine).WithMany().HasForeignKey(a => a.ItemDefineId).IsRequired();
            builder.HasOne(a => a.CreatorUser).WithMany().HasForeignKey(a => a.CreatorUserId);
           // builder.HasOne(a => a.AuditUser).WithMany().HasForeignKey(a => a.AuditUserId);
        }
    }
}


