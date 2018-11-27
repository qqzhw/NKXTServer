using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ICIMS.Migrations
{
    public partial class addpayauditdetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PaymentMethod",
                table: "PayAudit",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ContractTime",
                table: "Contract",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "PayAuditDetail",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FundName = table.Column<string>(maxLength: 50, nullable: true),
                    TenantId = table.Column<int>(nullable: true),
                    Remark = table.Column<string>(maxLength: 512, nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Amount = table.Column<decimal>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    PayAuditId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayAuditDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PayAuditDetail_PayAudit_PayAuditId",
                        column: x => x.PayAuditId,
                        principalTable: "PayAudit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReViewDefine_CreatorUserId",
                table: "ReViewDefine",
                column: "CreatorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PayAudit_CreatorUserId",
                table: "PayAudit",
                column: "CreatorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PayAuditDetail_PayAuditId",
                table: "PayAuditDetail",
                column: "PayAuditId");

            migrationBuilder.AddForeignKey(
                name: "FK_PayAudit_AbpUsers_CreatorUserId",
                table: "PayAudit",
                column: "CreatorUserId",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ReViewDefine_AbpUsers_CreatorUserId",
                table: "ReViewDefine",
                column: "CreatorUserId",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PayAudit_AbpUsers_CreatorUserId",
                table: "PayAudit");

            migrationBuilder.DropForeignKey(
                name: "FK_ReViewDefine_AbpUsers_CreatorUserId",
                table: "ReViewDefine");

            migrationBuilder.DropTable(
                name: "PayAuditDetail");

            migrationBuilder.DropIndex(
                name: "IX_ReViewDefine_CreatorUserId",
                table: "ReViewDefine");

            migrationBuilder.DropIndex(
                name: "IX_PayAudit_CreatorUserId",
                table: "PayAudit");

            migrationBuilder.DropColumn(
                name: "PaymentMethod",
                table: "PayAudit");

            migrationBuilder.DropColumn(
                name: "ContractTime",
                table: "Contract");
        }
    }
}
