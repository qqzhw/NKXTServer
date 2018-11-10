

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ICIMS.BaseData;

namespace ICIMS.EntityMapper.FundFroms
{
    public class FundFromCfg : IEntityTypeConfiguration<FundFrom>
    {
        public void Configure(EntityTypeBuilder<FundFrom> builder)
        {

            builder.ToTable("FundFrom");
            builder.HasKey(a => a.Id);
            
			builder.Property(a => a.No).HasMaxLength(100);
			builder.Property(a => a.Name).HasMaxLength(ICIMSAbpefCoreConsts.EntityLengthNames.Length128);
			builder.Property(a => a.Description).HasMaxLength(512);
 


        }
    }
}


