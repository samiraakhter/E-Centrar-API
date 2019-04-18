using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayers.DTOs
{
   public class InventoryItemDTO
    {
        public int Id { get; set; }
        public string InventoryItemName { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public int InventoryItemCategoryFk { get; set; }
    }
}
