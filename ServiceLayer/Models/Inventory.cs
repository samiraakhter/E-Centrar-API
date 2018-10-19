using System;
using System.Collections.Generic;

namespace ServiceLayer.Models
{
    public partial class Inventory
    {
        public int InventoryId { get; set; }
        public double Amount { get; set; }
        public int Unit { get; set; }
        public int MinimumStockLevel { get; set; }
        public int ReorderQuantity { get; set; }
        public string DefaultLocation { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public int? InventoryItemFk { get; set; }
        public int? InventoryItemTypeFk { get; set; }

        public InventoryItem InventoryItemFkNavigation { get; set; }
        public InventoryItemType InventoryItemTypeFkNavigation { get; set; }
    }
}
