

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ICIMS.BusinessManages;

namespace ICIMS.EntityMapper.ItemDefines
{
    public class ItemDefineCfg : IEntityTypeConfiguration<ItemDefine>
    {
        public void Configure(EntityTypeBuilder<ItemDefine> builder)
        {

            builder.ToTable("ItemDefine");
            builder.HasKey(a => a.Id);
			 
			builder.Property(a => a.SysGuid).HasMaxLength(64);
		 
			builder.Property(a => a.ItemDocNo).HasMaxLength(ICIMSAbpefCoreConsts.EntityLengthNames.Length128);
			 
			builder.Property(a => a.ItemNo).HasMaxLength(ICIMSAbpefCoreConsts.EntityLengthNames.Length128);
			builder.Property(a => a.ItemName).HasMaxLength(ICIMSAbpefCoreConsts.EntityLengthNames.Length128);
			//builder.Property(a => a.ItemType).HasMaxLength(ICIMSAbpefCoreConsts.EntityLengthNames.Length128);
		 
			builder.Property(a => a.ItemAddress).HasMaxLength(ICIMSAbpefCoreConsts.EntityLengthNames.Length128);
			builder.Property(a => a.ItemDescription).HasMaxLength(2000);
			builder.Property(a => a.Remark).HasMaxLength(2000);
            builder.Property(a => a.IsDeleted).HasDefaultValue(false);
             
           builder.HasOne(a => a.Unit).WithMany().HasForeignKey(r => r.UnitId).IsRequired();
           builder.HasOne(a => a.Budget).WithMany().HasForeignKey(r => r.BudgetId);
           builder.HasOne(a => a.ItemCategory).WithMany().HasForeignKey(r => r.ItemCategoryId).IsRequired();

            builder.HasOne(a => a.CreatorUser).WithMany().HasForeignKey(r => r.CreatorUserId);
        }
    }
}


