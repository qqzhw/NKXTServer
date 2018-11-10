

using ICIMS.BussinesManages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
 

namespace ICIMS.EntityMapper.BusinessTypes
{
    public class BusinessTypeCfg : IEntityTypeConfiguration<BusinessType>
    {
        public void Configure(EntityTypeBuilder<BusinessType> builder)
        {

            builder.ToTable("BusinessTypes", ICIMSAbpefCoreConsts.SchemaNames.CMS);

            
			builder.Property(a => a.Name).HasMaxLength(ICIMSAbpefCoreConsts.EntityLengthNames.Length128);
			 
        }
    }
}


