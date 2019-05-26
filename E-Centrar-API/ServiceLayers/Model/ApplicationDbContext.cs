using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayers.Model
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }
        public DbSet<User> User { get; set; }
        public DbSet<Data> Data { get; set; }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<GoodsNotes> GoodsNotes { get; set; }
        public DbSet<Inventory> Inventory { get; set; }
        public DbSet<InventoryItem> InventoryItem { get; set; }
        public DbSet<InventoryItemCategory> InventoryItemCategory { get; set; }
        public DbSet<InventoryItemType> InventoryItemType { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderLines> OrderLines { get; set; }
        public DbSet<Price> Price { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductCategory> ProductCategory { get; set; }
        public DbSet<ProductInfo> ProductInfo { get; set; }
        public DbSet<ProductOption> ProductOption { get; set; }
        public DbSet<ProductSelectedForOrder> ProductSelectedForOrder { get; set; }
        public DbSet<ProductType> ProductType { get; set; }
        public DbSet<PurchaseInvoice> PurchaseInvoice { get; set; }
        public DbSet<PurchaseOrder> PurchaseOrder { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<SalesInvoice> SalesInvoice { get; set; }
        public DbSet<SalesManager> SalesManager { get; set; }
        public DbSet<SalesOrder> SalesOrder { get; set; }
        public DbSet<SalesPerson> SalesPerson { get; set; }
        public DbSet<ShoppingCartViewModel> ShoppingCartViewModel { get; set; }
        public DbSet<Supplier> Supplier { get; set; }
    }
}
