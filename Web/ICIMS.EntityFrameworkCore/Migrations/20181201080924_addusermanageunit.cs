using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ICIMS.Migrations
{
    public partial class addusermanageunit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "InitPayAmount",
                table: "PayAudit",
                nullable: true,
                defaultValue: 0.0m);

            migrationBuilder.CreateTable(
                name: "UserManageUnit",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<long>(nullable: false),
                    UnitId = table.Column<long>(nullable: false),
                    TenantId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserManageUnit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserManageUnit_AbpOrganizationUnits_UnitId",
                        column: x => x.UnitId,
                        principalTable: "AbpOrganizationUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserManageUnit_AbpUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AbpUserOrganizationUnits_UserId",
                table: "AbpUserOrganizationUnits",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserManageUnit_UnitId",
                table: "UserManageUnit",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_UserManageUnit_UserId",
                table: "UserManageUnit",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AbpUserOrganizationUnits_AbpUsers_UserId",
                table: "AbpUserOrganizationUnits",
                column: "UserId",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AbpUserOrganizationUnits_AbpUsers_UserId",
                table: "AbpUserOrganizationUnits");

            migrationBuilder.DropTable(
                name: "UserManageUnit");

            migrationBuilder.DropIndex(
                name: "IX_AbpUserOrganizationUnits_UserId",
                table: "AbpUserOrganizationUnits");

            migrationBuilder.DropColumn(
                name: "InitPayAmount",
                table: "PayAudit");
        }
    }
}
