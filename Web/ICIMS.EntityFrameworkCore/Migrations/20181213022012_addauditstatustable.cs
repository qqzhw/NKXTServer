using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ICIMS.Migrations
{
    public partial class addauditstatustable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BusinessAuditStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TenantId = table.Column<int>(nullable: true),
                    EntityId = table.Column<int>(nullable: false),
                    BusinessTypeName = table.Column<string>(maxLength: 50, nullable: true),
                    Status = table.Column<int>(nullable: false, defaultValue: 0),
                    BusinessAuditId = table.Column<int>(nullable: false),
                    DisplayOrder = table.Column<int>(nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessAuditStatus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BusinessAuditStatus_BusinessAudit_BusinessAuditId",
                        column: x => x.BusinessAuditId,
                        principalTable: "BusinessAudit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BusinessAuditStatus_BusinessAuditId",
                table: "BusinessAuditStatus",
                column: "BusinessAuditId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BusinessAuditStatus");
        }
    }
}
