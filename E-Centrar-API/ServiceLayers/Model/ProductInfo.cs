using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServiceLayers.Model
{
    public partial class ProductInfo
    {
        public int Id { get; set; }

        [Display(Name = "Product")]
        public int ProductIdFk { get; set; }

        [ForeignKey("ProductIdFk")]
        public virtual Product Product { get; set; }
        //public int ProductIdFk { get; set; }

        public string ProductName { get; set; }
        public string ProductImage { get; set; }
        public bool CanBeSold { get; set; }
        public bool CanBeExpensed { get; set; }
        public bool CanBePurchased { get; set; }

        [Display(Name = "Product Type")]
        public int ProductTypeIdFk { get; set; }

        [ForeignKey("ProductTypeIdFk")]
        public virtual ProductType ProductType { get; set; }
        //public int ProductTypeIdFk { get; set; }

        [Display(Name = "Product Category")]
        public int ProductCategoryIdFk { get; set; }

        [ForeignKey("ProductCategoryIdFk")]
        public virtual ProductCategory ProductCategory { get; set; }

        //public int ProductCategoryIdFk { get; set; }
        public string ModelSku { get; set; }
        public string Upc { get; set; }
        public string Ean { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }

        //public ProductCategory ProductCategoryIdFkNavigation { get; set; }
        //public Product ProductIdFkNavigation { get; set; }
        //public ProductType ProductTypeIdFkNavigation { get; set; }
    }
}
