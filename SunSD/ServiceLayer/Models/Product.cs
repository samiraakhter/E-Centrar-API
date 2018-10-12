using System;
using System.Collections.Generic;

namespace ServiceLayer.Models
{
    public partial class Product
    {
        public Product()
        {
            ProductInfo = new HashSet<ProductInfo>();
            ProductSelectedForOrder = new HashSet<ProductSelectedForOrder>();
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductImage { get; set; }
        public string Sku { get; set; }
        public string Variants { get; set; }
        public int ProductTypeIdFk { get; set; }
        public int ProductCategoryIdFk { get; set; }
        public bool OnHand { get; set; }
        public bool Fullfilled { get; set; }
        public bool Instock { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }

        public ProductCategory ProductCategoryIdFkNavigation { get; set; }
        public ProductType ProductTypeIdFkNavigation { get; set; }
        public ICollection<ProductInfo> ProductInfo { get; set; }
        public ICollection<ProductSelectedForOrder> ProductSelectedForOrder { get; set; }
    }
}
