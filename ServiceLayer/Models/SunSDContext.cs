using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ServiceLayer.Models
{
    public partial class SunSDContext : DbContext
    {
        public SunSDContext()
        {
        }

        public SunSDContext(DbContextOptions<SunSDContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admin { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<GoodsNotes> GoodsNotes { get; set; }
        public virtual DbSet<Inventory> Inventory { get; set; }
        public virtual DbSet<InventoryItem> InventoryItem { get; set; }
        public virtual DbSet<InventoryItemCategory> InventoryItemCategory { get; set; }
        public virtual DbSet<InventoryItemType> InventoryItemType { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderLines> OrderLines { get; set; }
        public virtual DbSet<Price> Price { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductCategory> ProductCategory { get; set; }
        public virtual DbSet<ProductInfo> ProductInfo { get; set; }
        public virtual DbSet<ProductOption> ProductOption { get; set; }
        public virtual DbSet<ProductSelectedForOrder> ProductSelectedForOrder { get; set; }
        public virtual DbSet<ProductType> ProductType { get; set; }
        public virtual DbSet<PurchaseInvoice> PurchaseInvoice { get; set; }
        public virtual DbSet<PurchaseOrder> PurchaseOrder { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<SalesInvoice> SalesInvoice { get; set; }
        public virtual DbSet<SalesManager> SalesManager { get; set; }
        public virtual DbSet<SalesOrder> SalesOrder { get; set; }
        public virtual DbSet<SalesPerson> SalesPerson { get; set; }
        public virtual DbSet<ShoppingCartViewModel> ShoppingCartViewModel { get; set; }
        public virtual DbSet<Supplier> Supplier { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-HA8BMJ0\\SQLEXPRESS;Database=SunSD;Integrated Security=True;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>(entity =>
            {
                entity.Property(e => e.AdminId).ValueGeneratedNever();

                entity.Property(e => e.AdminName)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.UpdatedBy).HasMaxLength(128);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(128);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.CustomerId).ValueGeneratedNever();

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.EnterpriseName)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.MobileNo)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.PaymentMethod)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.PhoneNo)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.SalesManagerIdFk).HasColumnName("SalesManagerIdFK");

                entity.Property(e => e.UpdatedBy).HasMaxLength(128);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.SalesManagerIdFkNavigation)
                    .WithMany(p => p.Customer)
                    .HasForeignKey(d => d.SalesManagerIdFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Customer_SalesManagerI");
            });

            modelBuilder.Entity<GoodsNotes>(entity =>
            {
                entity.Property(e => e.GoodsNotesId)
                    .HasColumnName("GoodsNotesID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DeliverTo)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.OrderIdFk).HasColumnName("OrderIdFK");

                entity.Property(e => e.OrderStatus)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.Packed).HasColumnName("packed");

                entity.Property(e => e.Picked).HasColumnName("picked");

                entity.Property(e => e.Printed).HasColumnName("printed");

                entity.Property(e => e.Shipped).HasColumnName("shipped");

                entity.Property(e => e.UpdatedBy).HasMaxLength(128);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.Warehouse)
                    .IsRequired()
                    .HasMaxLength(128);
            });

            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.Property(e => e.InventoryId).ValueGeneratedNever();

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DefaultLocation).IsRequired();

                entity.Property(e => e.InventoryItemFk).HasColumnName("InventoryItemFK");

                entity.Property(e => e.InventoryItemTypeFk).HasColumnName("InventoryItemTypeFK");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.UpdatedBy).HasMaxLength(128);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.InventoryItemFkNavigation)
                    .WithMany(p => p.Inventory)
                    .HasForeignKey(d => d.InventoryItemFk)
                    .HasConstraintName("FK_Inventory_InventoryItem");

                entity.HasOne(d => d.InventoryItemTypeFkNavigation)
                    .WithMany(p => p.Inventory)
                    .HasForeignKey(d => d.InventoryItemTypeFk)
                    .HasConstraintName("FK_Inventory_InventoryItemType");
            });

            modelBuilder.Entity<InventoryItem>(entity =>
            {
                entity.Property(e => e.InventoryItemId).ValueGeneratedNever();

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.InventoryItemCategoryFk).HasColumnName("InventoryItemCategoryFK");

                entity.Property(e => e.InventoryItemName)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.UpdatedBy).HasMaxLength(128);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.InventoryItemCategoryFkNavigation)
                    .WithMany(p => p.InventoryItem)
                    .HasForeignKey(d => d.InventoryItemCategoryFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InventoryItem_InventoryItemCategory");
            });

            modelBuilder.Entity<InventoryItemCategory>(entity =>
            {
                entity.Property(e => e.InventoryItemCategoryId).ValueGeneratedNever();

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.InventoryItemCategoryName)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.UpdatedBy).HasMaxLength(128);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<InventoryItemType>(entity =>
            {
                entity.Property(e => e.InventoryItemTypeId).ValueGeneratedNever();

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.InventoryItemTypeName)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.UpdatedBy).HasMaxLength(128);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.OrderId).ValueGeneratedNever();

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.CustomerIdFk).HasColumnName("CustomerIdFK");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.OrderDate).HasColumnType("datetime");

                entity.Property(e => e.ProductIdFk).HasColumnName("ProductIdFK");

                entity.Property(e => e.SalesOrderIdFk)
                    .IsRequired()
                    .HasColumnName("SalesOrderIdFK")
                    .HasMaxLength(128);

                entity.Property(e => e.UpdatedBy).HasMaxLength(128);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<OrderLines>(entity =>
            {
                entity.Property(e => e.OrderLinesId).ValueGeneratedNever();

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.OrderIdFk).HasColumnName("OrderIdFK");

                entity.Property(e => e.Sku)
                    .IsRequired()
                    .HasColumnName("SKU")
                    .HasMaxLength(128);

                entity.Property(e => e.UpdatedBy).HasMaxLength(128);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.OrderIdFkNavigation)
                    .WithMany(p => p.OrderLines)
                    .HasForeignKey(d => d.OrderIdFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderLines_OrderId");
            });

            modelBuilder.Entity<Price>(entity =>
            {
                entity.Property(e => e.PriceId).ValueGeneratedNever();

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.Price1).HasColumnName("Price");

                entity.Property(e => e.UpdatedBy).HasMaxLength(128);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.ProductId).ValueGeneratedNever();

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.ProductCategoryIdFk).HasColumnName("ProductCategoryIdFK");

                entity.Property(e => e.ProductImage)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.ProductTypeIdFk).HasColumnName("ProductTypeIdFK");

                entity.Property(e => e.Sku)
                    .IsRequired()
                    .HasColumnName("SKU")
                    .HasMaxLength(128);

                entity.Property(e => e.UpdatedBy).HasMaxLength(128);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.Variants).HasMaxLength(128);

                entity.HasOne(d => d.ProductCategoryIdFkNavigation)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.ProductCategoryIdFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_ProductCategory");

                entity.HasOne(d => d.ProductTypeIdFkNavigation)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.ProductTypeIdFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_ProductType");
            });

            modelBuilder.Entity<ProductCategory>(entity =>
            {
                entity.Property(e => e.ProductCategoryId).ValueGeneratedNever();

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.ProductCategoryName)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.UpdatedBy).HasMaxLength(128);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<ProductInfo>(entity =>
            {
                entity.Property(e => e.ProductInfoId).ValueGeneratedNever();

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Ean)
                    .IsRequired()
                    .HasColumnName("EAN")
                    .HasMaxLength(128);

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.ModelSku)
                    .IsRequired()
                    .HasColumnName("Model_SKU")
                    .HasMaxLength(128);

                entity.Property(e => e.ProductCategoryIdFk).HasColumnName("ProductCategoryIdFK");

                entity.Property(e => e.ProductIdFk).HasColumnName("ProductIdFK");

                entity.Property(e => e.ProductImage)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.ProductTypeIdFk).HasColumnName("ProductTypeIdFK");

                entity.Property(e => e.Upc)
                    .IsRequired()
                    .HasColumnName("UPC")
                    .HasMaxLength(128);

                entity.Property(e => e.UpdatedBy).HasMaxLength(128);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.ProductCategoryIdFkNavigation)
                    .WithMany(p => p.ProductInfo)
                    .HasForeignKey(d => d.ProductCategoryIdFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductInfo_ProductCategory");

                entity.HasOne(d => d.ProductIdFkNavigation)
                    .WithMany(p => p.ProductInfo)
                    .HasForeignKey(d => d.ProductIdFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductInfo_Product");

                entity.HasOne(d => d.ProductTypeIdFkNavigation)
                    .WithMany(p => p.ProductInfo)
                    .HasForeignKey(d => d.ProductTypeIdFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductInfo_ProductType");
            });

            modelBuilder.Entity<ProductOption>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.Option)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.UpdatedBy).HasMaxLength(128);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<ProductSelectedForOrder>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.OrderIdFk).HasColumnName("OrderIdFK");

                entity.Property(e => e.ProductIdFk).HasColumnName("ProductIdFK");

                entity.Property(e => e.UpdatedBy).HasMaxLength(128);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.OrderIdFkNavigation)
                    .WithMany(p => p.ProductSelectedForOrder)
                    .HasForeignKey(d => d.OrderIdFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductSelectedForOrder_OrderId");

                entity.HasOne(d => d.ProductIdFkNavigation)
                    .WithMany(p => p.ProductSelectedForOrder)
                    .HasForeignKey(d => d.ProductIdFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductSelectedForOrder_ProductId");
            });

            modelBuilder.Entity<ProductType>(entity =>
            {
                entity.Property(e => e.ProductTypeId).ValueGeneratedNever();

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ProductTypeName)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.UpdatedBy).HasMaxLength(128);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<PurchaseInvoice>(entity =>
            {
                entity.Property(e => e.PurchaseInvoiceId)
                    .HasMaxLength(128)
                    .ValueGeneratedNever();

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DueDate).HasColumnType("datetime");

                entity.Property(e => e.InvoiceDate).HasColumnType("datetime");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.PaymentDate).HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.SupplierIdFk).HasColumnName("SupplierIdFK");

                entity.Property(e => e.UpdatedBy).HasMaxLength(128);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.SupplierIdFkNavigation)
                    .WithMany(p => p.PurchaseInvoice)
                    .HasForeignKey(d => d.SupplierIdFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PurchaseInvoice_SupplierId");
            });

            modelBuilder.Entity<PurchaseOrder>(entity =>
            {
                entity.Property(e => e.PurchaseOrderId)
                    .HasMaxLength(128)
                    .ValueGeneratedNever();

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.OrderDate).HasColumnType("datetime");

                entity.Property(e => e.Reference).HasMaxLength(128);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.SupplierIdFk).HasColumnName("SupplierIdFK");

                entity.Property(e => e.Untaxed).HasMaxLength(128);

                entity.Property(e => e.UpdatedBy).HasMaxLength(128);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.SupplierIdFkNavigation)
                    .WithMany(p => p.PurchaseOrder)
                    .HasForeignKey(d => d.SupplierIdFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PurchaseOrder_SupplierIdFK");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.RoleId).ValueGeneratedNever();

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.UpdatedBy).HasMaxLength(128);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<SalesInvoice>(entity =>
            {
                entity.HasKey(e => e.SalesInvoiceNo);

                entity.Property(e => e.SalesInvoiceNo)
                    .HasMaxLength(128)
                    .ValueGeneratedNever();

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.CustomerIdFk).HasColumnName("CustomerIdFK");

                entity.Property(e => e.CustomerName)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.ModeOfPayment)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.NotesToCustomer).IsRequired();

                entity.Property(e => e.PaymentDate).HasColumnType("datetime");

                entity.Property(e => e.PaymentTerm)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.PoWono)
                    .IsRequired()
                    .HasColumnName("PO_WONo")
                    .HasMaxLength(128);

                entity.Property(e => e.Product)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.SalesInvoiceDate).HasColumnType("datetime");

                entity.Property(e => e.SalesManagerAssign)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.SalesManagerIdFk).HasColumnName("SalesManagerIdFK");

                entity.Property(e => e.SalesOrdernoFk)
                    .IsRequired()
                    .HasColumnName("SalesOrdernoFK")
                    .HasMaxLength(128);

                entity.Property(e => e.ShippingAndHandling).IsRequired();

                entity.Property(e => e.UpdatedBy).HasMaxLength(128);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.CustomerIdFkNavigation)
                    .WithMany(p => p.SalesInvoice)
                    .HasForeignKey(d => d.CustomerIdFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SalesInvoice_Customer");

                entity.HasOne(d => d.SalesManagerIdFkNavigation)
                    .WithMany(p => p.SalesInvoice)
                    .HasForeignKey(d => d.SalesManagerIdFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SalesInvoice_SupplierIdFK");

                entity.HasOne(d => d.SalesOrdernoFkNavigation)
                    .WithMany(p => p.SalesInvoice)
                    .HasForeignKey(d => d.SalesOrdernoFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SalesInvoice_SalesOrderNo");
            });

            modelBuilder.Entity<SalesManager>(entity =>
            {
                entity.Property(e => e.SalesManagerId).ValueGeneratedNever();

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.MobileNo)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.PhoneNo)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.RoleIdFk).HasColumnName("RoleIdFK");

                entity.Property(e => e.Salary)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.UpdatedBy).HasMaxLength(128);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.HasOne(d => d.RoleIdFkNavigation)
                    .WithMany(p => p.SalesManager)
                    .HasForeignKey(d => d.RoleIdFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SalesManager_RoleIdFK");
            });

            modelBuilder.Entity<SalesOrder>(entity =>
            {
                entity.HasKey(e => e.SalesOrderNo);

                entity.Property(e => e.SalesOrderNo)
                    .HasMaxLength(128)
                    .ValueGeneratedNever();

                entity.Property(e => e.Category)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.CustomerIdFk).HasColumnName("CustomerIdFK");

                entity.Property(e => e.EnterpriseName)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.SalesManagerIdFk).HasColumnName("SalesManagerIdFK");

                entity.Property(e => e.SalesPersonAssign)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.UpdatedBy).HasMaxLength(128);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.CustomerIdFkNavigation)
                    .WithMany(p => p.SalesOrder)
                    .HasForeignKey(d => d.CustomerIdFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SalesOrder_CustomerId");

                entity.HasOne(d => d.SalesManagerIdFkNavigation)
                    .WithMany(p => p.SalesOrder)
                    .HasForeignKey(d => d.SalesManagerIdFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SalesOrder_SalesManagerIdFK");
            });

            modelBuilder.Entity<SalesPerson>(entity =>
            {
                entity.Property(e => e.SalesPersonId).ValueGeneratedNever();

                entity.Property(e => e.Address).IsRequired();

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.MobileNo)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.PhoneNo).HasMaxLength(128);

                entity.Property(e => e.Salary)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.UpdatedBy).HasMaxLength(128);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.VehicleNo)
                    .IsRequired()
                    .HasMaxLength(128);
            });

            modelBuilder.Entity<ShoppingCartViewModel>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.ProductList).IsRequired();

                entity.Property(e => e.UpdatedBy).HasMaxLength(128);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.Property(e => e.SupplierId).ValueGeneratedNever();

                entity.Property(e => e.Address).IsRequired();

                entity.Property(e => e.Company).IsRequired();

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.PaymentMethod)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.PhoneNo).IsRequired();

                entity.Property(e => e.Suppliername)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.UpdatedBy).HasMaxLength(128);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });
        }
    }
}
