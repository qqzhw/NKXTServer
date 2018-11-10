

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ICIMS.BaseData;

namespace ICIMS.EntityMapper.FilesManages
{
    public class FilesManageCfg : IEntityTypeConfiguration<FilesManage>
    {
        public void Configure(EntityTypeBuilder<FilesManage> builder)
        {

            builder.ToTable("FilesManages");
            builder.HasKey(a => a.Id);

            builder.Property(a => a.DownloadGuid).HasMaxLength(ICIMSAbpefCoreConsts.EntityLengthNames.Length128);
			builder.Property(a => a.DownloadUrl).HasMaxLength(ICIMSAbpefCoreConsts.EntityLengthNames.Length128);
			builder.Property(a => a.UploadType).HasMaxLength(50);
			builder.Property(a => a.ContentType).HasMaxLength(50);
			builder.Property(a => a.FileName).HasMaxLength(ICIMSAbpefCoreConsts.EntityLengthNames.Length128);
			 
			builder.Property(a => a.Extension).HasMaxLength(50);
		 

        }
    }
}


