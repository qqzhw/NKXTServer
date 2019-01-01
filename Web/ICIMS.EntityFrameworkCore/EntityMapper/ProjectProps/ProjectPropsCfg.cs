using ICIMS.BaseData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ICIMS.EntityMapper
{
    public class ProjectPropsCfg : IEntityTypeConfiguration<ProjectProps>
    {
        public void Configure(EntityTypeBuilder<ProjectProps> builder)
        {

            builder.ToTable("ProjectProps");

            builder.HasKey(a => a.Id);
            builder.Property(a => a.No).HasMaxLength(ICIMSAbpefCoreConsts.EntityLengthNames.Length128);
            builder.Property(a => a.Name).HasMaxLength(ICIMSAbpefCoreConsts.EntityLengthNames.Length128);
            builder.Property(a => a.Description).HasMaxLength(512);



        }
    }
}
