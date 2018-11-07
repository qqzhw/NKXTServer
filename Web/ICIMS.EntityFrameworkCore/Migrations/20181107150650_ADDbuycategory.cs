using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ICIMS.Migrations
{
    public partial class ADDbuycategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BuyCategory");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
        }
    }
}
