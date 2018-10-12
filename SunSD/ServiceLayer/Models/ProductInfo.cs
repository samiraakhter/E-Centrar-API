﻿using System;
using System.Collections.Generic;

namespace ServiceLayer.Models
{
    public partial class ProductInfo
    {
        public int ProductInfoId { get; set; }
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

        public ProductCategory ProductCategoryIdFkNavigation { get; set; }
        public Product ProductIdFkNavigation { get; set; }
        public ProductType ProductTypeIdFkNavigation { get; set; }
    }
}
