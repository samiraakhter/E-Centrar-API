using System;
using System.Collections.Generic;

namespace ServiceLayers.Model
{
    public class ProductType
    {
        //public ProductType()
        //{
        //    Product = new HashSet<Product>();
        //    ProductInfo = new HashSet<ProductInfo>();
        //}

        public int Id { get; set; }
        public string ProductTypeName { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

        //public ICollection<Product> Product { get; set; }
        //public ICollection<ProductInfo> ProductInfo { get; set; }
    }
}
