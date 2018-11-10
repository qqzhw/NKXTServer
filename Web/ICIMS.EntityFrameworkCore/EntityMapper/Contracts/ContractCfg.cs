

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ICIMS.BusinessManages;

namespace ICIMS.EntityMapper.Contracts
{
    public class ContractCfg : IEntityTypeConfiguration<Contract>
    {
        public void Configure(EntityTypeBuilder<Contract> builder)
        {

            builder.ToTable("Contracts", ICIMSAbpefCoreConsts.SchemaNames.CMS);
            builder.HasKey(a => a.Id);
			builder.Property(a => a.SysGuid).HasMaxLength(ICIMSAbpefCoreConsts.EntityLengthNames.Length64);
			 
			builder.Property(a => a.ContractName).HasMaxLength(ICIMSAbpefCoreConsts.EntityLengthNames.Length128);
			 
			builder.Property(a => a.Warining).HasMaxLength(200);
			 
			builder.Property(a => a.Remark).HasMaxLength(2000);
 

        }
    }
}


