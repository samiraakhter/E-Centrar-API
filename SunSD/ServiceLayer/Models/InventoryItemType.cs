using System;
using System.Collections.Generic;

namespace ServiceLayer.Models
{
    public partial class InventoryItemType
    {
        public InventoryItemType()
        {
            Inventory = new HashSet<Inventory>();
        }

        public int InventoryItemTypeId { get; set; }
        public string InventoryItemTypeName { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }

        public ICollection<Inventory> Inventory { get; set; }
    }
}
