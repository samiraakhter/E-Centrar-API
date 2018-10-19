using System;
using System.Collections.Generic;

namespace ServiceLayer.Models
{
    public partial class InventoryItem
    {
        public InventoryItem()
        {
            Inventory = new HashSet<Inventory>();
        }

        public int InventoryItemId { get; set; }
        public string InventoryItemName { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public int InventoryItemCategoryFk { get; set; }

        public InventoryItemCategory InventoryItemCategoryFkNavigation { get; set; }
        public ICollection<Inventory> Inventory { get; set; }
    }
}
