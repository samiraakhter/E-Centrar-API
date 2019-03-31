using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayers.DTOs
{
   public class ProductInfoDTO
    {
        public int Id { get; set; }
        public int ProductIdFk { get; set; }
        public string ProductName { get; set; }
        public string ProductImage { get; set; }
        public bool CanBeSold { get; set; }
        public bool CanBeExpensed { get; set; }
        public bool CanBePurchased { get; set; }
        public int ProductTypeIdFk { get; set; }
        public int ProductCategoryIdFk { get; set; }
        public string ModelSku { get; set; }
        public string Upc { get; set; }
        public string Ean { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }

    }
}
