

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ICIMS.BusinessManages;

namespace ICIMS.EntityMapper.UserManageUnits
{
    public class UserManageUnitCfg : IEntityTypeConfiguration<UserManageUnit>
    {
        public void Configure(EntityTypeBuilder<UserManageUnit> builder)
        {

            builder.ToTable("UserManageUnit");
            builder.HasKey(a => a.Id);
			builder.HasOne(a => a.User).WithMany().HasForeignKey(a=>a.UserId);
			builder.HasOne(a => a.OrganizationUnit).WithMany().HasForeignKey(a=>a.UnitId);
        }
    }
}


