using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ServiceLayers.Migrations
{
    public partial class addProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    AdminId = table.Column<Guid>(nullable: false),
                    AdminName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InventoryItemCategory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    InventoryItemCategoryName = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryItemCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InventoryItemType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    InventoryItemTypeName = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryItemType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Price",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Count = table.Column<int>(nullable: false),
                    Price1 = table.Column<double>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Price", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProductCategoryName = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductOption",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Option = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductOption", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProductTypeName = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleName = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SalesPerson",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SalesPersonId = table.Column<Guid>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    VehicleNo = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    PhoneNo = table.Column<string>(nullable: true),
                    MobileNo = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Salary = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesPerson", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCartViewModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProductList = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCartViewModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Supplier",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SupplierId = table.Column<Guid>(nullable: false),
                    Suppliername = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    PhoneNo = table.Column<string>(nullable: true),
                    MobileNo = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    PaymentMethod = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Company = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplier", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InventoryItem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    InventoryItemName = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    InventoryItemCategoryFk = table.Column<int>(nullable: false),
                    InventoryItemCategoryFkNavigationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InventoryItem_InventoryItemCategory_InventoryItemCategoryFkNavigationId",
                        column: x => x.InventoryItemCategoryFkNavigationId,
                        principalTable: "InventoryItemCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProductName = table.Column<string>(nullable: true),
                    ProductImage = table.Column<string>(nullable: true),
                    Sku = table.Column<string>(nullable: true),
                    Variants = table.Column<string>(nullable: true),
                    ProductTypeIdFk = table.Column<int>(nullable: false),
                    ProductCategoryIdFk = table.Column<int>(nullable: false),
                    OnHand = table.Column<bool>(nullable: false),
                    Fullfilled = table.Column<bool>(nullable: false),
                    Instock = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_ProductCategory_ProductCategoryIdFk",
                        column: x => x.ProductCategoryIdFk,
                        principalTable: "ProductCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Product_ProductType_ProductTypeIdFk",
                        column: x => x.ProductTypeIdFk,
                        principalTable: "ProductType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SalesManager",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SalesManagerId = table.Column<Guid>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    RoleIdFk = table.Column<int>(nullable: false),
                    Salary = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    PhoneNo = table.Column<string>(nullable: true),
                    MobileNo = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    RoleIdFkNavigationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesManager", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalesManager_Role_RoleIdFkNavigationId",
                        column: x => x.RoleIdFkNavigationId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseInvoice",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PurchaseInvoiceNo = table.Column<string>(nullable: true),
                    SupplierIdFk = table.Column<int>(nullable: true),
                    PaymentDate = table.Column<DateTime>(nullable: false),
                    DueDate = table.Column<DateTime>(nullable: false),
                    Balance = table.Column<double>(nullable: false),
                    PaidAmount = table.Column<double>(nullable: false),
                    Total = table.Column<double>(nullable: false),
                    Status = table.Column<string>(nullable: true),
                    InvoiceDate = table.Column<DateTime>(nullable: false),
                    Revenue = table.Column<double>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    SupplierIdFkNavigationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseInvoice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseInvoice_Supplier_SupplierIdFkNavigationId",
                        column: x => x.SupplierIdFkNavigationId,
                        principalTable: "Supplier",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseOrder",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PurchaseOrderNo = table.Column<string>(nullable: true),
                    Reference = table.Column<string>(nullable: true),
                    SupplierIdFk = table.Column<int>(nullable: true),
                    Untaxed = table.Column<string>(nullable: true),
                    Total = table.Column<double>(nullable: false),
                    Status = table.Column<string>(nullable: true),
                    Revenue = table.Column<double>(nullable: false),
                    OrderDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    SupplierIdFkNavigationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseOrder", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseOrder_Supplier_SupplierIdFkNavigationId",
                        column: x => x.SupplierIdFkNavigationId,
                        principalTable: "Supplier",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Inventory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Amount = table.Column<double>(nullable: false),
                    Unit = table.Column<int>(nullable: false),
                    MinimumStockLevel = table.Column<int>(nullable: false),
                    ReorderQuantity = table.Column<int>(nullable: false),
                    DefaultLocation = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    InventoryItemFk = table.Column<int>(nullable: true),
                    InventoryItemTypeFk = table.Column<int>(nullable: true),
                    InventoryItemFkNavigationId = table.Column<int>(nullable: true),
                    InventoryItemTypeFkNavigationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inventory_InventoryItem_InventoryItemFkNavigationId",
                        column: x => x.InventoryItemFkNavigationId,
                        principalTable: "InventoryItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Inventory_InventoryItemType_InventoryItemTypeFkNavigationId",
                        column: x => x.InventoryItemTypeFkNavigationId,
                        principalTable: "InventoryItemType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductInfo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProductIdFk = table.Column<int>(nullable: false),
                    ProductName = table.Column<string>(nullable: true),
                    ProductImage = table.Column<string>(nullable: true),
                    CanBeSold = table.Column<bool>(nullable: false),
                    CanBeExpensed = table.Column<bool>(nullable: false),
                    CanBePurchased = table.Column<bool>(nullable: false),
                    ProductTypeIdFk = table.Column<int>(nullable: false),
                    ProductCategoryIdFk = table.Column<int>(nullable: false),
                    ModelSku = table.Column<string>(nullable: true),
                    Upc = table.Column<string>(nullable: true),
                    Ean = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    ProductCategoryIdFkNavigationId = table.Column<int>(nullable: true),
                    ProductIdFkNavigationId = table.Column<int>(nullable: true),
                    ProductTypeIdFkNavigationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductInfo_ProductCategory_ProductCategoryIdFkNavigationId",
                        column: x => x.ProductCategoryIdFkNavigationId,
                        principalTable: "ProductCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductInfo_Product_ProductIdFkNavigationId",
                        column: x => x.ProductIdFkNavigationId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductInfo_ProductType_ProductTypeIdFkNavigationId",
                        column: x => x.ProductTypeIdFkNavigationId,
                        principalTable: "ProductType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CustomerId = table.Column<Guid>(nullable: false),
                    FkSalesManager = table.Column<int>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    EnterpriseName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    PhoneNo = table.Column<string>(nullable: true),
                    MobileNo = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    PaymentMethod = table.Column<string>(nullable: true),
                    FkSalesManagerNavigationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customer_SalesManager_FkSalesManagerNavigationId",
                        column: x => x.FkSalesManagerNavigationId,
                        principalTable: "SalesManager",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SalesOrder",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SalesOrderNo = table.Column<string>(nullable: true),
                    EnterpriseName = table.Column<string>(nullable: true),
                    ProductName = table.Column<string>(nullable: true),
                    Category = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Revenue = table.Column<double>(nullable: false),
                    SalesManagerIdFk = table.Column<int>(nullable: true),
                    SalesPersonAssign = table.Column<string>(nullable: true),
                    CustomerIdFk = table.Column<int>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    CustomerIdFkNavigationId = table.Column<int>(nullable: true),
                    SalesManagerIdFkNavigationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesOrder", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalesOrder_Customer_CustomerIdFkNavigationId",
                        column: x => x.CustomerIdFkNavigationId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesOrder_SalesManager_SalesManagerIdFkNavigationId",
                        column: x => x.SalesManagerIdFkNavigationId,
                        principalTable: "SalesManager",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrderDate = table.Column<DateTime>(nullable: false),
                    CustomerIdFk = table.Column<int>(nullable: true),
                    IsConfirmed = table.Column<bool>(nullable: false),
                    ProductIdFk = table.Column<int>(nullable: false),
                    SalesOrderIdFk = table.Column<int>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    CustomerIdFkNavigationId = table.Column<int>(nullable: true),
                    ProductIdFkNavigationId = table.Column<int>(nullable: true),
                    SalesOrderIdFkNavigationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_Customer_CustomerIdFkNavigationId",
                        column: x => x.CustomerIdFkNavigationId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Order_Product_ProductIdFkNavigationId",
                        column: x => x.ProductIdFkNavigationId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Order_SalesOrder_SalesOrderIdFkNavigationId",
                        column: x => x.SalesOrderIdFkNavigationId,
                        principalTable: "SalesOrder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SalesInvoice",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SalesInvoiceNo = table.Column<string>(nullable: true),
                    SalesInvoiceDate = table.Column<DateTime>(nullable: false),
                    SalesManagerIdFk = table.Column<int>(nullable: true),
                    SalesManagerAssign = table.Column<string>(nullable: true),
                    SalesOrdernoFk = table.Column<int>(nullable: true),
                    PaymentTerm = table.Column<string>(nullable: true),
                    CustomerIdFk = table.Column<int>(nullable: true),
                    CustomerName = table.Column<string>(nullable: true),
                    PaymentDate = table.Column<DateTime>(nullable: false),
                    Discount = table.Column<double>(nullable: false),
                    PoWono = table.Column<string>(nullable: true),
                    ModeOfPayment = table.Column<string>(nullable: true),
                    NotesToCustomer = table.Column<string>(nullable: true),
                    Product = table.Column<string>(nullable: true),
                    Rate = table.Column<double>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    Amount = table.Column<double>(nullable: false),
                    Tax = table.Column<double>(nullable: false),
                    SubTotal = table.Column<double>(nullable: false),
                    ShippingAndHandling = table.Column<string>(nullable: true),
                    Total = table.Column<double>(nullable: false),
                    AmountDue = table.Column<double>(nullable: true),
                    Revenue = table.Column<double>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    CustomerIdFkNavigationId = table.Column<int>(nullable: true),
                    SalesManagerIdFkNavigationId = table.Column<int>(nullable: true),
                    SalesOrdernoFkNavigationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesInvoice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalesInvoice_Customer_CustomerIdFkNavigationId",
                        column: x => x.CustomerIdFkNavigationId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesInvoice_SalesManager_SalesManagerIdFkNavigationId",
                        column: x => x.SalesManagerIdFkNavigationId,
                        principalTable: "SalesManager",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesInvoice_SalesOrder_SalesOrdernoFkNavigationId",
                        column: x => x.SalesOrdernoFkNavigationId,
                        principalTable: "SalesOrder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GoodsNotes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrderIdFk = table.Column<int>(nullable: false),
                    OrderStatus = table.Column<string>(nullable: true),
                    DeliverTo = table.Column<string>(nullable: true),
                    Warehouse = table.Column<string>(nullable: true),
                    Printed = table.Column<bool>(nullable: false),
                    Picked = table.Column<bool>(nullable: false),
                    Packed = table.Column<bool>(nullable: false),
                    Shipped = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    OrderIdFkNavigationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoodsNotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GoodsNotes_Order_OrderIdFkNavigationId",
                        column: x => x.OrderIdFkNavigationId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderLines",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrderIdFk = table.Column<int>(nullable: false),
                    Sku = table.Column<string>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    TotalPrice = table.Column<double>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    OrderIdFkNavigationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderLines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderLines_Order_OrderIdFkNavigationId",
                        column: x => x.OrderIdFkNavigationId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductSelectedForOrder",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrderIdFk = table.Column<int>(nullable: false),
                    ProductIdFk = table.Column<int>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    OrderIdFkNavigationId = table.Column<int>(nullable: true),
                    ProductIdFkNavigationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSelectedForOrder", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductSelectedForOrder_Order_OrderIdFkNavigationId",
                        column: x => x.OrderIdFkNavigationId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductSelectedForOrder_Product_ProductIdFkNavigationId",
                        column: x => x.ProductIdFkNavigationId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customer_FkSalesManagerNavigationId",
                table: "Customer",
                column: "FkSalesManagerNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsNotes_OrderIdFkNavigationId",
                table: "GoodsNotes",
                column: "OrderIdFkNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_InventoryItemFkNavigationId",
                table: "Inventory",
                column: "InventoryItemFkNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_InventoryItemTypeFkNavigationId",
                table: "Inventory",
                column: "InventoryItemTypeFkNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryItem_InventoryItemCategoryFkNavigationId",
                table: "InventoryItem",
                column: "InventoryItemCategoryFkNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_CustomerIdFkNavigationId",
                table: "Order",
                column: "CustomerIdFkNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_ProductIdFkNavigationId",
                table: "Order",
                column: "ProductIdFkNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_SalesOrderIdFkNavigationId",
                table: "Order",
                column: "SalesOrderIdFkNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderLines_OrderIdFkNavigationId",
                table: "OrderLines",
                column: "OrderIdFkNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProductCategoryIdFk",
                table: "Product",
                column: "ProductCategoryIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProductTypeIdFk",
                table: "Product",
                column: "ProductTypeIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_ProductInfo_ProductCategoryIdFkNavigationId",
                table: "ProductInfo",
                column: "ProductCategoryIdFkNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductInfo_ProductIdFkNavigationId",
                table: "ProductInfo",
                column: "ProductIdFkNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductInfo_ProductTypeIdFkNavigationId",
                table: "ProductInfo",
                column: "ProductTypeIdFkNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSelectedForOrder_OrderIdFkNavigationId",
                table: "ProductSelectedForOrder",
                column: "OrderIdFkNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSelectedForOrder_ProductIdFkNavigationId",
                table: "ProductSelectedForOrder",
                column: "ProductIdFkNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseInvoice_SupplierIdFkNavigationId",
                table: "PurchaseInvoice",
                column: "SupplierIdFkNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrder_SupplierIdFkNavigationId",
                table: "PurchaseOrder",
                column: "SupplierIdFkNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesInvoice_CustomerIdFkNavigationId",
                table: "SalesInvoice",
                column: "CustomerIdFkNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesInvoice_SalesManagerIdFkNavigationId",
                table: "SalesInvoice",
                column: "SalesManagerIdFkNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesInvoice_SalesOrdernoFkNavigationId",
                table: "SalesInvoice",
                column: "SalesOrdernoFkNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesManager_RoleIdFkNavigationId",
                table: "SalesManager",
                column: "RoleIdFkNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrder_CustomerIdFkNavigationId",
                table: "SalesOrder",
                column: "CustomerIdFkNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrder_SalesManagerIdFkNavigationId",
                table: "SalesOrder",
                column: "SalesManagerIdFkNavigationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "GoodsNotes");

            migrationBuilder.DropTable(
                name: "Inventory");

            migrationBuilder.DropTable(
                name: "OrderLines");

            migrationBuilder.DropTable(
                name: "Price");

            migrationBuilder.DropTable(
                name: "ProductInfo");

            migrationBuilder.DropTable(
                name: "ProductOption");

            migrationBuilder.DropTable(
                name: "ProductSelectedForOrder");

            migrationBuilder.DropTable(
                name: "PurchaseInvoice");

            migrationBuilder.DropTable(
                name: "PurchaseOrder");

            migrationBuilder.DropTable(
                name: "SalesInvoice");

            migrationBuilder.DropTable(
                name: "SalesPerson");

            migrationBuilder.DropTable(
                name: "ShoppingCartViewModel");

            migrationBuilder.DropTable(
                name: "InventoryItem");

            migrationBuilder.DropTable(
                name: "InventoryItemType");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Supplier");

            migrationBuilder.DropTable(
                name: "InventoryItemCategory");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "SalesOrder");

            migrationBuilder.DropTable(
                name: "ProductCategory");

            migrationBuilder.DropTable(
                name: "ProductType");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "SalesManager");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Users");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");
        }
    }
}
