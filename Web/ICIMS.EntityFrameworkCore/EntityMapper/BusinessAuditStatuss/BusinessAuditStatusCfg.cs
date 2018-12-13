

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ICIMS.BusinessManages;

namespace ICIMS.EntityMapper.BusinessAuditStatuss
{
    public class BusinessAuditStatusCfg : IEntityTypeConfiguration<BusinessAuditStatus>
    {
        public void Configure(EntityTypeBuilder<BusinessAuditStatus> builder)
        {

            builder.ToTable("BusinessAuditStatus");
            builder.HasKey(a => a.Id);
            
		 
			builder.Property(a => a.BusinessTypeName).HasMaxLength(50);
			builder.Property(a => a.Status).HasDefaultValue(0);
            builder.HasOne(a => a.BusinessAudit).WithMany().HasForeignKey(a => a.BusinessAuditId);
			builder.Property(a => a.DisplayOrder).HasDefaultValue(1);


        }
    }
}


