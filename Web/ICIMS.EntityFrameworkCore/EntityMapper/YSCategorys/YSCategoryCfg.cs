

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ICIMS.BaseData;

namespace ICIMS.EntityMapper.YSCategorys
{
    public class YSCategoryCfg : IEntityTypeConfiguration<YSCategory>
    {
        public void Configure(EntityTypeBuilder<YSCategory> builder)
        {

            builder.ToTable("YSCategory");

            builder.HasKey(a => a.Id);
			builder.Property(a => a.No).HasMaxLength(50);
			builder.Property(a => a.Name).HasMaxLength(ICIMSAbpefCoreConsts.EntityLengthNames.Length128);
			builder.Property(a => a.Description).HasMaxLength(512);
		 

        }
    }
}


