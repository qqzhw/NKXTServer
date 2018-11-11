

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ICIMS.BusinessManages;

namespace ICIMS.EntityMapper.Budgets
{
    public class BudgetCfg : IEntityTypeConfiguration<Budget>
    {
        public void Configure(EntityTypeBuilder<Budget> builder)
        {

            builder.ToTable("Budget");
            builder.HasKey(a => a.Id);
            builder.Property(a => a.SysGuid).HasMaxLength(64);
            builder.Property(a => a.BudgetNo).HasMaxLength(50);
			builder.Property(a => a.BudgetName).HasMaxLength(ICIMSAbpefCoreConsts.EntityLengthNames.Length128);
			builder.Property(a => a.According).HasMaxLength(ICIMSAbpefCoreConsts.EntityLengthNames.Length128);
			builder.Property(a => a.MeasureStandard).HasMaxLength(ICIMSAbpefCoreConsts.EntityLengthNames.Length128);	
			 
			builder.Property(a => a.Remark).HasMaxLength(2048);

            builder.HasOne(a => a.BuyCategory)
               .WithMany()
               .HasForeignKey(a => a.BuyCategoryId)
               .IsRequired();

            builder.HasOne(a => a.FunctionSubject)
              .WithMany()
              .HasForeignKey(a => a.SubjectId)
              .IsRequired();

            builder.HasOne(a => a.YsCategory)
              .WithMany()
              .HasForeignKey(a => a.YsCategoryId)
              .IsRequired();
            builder.HasOne(a => a.Unit)
             .WithMany()
             .HasForeignKey(a => a.UnitId)
             .IsRequired();
        }
    }
}


