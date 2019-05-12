using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServiceLayers.Model
{
    public partial class ProductSelectedForOrder
    {
        public int Id { get; set; }

        [Display(Name = "Order")]
        public int OrderIdFk { get; set; }

        [ForeignKey("OrderIdFk")]
        public virtual Order Order { get; set; }

        //public int OrderIdFk { get; set; }

        [Display(Name = "Product")]
        public int ProductIdFk { get; set; }

        [ForeignKey("ProductIdFk")]
        public virtual Product Product { get; set; }
        //public int ProductIdFk { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }

        //public Order OrderIdFkNavigation { get; set; }
        //public Product ProductIdFkNavigation { get; set; }
    }
}
