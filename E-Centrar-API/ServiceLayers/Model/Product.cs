using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServiceLayers.Model
{
    public class Product
    {
        //public Product()
        //{
        //    Order = new HashSet<Order>();
        //    ProductInfo = new HashSet<ProductInfo>();
        //    ProductSelectedForOrder = new HashSet<ProductSelectedForOrder>();
        //}

        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductImage { get; set; }
        public string Sku { get; set; }
        public string Variants { get; set; }

        [Display(Name = "Product Type")]
        public int ProductTypeIdFk { get; set; }

        [ForeignKey("ProductTypeIdFk")]
        public virtual ProductType ProductType { get; set; }

        [Display(Name = "Product Category")]
        public int ProductCategoryIdFk { get; set; }

        [ForeignKey("ProductCategoryIdFk")]
        public virtual ProductCategory ProductCategory { get; set; }
        
        public bool OnHand { get; set; }
        public bool Fullfilled { get; set; }
        public int Instock { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }

        //public ProductCategory ProductCategoryIdFkNavigation { get; set; }
        //public ProductType ProductTypeIdFkNavigation { get; set; }
        //public ICollection<Order> Order { get; set; }
        //public ICollection<ProductInfo> ProductInfo { get; set; }
        //public ICollection<ProductSelectedForOrder> ProductSelectedForOrder { get; set; }
    }
}
