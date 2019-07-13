﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayers.DTOs
{
    public class InventoryDTO
    {
        public int Id { get; set; }
        public double Amount { get; set; }
        public string Unit { get; set; }
        public int MinimumStockLevel { get; set; }
        public int ReorderQuantity { get; set; }
        public string DefaultLocation { get; set; }
        public int ProductFk { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
       
   
    }
}
