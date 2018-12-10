using Microsoft.EntityFrameworkCore.Migrations;

namespace ICIMS.Migrations
{
    public partial class addquanxian : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "According",
                table: "Contract",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BusinessTypeName",
                table: "AuditMappings",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AuditMappings_CreatorUserId",
                table: "AuditMappings",
                column: "CreatorUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AuditMappings_AbpUsers_CreatorUserId",
                table: "AuditMappings",
                column: "CreatorUserId",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuditMappings_AbpUsers_CreatorUserId",
                table: "AuditMappings");

            migrationBuilder.DropIndex(
                name: "IX_AuditMappings_CreatorUserId",
                table: "AuditMappings");

            migrationBuilder.DropColumn(
                name: "According",
                table: "Contract");

            migrationBuilder.DropColumn(
                name: "BusinessTypeName",
                table: "AuditMappings");
        }
    }
}
