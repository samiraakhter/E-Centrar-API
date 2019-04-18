using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServiceLayers.Model
{
    public partial class OrderLines
    {
        public int Id { get; set; }

        //public int OrderIdFk { get; set; }
        public string Sku { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public double TotalPrice { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }

        [Display(Name = "Order")]
        public int OrderIdFk { get; set; }

        [ForeignKey("OrderIdFk")]
        public virtual Order Order { get; set; }

        // public Order OrderIdFkNavigation { get; set; }
    }
}
