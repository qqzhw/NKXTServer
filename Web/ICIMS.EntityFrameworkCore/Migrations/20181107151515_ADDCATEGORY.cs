using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ICIMS.Migrations
{
    public partial class ADDCATEGORY : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BuyCategory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    No = table.Column<string>(maxLength: 65, nullable: true),
                    Name = table.Column<string>(maxLength: 65, nullable: true),
                    Description = table.Column<string>(maxLength: 65, nullable: true),
                    ParentId = table.Column<int>(maxLength: 65, nullable: false),
                    Published = table.Column<bool>(maxLength: 65, nullable: false),
                    DisplayOrder = table.Column<int>(maxLength: 65, nullable: false),
                    TenantId = table.Column<int>(maxLength: 65, nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuyCategory", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BuyCategory");
        }
    }
}
