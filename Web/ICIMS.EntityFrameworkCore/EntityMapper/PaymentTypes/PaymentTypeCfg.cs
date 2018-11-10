

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ICIMS.BaseData;

namespace ICIMS.EntityMapper.PaymentTypes
{
    public class PaymentTypeCfg : IEntityTypeConfiguration<PaymentType>
    {
        public void Configure(EntityTypeBuilder<PaymentType> builder)
        {

            builder.ToTable("PaymentType");
            builder.HasKey(a => a.Id);

            builder.Property(a => a.No).HasMaxLength(100);
			builder.Property(a => a.Name).HasMaxLength(ICIMSAbpefCoreConsts.EntityLengthNames.Length128);
			builder.Property(a => a.Description).HasMaxLength(512);
		 

        }
    }
}


