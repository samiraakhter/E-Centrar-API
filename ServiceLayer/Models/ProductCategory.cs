using System;
using System.Collections.Generic;

namespace ServiceLayer.Models
{
    public partial class ProductCategory
    {
        public ProductCategory()
        {
            Product = new HashSet<Product>();
            ProductInfo = new HashSet<ProductInfo>();
        }

        public int ProductCategoryId { get; set; }
        public string ProductCategoryName { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }

        public ICollection<Product> Product { get; set; }
        public ICollection<ProductInfo> ProductInfo { get; set; }
    }
}
