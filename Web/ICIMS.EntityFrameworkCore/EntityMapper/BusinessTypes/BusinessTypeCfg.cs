

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ICIMS.BusinessManages;

namespace ICIMS.EntityMapper.BusinessTypes
{
    public class BusinessTypeCfg : IEntityTypeConfiguration<BusinessType>
    {
        public void Configure(EntityTypeBuilder<BusinessType> builder)
        {

            builder.ToTable("BusinessType");

            builder.HasKey(a => a.Id);
			builder.Property(a => a.Name).HasMaxLength(100); 

        }
    }
}


