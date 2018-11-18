using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ICIMS.Migrations
{
    public partial class addauditmapping : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Contract_AbpOrganizationUnits_UnitId",
            //    table: "Contract");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_PayAudit_ItemDefine_ItemDefineId",
            //    table: "PayAudit");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_PayAudit_AbpOrganizationUnits_UnitId",
            //    table: "PayAudit");

            migrationBuilder.DropIndex(
                name: "IX_PayAudit_ItemDefineId",
                table: "PayAudit");

            migrationBuilder.DropIndex(
                name: "IX_PayAudit_UnitId",
                table: "PayAudit");

            migrationBuilder.DropIndex(
                name: "IX_Contract_UnitId",
                table: "Contract");

            migrationBuilder.AlterColumn<DateTime>(
                name: "AuditDate",
                table: "ReViewDefine",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<long>(
                name: "UnitId",
                table: "PayAudit",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<DateTime>(
                name: "AuditDate",
                table: "PayAudit",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "ItemDefine",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<DateTime>(
                name: "AuditDate",
                table: "ItemDefine",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "AuditDate",
                table: "Contract",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.CreateTable(
                name: "BusinessType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    DisplayOrder = table.Column<int>(nullable: false),
                    TenantId = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BuinessAudit",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    DisplayOrder = table.Column<int>(nullable: false),
                    TenantId = table.Column<int>(nullable: true),
                    RoleId = table.Column<int>(nullable: false),
                    BuinessTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuinessAudit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BuinessAudit_BusinessType_BuinessTypeId",
                        column: x => x.BuinessTypeId,
                        principalTable: "BusinessType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BuinessAudit_AbpRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AbpRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AuditMappings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DisplayOrder = table.Column<int>(nullable: false),
                    TenantId = table.Column<int>(nullable: true),
                    BuinessAuditId = table.Column<int>(nullable: false),
                    BuinessTypeId = table.Column<int>(nullable: false),
                    ItemId = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    AuditOpinion = table.Column<string>(nullable: true),
                    CreatorUserId = table.Column<long>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    AuditTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditMappings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AuditMappings_BuinessAudit_BuinessAuditId",
                        column: x => x.BuinessAuditId,
                        principalTable: "BuinessAudit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuditMappings_BuinessAuditId",
                table: "AuditMappings",
                column: "BuinessAuditId");

            migrationBuilder.CreateIndex(
                name: "IX_BuinessAudit_BuinessTypeId",
                table: "BuinessAudit",
                column: "BuinessTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_BuinessAudit_RoleId",
                table: "BuinessAudit",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuditMappings");

            migrationBuilder.DropTable(
                name: "BuinessAudit");

            migrationBuilder.DropTable(
                name: "BusinessType");

            migrationBuilder.AlterColumn<DateTime>(
                name: "AuditDate",
                table: "ReViewDefine",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "UnitId",
                table: "PayAudit",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "AuditDate",
                table: "PayAudit",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "ItemDefine",
                nullable: false,
                oldClrType: typeof(bool),
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "AuditDate",
                table: "ItemDefine",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "AuditDate",
                table: "Contract",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PayAudit_ItemDefineId",
                table: "PayAudit",
                column: "ItemDefineId");

            migrationBuilder.CreateIndex(
                name: "IX_PayAudit_UnitId",
                table: "PayAudit",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Contract_UnitId",
                table: "Contract",
                column: "UnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contract_AbpOrganizationUnits_UnitId",
                table: "Contract",
                column: "UnitId",
                principalTable: "AbpOrganizationUnits",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_PayAudit_ItemDefine_ItemDefineId",
                table: "PayAudit",
                column: "ItemDefineId",
                principalTable: "ItemDefine",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PayAudit_AbpOrganizationUnits_UnitId",
                table: "PayAudit",
                column: "UnitId",
                principalTable: "AbpOrganizationUnits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
