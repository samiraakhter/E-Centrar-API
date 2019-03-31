using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServiceLayers.Model
{
    public partial class GoodsNotes
    {
        public int Id { get; set; }

        [Display(Name = "Order")]
        public int OrderIdFk { get; set; }

        [ForeignKey("OrderIdFk")]
        public virtual Order Order { get; set; }

        public string OrderStatus { get; set; }
        public string DeliverTo { get; set; }
        public string Warehouse { get; set; }
        public bool Printed { get; set; }
        public bool Picked { get; set; }
        public bool Packed { get; set; }
        public bool Shipped { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }

        //public Order OrderIdFkNavigation { get; set; }
    }
}
