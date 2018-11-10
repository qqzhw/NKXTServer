

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ICIMS.BaseData;

namespace ICIMS.EntityMapper.ContractCategorys
{
    public class ContractCategoryCfg : IEntityTypeConfiguration<ContractCategory>
    {
        public void Configure(EntityTypeBuilder<ContractCategory> builder)
        {

            builder.ToTable("ContractCategory");
            
            builder.HasKey(a => a.Id);
			builder.Property(a => a.No).HasMaxLength(ICIMSAbpefCoreConsts.EntityLengthNames.Length128);
			builder.Property(a => a.Name).HasMaxLength(ICIMSAbpefCoreConsts.EntityLengthNames.Length128);
			builder.Property(a => a.Description).HasMaxLength(512);
			 

        }
    }
}


