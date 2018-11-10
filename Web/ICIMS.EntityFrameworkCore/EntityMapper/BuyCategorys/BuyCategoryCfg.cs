

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ICIMS.BaseData;

namespace ICIMS.EntityMapper.BuyCategorys
{
    public class BuyCategoryCfg : IEntityTypeConfiguration<BuyCategory>
    {
        public void Configure(EntityTypeBuilder<BuyCategory> builder)
        {

            builder.ToTable("BuyCategory");
            builder.HasKey(a => a.Id);
            
			builder.Property(a => a.No).HasMaxLength(ICIMSAbpefCoreConsts.EntityLengthNames.Length128);
			builder.Property(a => a.Name).HasMaxLength(ICIMSAbpefCoreConsts.EntityLengthNames.Length128);
			builder.Property(a => a.Description).HasMaxLength(512);		 

        }
    }
}


