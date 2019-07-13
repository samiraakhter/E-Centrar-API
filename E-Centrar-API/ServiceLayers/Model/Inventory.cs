using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServiceLayers.Model
{
    public partial class Inventory
    {
        public int Id { get; set; }
        public double Amount { get; set; }
        public string Unit { get; set; }
        public int MinimumStockLevel { get; set; }
        public int ReorderQuantity { get; set; }
        public string DefaultLocation { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }

        [Display(Name = "Product")]
        public int ProductFk { get; set; }

        [ForeignKey("ProductFk")]
        public virtual Product Product { get; set; }

        //[Display(Name = "Inventory Item Type")]
        //public int InventoryItemTypeFk { get; set; }

        //[ForeignKey("InventoryItemTypeFk")]
        //public virtual InventoryItemType InventoryItemType { get; set; }


        //public int? InventoryItemFk { get; set; }
        //public int? InventoryItemTypeFk { get; set; }

        //public InventoryItem InventoryItemFkNavigation { get; set; }
        //public InventoryItemType InventoryItemTypeFkNavigation { get; set; }
    }
}
