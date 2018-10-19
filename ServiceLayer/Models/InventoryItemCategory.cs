using System;
using System.Collections.Generic;

namespace ServiceLayer.Models
{
    public partial class InventoryItemCategory
    {
        public InventoryItemCategory()
        {
            InventoryItem = new HashSet<InventoryItem>();
        }

        public int InventoryItemCategoryId { get; set; }
        public string InventoryItemCategoryName { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }

        public ICollection<InventoryItem> InventoryItem { get; set; }
    }
}
