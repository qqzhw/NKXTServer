using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ICIMS.Migrations
{
    public partial class _20181107 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContractCategory",
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
                    CreationTime = table.Column<DateTime>(maxLength: 65, nullable: false),
                    LastModificationTime = table.Column<DateTime>(maxLength: 65, nullable: true),
                    IsDeleted = table.Column<bool>(maxLength: 65, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DocumentCategory",
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
                    CreationTime = table.Column<DateTime>(maxLength: 65, nullable: false),
                    LastModificationTime = table.Column<DateTime>(maxLength: 65, nullable: true),
                    IsDeleted = table.Column<bool>(maxLength: 65, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FilesManages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    DownloadGuid = table.Column<Guid>(maxLength: 65, nullable: false),
                    DownloadUrl = table.Column<string>(maxLength: 65, nullable: true),
                    UploadType = table.Column<string>(maxLength: 65, nullable: true),
                    ContentType = table.Column<string>(maxLength: 65, nullable: true),
                    FileName = table.Column<string>(maxLength: 65, nullable: true),
                    FileSize = table.Column<long>(maxLength: 65, nullable: false),
                    Extension = table.Column<string>(maxLength: 65, nullable: true),
                    DisplayOrder = table.Column<int>(maxLength: 65, nullable: false),
                    IsNew = table.Column<bool>(maxLength: 65, nullable: false),
                    TenantId = table.Column<int>(maxLength: 65, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilesManages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FunctionSubject",
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
                    CreationTime = table.Column<DateTime>(maxLength: 65, nullable: false),
                    LastModificationTime = table.Column<DateTime>(maxLength: 65, nullable: true),
                    IsDeleted = table.Column<bool>(maxLength: 65, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FunctionSubject", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemCategory",
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
                    CreationTime = table.Column<DateTime>(maxLength: 65, nullable: false),
                    LastModificationTime = table.Column<DateTime>(maxLength: 65, nullable: true),
                    IsDeleted = table.Column<bool>(maxLength: 65, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentType",
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
                    CreationTime = table.Column<DateTime>(maxLength: 65, nullable: false),
                    LastModificationTime = table.Column<DateTime>(maxLength: 65, nullable: true),
                    IsDeleted = table.Column<bool>(maxLength: 65, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vendor",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    No = table.Column<string>(maxLength: 65, nullable: true),
                    Email = table.Column<string>(maxLength: 65, nullable: true),
                    Name = table.Column<string>(maxLength: 65, nullable: true),
                    Address = table.Column<string>(maxLength: 65, nullable: true),
                    LinkPerson = table.Column<string>(maxLength: 65, nullable: true),
                    LinkPhone = table.Column<string>(maxLength: 65, nullable: true),
                    AccountName = table.Column<string>(maxLength: 65, nullable: true),
                    OpenBank = table.Column<string>(maxLength: 65, nullable: true),
                    Remark = table.Column<string>(maxLength: 65, nullable: true),
                    TenantId = table.Column<int>(maxLength: 65, nullable: true),
                    Published = table.Column<bool>(maxLength: 65, nullable: false),
                    DisplayOrder = table.Column<int>(maxLength: 65, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendor", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContractCategory");

            migrationBuilder.DropTable(
                name: "DocumentCategory");

            migrationBuilder.DropTable(
                name: "FilesManages");

            migrationBuilder.DropTable(
                name: "FunctionSubject");

            migrationBuilder.DropTable(
                name: "ItemCategory");

            migrationBuilder.DropTable(
                name: "PaymentType");

            migrationBuilder.DropTable(
                name: "Vendor");
        }
    }
}
