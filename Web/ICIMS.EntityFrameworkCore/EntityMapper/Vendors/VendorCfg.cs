

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ICIMS.BaseData;

namespace ICIMS.EntityMapper.Vendors
{
    public class VendorCfg : IEntityTypeConfiguration<Vendor>
    {
        public void Configure(EntityTypeBuilder<Vendor> builder)
        {

            builder.ToTable("Vendor");
            builder.HasKey(a => a.Id);

            builder.Property(a => a.No).HasMaxLength(100);
            builder.Property(a => a.Email).HasMaxLength(ICIMSAbpefCoreConsts.EntityLengthNames.Length128);
            builder.Property(a => a.Name).HasMaxLength(ICIMSAbpefCoreConsts.EntityLengthNames.Length128);
            builder.Property(a => a.Address).HasMaxLength(ICIMSAbpefCoreConsts.EntityLengthNames.Length128);
            builder.Property(a => a.LinkPerson).HasMaxLength(ICIMSAbpefCoreConsts.EntityLengthNames.Length128);
            builder.Property(a => a.LinkPhone).HasMaxLength(ICIMSAbpefCoreConsts.EntityLengthNames.Length128);
            builder.Property(a => a.AccountName).HasMaxLength(ICIMSAbpefCoreConsts.EntityLengthNames.Length128);
            builder.Property(a => a.OpenBank).HasMaxLength(ICIMSAbpefCoreConsts.EntityLengthNames.Length128);
            builder.Property(a => a.Remark).HasMaxLength(512);

        }
    }
}


