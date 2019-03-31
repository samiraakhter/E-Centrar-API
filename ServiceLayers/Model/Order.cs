using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServiceLayers.Model
{
    public partial class Order
    {
        //public Order()
        //{
        //    GoodsNotes = new HashSet<GoodsNotes>();
        //    OrderLines = new HashSet<OrderLines>();
        //    ProductSelectedForOrder = new HashSet<ProductSelectedForOrder>();
        //}

        public int Id { get; set; }
        public DateTime OrderDate { get; set; }

        [Display(Name = "Customer")]
        public int CustomerIdFk { get; set; }

        [ForeignKey("CustomerIdFk")]
        public virtual Customer Customer { get; set; }
     
        public bool IsConfirmed { get; set; }

        [Display(Name = "Product")]
        public int ProductIdFk { get; set; }

        [ForeignKey("ProductIdFk")]
        public virtual Product Product { get; set; }

        [Display(Name = "SalesOrder")]
        public int SalesOrderIdFk { get; set; }

        [ForeignKey("SalesOrderIdFk")]
        public virtual SalesOrder SalesOrder { get; set; }
       
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }

        //public Customer CustomerIdFkNavigation { get; set; }
        //public Product ProductIdFkNavigation { get; set; }
        //public SalesOrder SalesOrderIdFkNavigation { get; set; }
        //public ICollection<GoodsNotes> GoodsNotes { get; set; }
        //public ICollection<OrderLines> OrderLines { get; set; }
        //public ICollection<ProductSelectedForOrder> ProductSelectedForOrder { get; set; }
    }
}
