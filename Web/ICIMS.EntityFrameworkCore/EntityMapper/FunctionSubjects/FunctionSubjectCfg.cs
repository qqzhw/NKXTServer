

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ICIMS.BaseData;

namespace ICIMS.EntityMapper.FunctionSubjects
{
    public class FunctionSubjectCfg : IEntityTypeConfiguration<FunctionSubject>
    {
        public void Configure(EntityTypeBuilder<FunctionSubject> builder)
        {

            builder.ToTable("FunctionSubject");

            builder.HasKey(a => a.Id);
            builder.Property(a => a.No).HasMaxLength(100);
			builder.Property(a => a.Name).HasMaxLength(ICIMSAbpefCoreConsts.EntityLengthNames.Length128);
			builder.Property(a => a.Description).HasMaxLength(512);	 

        }
    }
}


