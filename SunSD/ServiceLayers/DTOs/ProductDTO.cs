using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayers.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }
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
    }
}
