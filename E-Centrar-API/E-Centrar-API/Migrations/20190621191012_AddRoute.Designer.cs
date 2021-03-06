﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ServiceLayers.Model;

namespace ECentrarApi.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20190621191012_AddRoute")]
    partial class AddRoute
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ServiceLayer.Model.Route", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime>("DateOfVisit");

                    b.Property<string>("RouteName");

                    b.Property<int>("SalesPerson");

                    b.Property<string>("UpdatedBy");

                    b.Property<DateTime>("UpdatedDate");

                    b.Property<bool>("isActive");

                    b.Property<bool>("isRepeatable");

                    b.HasKey("Id");

                    b.HasIndex("SalesPerson");

                    b.ToTable("Route");
                });

            modelBuilder.Entity("ServiceLayers.Model.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<Guid>("CustomerId");

                    b.Property<string>("Email");

                    b.Property<string>("EnterpriseName");

                    b.Property<int>("FK_RouteId");

                    b.Property<int>("FK_SalesManager");

                    b.Property<string>("FirstName");

                    b.Property<bool>("IsActive");

                    b.Property<string>("LastName");

                    b.Property<float>("Latitude");

                    b.Property<float>("Longitude");

                    b.Property<string>("MobileNo");

                    b.Property<string>("PaymentMethod");

                    b.Property<string>("PhoneNo");

                    b.Property<string>("UpdatedBy");

                    b.Property<DateTime?>("UpdatedDate");

                    b.HasKey("Id");

                    b.HasIndex("FK_RouteId");

                    b.HasIndex("FK_SalesManager");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("ServiceLayers.Model.Data", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("col_current_date");

                    b.Property<string>("latitude");

                    b.Property<string>("longitude");

                    b.HasKey("Id");

                    b.ToTable("Data");
                });

            modelBuilder.Entity("ServiceLayers.Model.GoodsNotes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("DeliverTo");

                    b.Property<bool>("IsActive");

                    b.Property<int>("OrderIdFk");

                    b.Property<string>("OrderStatus");

                    b.Property<bool>("Packed");

                    b.Property<bool>("Picked");

                    b.Property<bool>("Printed");

                    b.Property<bool>("Shipped");

                    b.Property<string>("UpdatedBy");

                    b.Property<DateTime?>("UpdatedDate");

                    b.Property<string>("Warehouse");

                    b.HasKey("Id");

                    b.HasIndex("OrderIdFk");

                    b.ToTable("GoodsNotes");
                });

            modelBuilder.Entity("ServiceLayers.Model.Inventory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Amount");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("DefaultLocation");

                    b.Property<bool>("IsActive");

                    b.Property<int>("MinimumStockLevel");

                    b.Property<int>("ReorderQuantity");

                    b.Property<int>("Unit");

                    b.Property<string>("UpdatedBy");

                    b.Property<DateTime?>("UpdatedDate");

                    b.HasKey("Id");

                    b.ToTable("Inventory");
                });

            modelBuilder.Entity("ServiceLayers.Model.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<int>("CustomerIdFk");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsConfirmed");

                    b.Property<DateTime>("OrderDate");

                    b.Property<int>("ProductIdFk");

                    b.Property<string>("UpdatedBy");

                    b.Property<DateTime?>("UpdatedDate");

                    b.HasKey("Id");

                    b.HasIndex("CustomerIdFk");

                    b.HasIndex("ProductIdFk");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("ServiceLayers.Model.OrderLines", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<bool>("IsActive");

                    b.Property<int>("OrderIdFk");

                    b.Property<double>("Price");

                    b.Property<int>("Quantity");

                    b.Property<string>("Sku");

                    b.Property<double>("TotalPrice");

                    b.Property<string>("UpdatedBy");

                    b.Property<DateTime?>("UpdatedDate");

                    b.HasKey("Id");

                    b.HasIndex("OrderIdFk");

                    b.ToTable("OrderLines");
                });

            modelBuilder.Entity("ServiceLayers.Model.Price", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Count");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<bool>("IsActive");

                    b.Property<double>("Price1");

                    b.Property<string>("UpdatedBy");

                    b.Property<DateTime?>("UpdatedDate");

                    b.HasKey("Id");

                    b.ToTable("Price");
                });

            modelBuilder.Entity("ServiceLayers.Model.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<bool>("Fullfilled");

                    b.Property<bool>("Instock");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("OnHand");

                    b.Property<int>("ProductCategoryIdFk");

                    b.Property<string>("ProductImage");

                    b.Property<string>("ProductName");

                    b.Property<int>("ProductTypeIdFk");

                    b.Property<string>("Sku");

                    b.Property<string>("UpdatedBy");

                    b.Property<DateTime?>("UpdatedDate");

                    b.Property<string>("Variants");

                    b.HasKey("Id");

                    b.HasIndex("ProductCategoryIdFk");

                    b.HasIndex("ProductTypeIdFk");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("ServiceLayers.Model.ProductCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<bool>("IsActive");

                    b.Property<string>("ProductCategoryName");

                    b.Property<string>("UpdatedBy");

                    b.Property<DateTime?>("UpdatedDate");

                    b.HasKey("Id");

                    b.ToTable("ProductCategory");
                });

            modelBuilder.Entity("ServiceLayers.Model.ProductInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("CanBeExpensed");

                    b.Property<bool>("CanBePurchased");

                    b.Property<bool>("CanBeSold");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Ean");

                    b.Property<bool>("IsActive");

                    b.Property<string>("ModelSku");

                    b.Property<int>("ProductIdFk");

                    b.Property<string>("ProductImage");

                    b.Property<string>("ProductName");

                    b.Property<string>("Upc");

                    b.Property<string>("UpdatedBy");

                    b.Property<DateTime?>("UpdatedDate");

                    b.HasKey("Id");

                    b.HasIndex("ProductIdFk");

                    b.ToTable("ProductInfo");
                });

            modelBuilder.Entity("ServiceLayers.Model.ProductOption", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<bool>("IsActive");

                    b.Property<string>("Name");

                    b.Property<string>("Option");

                    b.Property<string>("UpdatedBy");

                    b.Property<DateTime?>("UpdatedDate");

                    b.HasKey("Id");

                    b.ToTable("ProductOption");
                });

            modelBuilder.Entity("ServiceLayers.Model.ProductType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("ProductTypeName");

                    b.Property<string>("UpdatedBy");

                    b.Property<DateTime?>("UpdatedDate");

                    b.HasKey("Id");

                    b.ToTable("ProductType");
                });

            modelBuilder.Entity("ServiceLayers.Model.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<bool>("IsActive");

                    b.Property<string>("RoleName");

                    b.Property<string>("UpdatedBy");

                    b.Property<DateTime?>("UpdatedDate");

                    b.HasKey("Id");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("ServiceLayers.Model.SalesInvoice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Amount");

                    b.Property<double?>("AmountDue");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<int>("CustomerIdFk");

                    b.Property<string>("CustomerName");

                    b.Property<double>("Discount");

                    b.Property<bool>("IsActive");

                    b.Property<string>("ModeOfPayment");

                    b.Property<string>("NotesToCustomer");

                    b.Property<string>("PO_WOno");

                    b.Property<DateTime>("PaymentDate");

                    b.Property<string>("PaymentTerm");

                    b.Property<string>("Product");

                    b.Property<int>("Quantity");

                    b.Property<double>("Rate");

                    b.Property<double>("Revenue");

                    b.Property<DateTime>("SalesInvoiceDate");

                    b.Property<string>("SalesInvoiceNo");

                    b.Property<string>("SalesManagerAssign");

                    b.Property<string>("ShippingAndHandling");

                    b.Property<double>("SubTotal");

                    b.Property<double>("Tax");

                    b.Property<double>("Total");

                    b.Property<string>("UpdatedBy");

                    b.Property<DateTime?>("UpdatedDate");

                    b.HasKey("Id");

                    b.HasIndex("CustomerIdFk");

                    b.ToTable("SalesInvoice");
                });

            modelBuilder.Entity("ServiceLayers.Model.SalesManager", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<bool>("IsActive");

                    b.Property<string>("LastName");

                    b.Property<string>("MobileNo");

                    b.Property<string>("Password");

                    b.Property<string>("PhoneNo");

                    b.Property<int>("RoleIdFk");

                    b.Property<string>("Salary");

                    b.Property<Guid>("SalesManagerId");

                    b.Property<string>("UpdatedBy");

                    b.Property<DateTime?>("UpdatedDate");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.HasIndex("RoleIdFk");

                    b.ToTable("SalesManager");
                });

            modelBuilder.Entity("ServiceLayers.Model.SalesOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Category");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<int>("CustomerIdFk");

                    b.Property<string>("EnterpriseName");

                    b.Property<bool>("IsActive");

                    b.Property<string>("ProductName");

                    b.Property<double>("Revenue");

                    b.Property<string>("SalesOrderNo");

                    b.Property<string>("SalesPersonAssign");

                    b.Property<string>("Status");

                    b.Property<string>("UpdatedBy");

                    b.Property<DateTime?>("UpdatedDate");

                    b.HasKey("Id");

                    b.HasIndex("CustomerIdFk");

                    b.ToTable("SalesOrder");
                });

            modelBuilder.Entity("ServiceLayers.Model.SalesPerson", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("FirstName");

                    b.Property<bool>("IsActive");

                    b.Property<string>("LastName");

                    b.Property<string>("MobileNo");

                    b.Property<string>("Password");

                    b.Property<string>("PhoneNo");

                    b.Property<string>("Salary");

                    b.Property<Guid>("SalesPersonId");

                    b.Property<string>("UpdatedBy");

                    b.Property<DateTime?>("UpdatedDate");

                    b.Property<string>("UserName");

                    b.Property<string>("VehicleNo");

                    b.HasKey("Id");

                    b.ToTable("SalesPerson");
                });

            modelBuilder.Entity("ServiceLayers.Model.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ContactNo");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<bool>("IsActive");

                    b.Property<string>("LastName");

                    b.Property<byte[]>("PasswordHash");

                    b.Property<byte[]>("PasswordSalt");

                    b.Property<string>("ResidentialAddress");

                    b.Property<int>("RoleId");

                    b.Property<string>("UpdatedBy");

                    b.Property<DateTime>("UpdatedDate");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("ServiceLayer.Model.Route", b =>
                {
                    b.HasOne("ServiceLayers.Model.User", "GetSalesPerson")
                        .WithMany()
                        .HasForeignKey("SalesPerson")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ServiceLayers.Model.Customer", b =>
                {
                    b.HasOne("ServiceLayer.Model.Route", "Route")
                        .WithMany()
                        .HasForeignKey("FK_RouteId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ServiceLayers.Model.User", "User")
                        .WithMany()
                        .HasForeignKey("FK_SalesManager")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ServiceLayers.Model.GoodsNotes", b =>
                {
                    b.HasOne("ServiceLayers.Model.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderIdFk")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ServiceLayers.Model.Order", b =>
                {
                    b.HasOne("ServiceLayers.Model.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerIdFk")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ServiceLayers.Model.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductIdFk")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ServiceLayers.Model.OrderLines", b =>
                {
                    b.HasOne("ServiceLayers.Model.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderIdFk")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ServiceLayers.Model.Product", b =>
                {
                    b.HasOne("ServiceLayers.Model.ProductCategory", "ProductCategory")
                        .WithMany()
                        .HasForeignKey("ProductCategoryIdFk")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ServiceLayers.Model.ProductType", "ProductType")
                        .WithMany()
                        .HasForeignKey("ProductTypeIdFk")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ServiceLayers.Model.ProductInfo", b =>
                {
                    b.HasOne("ServiceLayers.Model.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductIdFk")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ServiceLayers.Model.SalesInvoice", b =>
                {
                    b.HasOne("ServiceLayers.Model.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerIdFk")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ServiceLayers.Model.SalesManager", b =>
                {
                    b.HasOne("ServiceLayers.Model.ProductType", "ProductType")
                        .WithMany()
                        .HasForeignKey("RoleIdFk")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ServiceLayers.Model.SalesOrder", b =>
                {
                    b.HasOne("ServiceLayers.Model.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerIdFk")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ServiceLayers.Model.User", b =>
                {
                    b.HasOne("ServiceLayers.Model.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
