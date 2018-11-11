using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ICIMS.Migrations
{
    public partial class tableadd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BuyCategory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    No = table.Column<string>(maxLength: 128, nullable: true),
                    Name = table.Column<string>(maxLength: 128, nullable: true),
                    Description = table.Column<string>(maxLength: 512, nullable: true),
                    ParentId = table.Column<int>(nullable: false),
                    Published = table.Column<bool>(nullable: false),
                    DisplayOrder = table.Column<int>(nullable: false),
                    TenantId = table.Column<int>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuyCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContractCategory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    No = table.Column<string>(maxLength: 128, nullable: true),
                    Name = table.Column<string>(maxLength: 128, nullable: true),
                    Description = table.Column<string>(maxLength: 512, nullable: true),
                    ParentId = table.Column<int>(nullable: false),
                    Published = table.Column<bool>(nullable: false),
                    DisplayOrder = table.Column<int>(nullable: false),
                    TenantId = table.Column<int>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false)
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
                    No = table.Column<string>(maxLength: 128, nullable: true),
                    Name = table.Column<string>(maxLength: 128, nullable: true),
                    Description = table.Column<string>(maxLength: 512, nullable: true),
                    ParentId = table.Column<int>(nullable: false),
                    Published = table.Column<bool>(nullable: false),
                    DisplayOrder = table.Column<int>(nullable: false),
                    TenantId = table.Column<int>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false)
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
                    DownloadGuid = table.Column<Guid>(maxLength: 128, nullable: false),
                    DownloadUrl = table.Column<string>(maxLength: 256, nullable: true),
                    UploadType = table.Column<string>(maxLength: 50, nullable: true),
                    ContentType = table.Column<string>(maxLength: 50, nullable: true),
                    FileName = table.Column<string>(maxLength: 128, nullable: true),
                    FileSize = table.Column<long>(nullable: false),
                    Extension = table.Column<string>(maxLength: 50, nullable: true),
                    DisplayOrder = table.Column<int>(nullable: false),
                    IsNew = table.Column<bool>(nullable: false),
                    TenantId = table.Column<int>(nullable: true)
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
                    No = table.Column<string>(maxLength: 100, nullable: true),
                    Name = table.Column<string>(maxLength: 128, nullable: true),
                    Description = table.Column<string>(maxLength: 512, nullable: true),
                    ParentId = table.Column<int>(nullable: false),
                    Published = table.Column<bool>(nullable: false),
                    DisplayOrder = table.Column<int>(nullable: false),
                    TenantId = table.Column<int>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FunctionSubject", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FundFrom",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    No = table.Column<string>(maxLength: 100, nullable: true),
                    Name = table.Column<string>(maxLength: 128, nullable: true),
                    Description = table.Column<string>(maxLength: 512, nullable: true),
                    ParentId = table.Column<int>(nullable: false),
                    Published = table.Column<bool>(nullable: false),
                    DisplayOrder = table.Column<int>(nullable: false),
                    TenantId = table.Column<int>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FundFrom", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemCategory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    No = table.Column<string>(maxLength: 100, nullable: true),
                    Name = table.Column<string>(maxLength: 128, nullable: true),
                    Description = table.Column<string>(maxLength: 2000, nullable: true),
                    ParentId = table.Column<int>(nullable: false),
                    Published = table.Column<bool>(nullable: false),
                    DisplayOrder = table.Column<int>(nullable: false),
                    TenantId = table.Column<int>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false)
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
                    No = table.Column<string>(maxLength: 100, nullable: true),
                    Name = table.Column<string>(maxLength: 128, nullable: true),
                    Description = table.Column<string>(maxLength: 512, nullable: true),
                    ParentId = table.Column<int>(nullable: false),
                    Published = table.Column<bool>(nullable: false),
                    DisplayOrder = table.Column<int>(nullable: false),
                    TenantId = table.Column<int>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false)
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
                    No = table.Column<string>(maxLength: 100, nullable: true),
                    Email = table.Column<string>(maxLength: 128, nullable: true),
                    Name = table.Column<string>(maxLength: 128, nullable: true),
                    Address = table.Column<string>(maxLength: 128, nullable: true),
                    LinkPerson = table.Column<string>(maxLength: 128, nullable: true),
                    LinkPhone = table.Column<string>(maxLength: 128, nullable: true),
                    AccountName = table.Column<string>(maxLength: 128, nullable: true),
                    OpenBank = table.Column<string>(maxLength: 128, nullable: true),
                    Remark = table.Column<string>(maxLength: 512, nullable: true),
                    TenantId = table.Column<int>(nullable: true),
                    Published = table.Column<bool>(nullable: false),
                    DisplayOrder = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "YSCategory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    No = table.Column<string>(maxLength: 50, nullable: true),
                    Name = table.Column<string>(maxLength: 128, nullable: true),
                    Description = table.Column<string>(maxLength: 512, nullable: true),
                    ParentId = table.Column<int>(nullable: false),
                    Published = table.Column<bool>(nullable: false),
                    DisplayOrder = table.Column<int>(nullable: false),
                    TenantId = table.Column<int>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YSCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Budget",
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
                    TenantId = table.Column<int>(nullable: true),
                    SysGuid = table.Column<string>(maxLength: 64, nullable: true),
                    Status = table.Column<int>(nullable: false),
                    Year = table.Column<int>(nullable: false),
                    BudgetNo = table.Column<string>(maxLength: 50, nullable: true),
                    BudgetName = table.Column<string>(maxLength: 128, nullable: true),
                    According = table.Column<string>(maxLength: 128, nullable: true),
                    MeasureStandard = table.Column<string>(maxLength: 128, nullable: true),
                    BudgetAmount = table.Column<decimal>(nullable: false),
                    UnitId = table.Column<long>(nullable: false),
                    YsCategoryId = table.Column<int>(nullable: false),
                    BuyCategoryId = table.Column<int>(nullable: false),
                    SubjectId = table.Column<int>(nullable: false),
                    OneAmount = table.Column<decimal>(nullable: false),
                    SecondAmount = table.Column<decimal>(nullable: false),
                    InitAmount = table.Column<decimal>(nullable: false),
                    MiddleAmount = table.Column<decimal>(nullable: false),
                    IsMiddle = table.Column<bool>(nullable: false),
                    MiddleReplyAmount = table.Column<decimal>(nullable: false),
                    Remark = table.Column<string>(maxLength: 2048, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Budget", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Budget_BuyCategory_BuyCategoryId",
                        column: x => x.BuyCategoryId,
                        principalTable: "BuyCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Budget_FunctionSubject_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "FunctionSubject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Budget_AbpOrganizationUnits_UnitId",
                        column: x => x.UnitId,
                        principalTable: "AbpOrganizationUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Budget_YSCategory_YsCategoryId",
                        column: x => x.YsCategoryId,
                        principalTable: "YSCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemDefine",
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
                    TenantId = table.Column<int>(nullable: true),
                    SysGuid = table.Column<string>(maxLength: 64, nullable: true),
                    Status = table.Column<int>(nullable: false),
                    UnitId = table.Column<long>(nullable: false),
                    BudgetId = table.Column<int>(nullable: true),
                    ItemDocNo = table.Column<string>(maxLength: 128, nullable: true),
                    DefineDate = table.Column<DateTime>(nullable: false),
                    ItemNo = table.Column<string>(maxLength: 128, nullable: true),
                    ItemName = table.Column<string>(maxLength: 128, nullable: true),
                    ItemCategoryId = table.Column<int>(nullable: false),
                    DefineAmount = table.Column<decimal>(nullable: false),
                    ItemAddress = table.Column<string>(maxLength: 128, nullable: true),
                    ItemDescription = table.Column<string>(maxLength: 2000, nullable: true),
                    Remark = table.Column<string>(maxLength: 2000, nullable: true),
                    IsFinal = table.Column<bool>(nullable: false),
                    IsAudit = table.Column<bool>(nullable: false),
                    AuditDate = table.Column<DateTime>(nullable: false),
                    AuditUserId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemDefine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemDefine_AbpUsers_AuditUserId",
                        column: x => x.AuditUserId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItemDefine_Budget_BudgetId",
                        column: x => x.BudgetId,
                        principalTable: "Budget",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItemDefine_ItemCategory_ItemCategoryId",
                        column: x => x.ItemCategoryId,
                        principalTable: "ItemCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemDefine_AbpOrganizationUnits_UnitId",
                        column: x => x.UnitId,
                        principalTable: "AbpOrganizationUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contract",
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
                    TenantId = table.Column<int>(nullable: true),
                    SysGuid = table.Column<string>(maxLength: 65, nullable: true),
                    Status = table.Column<int>(nullable: false),
                    ItemDefineId = table.Column<int>(nullable: false),
                    UnitId = table.Column<long>(nullable: false),
                    ContractCategoryId = table.Column<int>(nullable: false),
                    BeginTime = table.Column<DateTime>(nullable: false),
                    EndTime = table.Column<DateTime>(nullable: false),
                    ContractNo = table.Column<string>(nullable: true),
                    ContractName = table.Column<string>(maxLength: 128, nullable: true),
                    ContractAmount = table.Column<decimal>(nullable: false),
                    PaidAmount = table.Column<decimal>(nullable: false),
                    ProvisionalAmount = table.Column<decimal>(nullable: false),
                    Tax = table.Column<decimal>(nullable: false),
                    TaxAmount = table.Column<decimal>(nullable: false),
                    IdentifyDate = table.Column<DateTime>(nullable: false),
                    VendorId = table.Column<int>(nullable: false),
                    IsClearing = table.Column<bool>(nullable: false),
                    ClearingAmount = table.Column<decimal>(nullable: false),
                    ClearingPer = table.Column<decimal>(nullable: false),
                    FinalPer = table.Column<decimal>(nullable: false),
                    Warining = table.Column<string>(maxLength: 200, nullable: true),
                    WariningDate = table.Column<string>(nullable: true),
                    PaymentMethod = table.Column<string>(nullable: true),
                    Remark = table.Column<string>(maxLength: 2000, nullable: true),
                    AuditDate = table.Column<DateTime>(nullable: false),
                    AuditUserId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contract", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contract_AbpUsers_AuditUserId",
                        column: x => x.AuditUserId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Contract_ContractCategory_ContractCategoryId",
                        column: x => x.ContractCategoryId,
                        principalTable: "ContractCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contract_ItemDefine_ItemDefineId",
                        column: x => x.ItemDefineId,
                        principalTable: "ItemDefine",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
          
                    table.ForeignKey(
                        name: "FK_Contract_Vendor_VendorId",
                        column: x => x.VendorId,
                        principalTable: "Vendor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReViewDefine",
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
                    TenantId = table.Column<int>(nullable: true),
                    SysGuid = table.Column<string>(maxLength: 64, nullable: true),
                    Status = table.Column<int>(nullable: false),
                    ItemDefineId = table.Column<int>(nullable: false),
                    ReViewNo = table.Column<string>(maxLength: 100, nullable: true),
                    ReViewName = table.Column<string>(maxLength: 128, nullable: true),
                    ReViewDocNo = table.Column<string>(maxLength: 50, nullable: true),
                    ReViewAmount = table.Column<decimal>(nullable: false),
                    Remark = table.Column<string>(maxLength: 2000, nullable: true),
                    AuditDate = table.Column<DateTime>(nullable: false),
                    AuditUserId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReViewDefine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReViewDefine_AbpUsers_AuditUserId",
                        column: x => x.AuditUserId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReViewDefine_ItemDefine_ItemDefineId",
                        column: x => x.ItemDefineId,
                        principalTable: "ItemDefine",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PayAudit",
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
                    TenantId = table.Column<int>(nullable: true),
                    SysGuid = table.Column<string>(maxLength: 64, nullable: true),
                    Status = table.Column<int>(nullable: false),
                    UnitId = table.Column<long>(nullable: false),
                    ContrctId = table.Column<int>(nullable: false),
                    ItemDefineId = table.Column<int>(nullable: false),
                    PaymentTypeId = table.Column<int>(nullable: false),
                    PaymentNo = table.Column<string>(maxLength: 100, nullable: true),
                    PaymentName = table.Column<string>(maxLength: 128, nullable: true),
                    PayAmount = table.Column<decimal>(nullable: false),
                    PaymentPer = table.Column<int>(nullable: false),
                    PaymentCount = table.Column<int>(nullable: false),
                    ItemYsTotalAmount = table.Column<decimal>(nullable: false),
                    ItemTotalAmount = table.Column<decimal>(nullable: false),
                    ContractTotalAmount = table.Column<decimal>(nullable: false),
                    Remark = table.Column<string>(maxLength: 2000, nullable: true),
                    AuditDate = table.Column<DateTime>(nullable: false),
                    AuditUserId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayAudit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PayAudit_AbpUsers_AuditUserId",
                        column: x => x.AuditUserId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PayAudit_Contract_ContrctId",
                        column: x => x.ContrctId,
                        principalTable: "Contract",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                  
                    table.ForeignKey(
                        name: "FK_PayAudit_PaymentType_PaymentTypeId",
                        column: x => x.PaymentTypeId,
                        principalTable: "PaymentType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                   
                });

            migrationBuilder.CreateIndex(
                name: "IX_Budget_BuyCategoryId",
                table: "Budget",
                column: "BuyCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Budget_SubjectId",
                table: "Budget",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Budget_UnitId",
                table: "Budget",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Budget_YsCategoryId",
                table: "Budget",
                column: "YsCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Contract_AuditUserId",
                table: "Contract",
                column: "AuditUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Contract_ContractCategoryId",
                table: "Contract",
                column: "ContractCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Contract_ItemDefineId",
                table: "Contract",
                column: "ItemDefineId");

            migrationBuilder.CreateIndex(
                name: "IX_Contract_UnitId",
                table: "Contract",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Contract_VendorId",
                table: "Contract",
                column: "VendorId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemDefine_AuditUserId",
                table: "ItemDefine",
                column: "AuditUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemDefine_BudgetId",
                table: "ItemDefine",
                column: "BudgetId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemDefine_ItemCategoryId",
                table: "ItemDefine",
                column: "ItemCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemDefine_UnitId",
                table: "ItemDefine",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_PayAudit_AuditUserId",
                table: "PayAudit",
                column: "AuditUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PayAudit_ContrctId",
                table: "PayAudit",
                column: "ContrctId");

            migrationBuilder.CreateIndex(
                name: "IX_PayAudit_ItemDefineId",
                table: "PayAudit",
                column: "ItemDefineId");

            migrationBuilder.CreateIndex(
                name: "IX_PayAudit_PaymentTypeId",
                table: "PayAudit",
                column: "PaymentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PayAudit_UnitId",
                table: "PayAudit",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_ReViewDefine_AuditUserId",
                table: "ReViewDefine",
                column: "AuditUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ReViewDefine_ItemDefineId",
                table: "ReViewDefine",
                column: "ItemDefineId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DocumentCategory");

            migrationBuilder.DropTable(
                name: "FilesManages");

            migrationBuilder.DropTable(
                name: "FundFrom");

            migrationBuilder.DropTable(
                name: "PayAudit");

            migrationBuilder.DropTable(
                name: "ReViewDefine");

            migrationBuilder.DropTable(
                name: "Contract");

            migrationBuilder.DropTable(
                name: "PaymentType");

            migrationBuilder.DropTable(
                name: "ContractCategory");

            migrationBuilder.DropTable(
                name: "ItemDefine");

            migrationBuilder.DropTable(
                name: "Vendor");

            migrationBuilder.DropTable(
                name: "Budget");

            migrationBuilder.DropTable(
                name: "ItemCategory");

            migrationBuilder.DropTable(
                name: "BuyCategory");

            migrationBuilder.DropTable(
                name: "FunctionSubject");

            migrationBuilder.DropTable(
                name: "YSCategory");
        }
    }
}
