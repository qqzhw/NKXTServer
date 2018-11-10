

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ICIMS.BaseData;

namespace ICIMS.EntityMapper.ItemCategorys
{
    public class ItemCategoryCfg : IEntityTypeConfiguration<ItemCategory>
    {
        public void Configure(EntityTypeBuilder<ItemCategory> builder)
        {

            builder.ToTable("ItemCategory");

            builder.HasKey(a => a.Id);
            builder.Property(a => a.No).HasMaxLength(100);
			builder.Property(a => a.Name).HasMaxLength(ICIMSAbpefCoreConsts.EntityLengthNames.Length128);
			builder.Property(a => a.Description).HasMaxLength(2000);
		 

        }
    }
}


