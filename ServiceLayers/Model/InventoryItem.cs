using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServiceLayers.Model
{
    public partial class InventoryItem
    {
        //public InventoryItem()
        //{
        //    Inventory = new HashSet<Inventory>();
        //}

        public int Id { get; set; }
        public string InventoryItemName { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }

        [Display(Name = "Inventory Item")]
        public int InventoryItemCategoryFk { get; set; }

        [ForeignKey("InventoryItemCategoryFk")]
        public virtual InventoryItemCategory InventoryItemCategory  { get; set; }

        // public int InventoryItemCategoryFk { get; set; }

        //public InventoryItemCategory InventoryItemCategoryFkNavigation { get; set; }
        //public ICollection<Inventory> Inventory { get; set; }
    }
}
