using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServiceLayers.Model
{
    public partial class SalesOrder
    {
        //public SalesOrder()
        //{
        //    Order = new HashSet<Order>();
        //    SalesInvoice = new HashSet<SalesInvoice>();
        //}

        public int Id { get; set; }
        public string SalesOrderNo { get; set; }
        public string EnterpriseName { get; set; }
        public string ProductName { get; set; }
        public string Category { get; set; }
        public string Status { get; set; }
        public double Revenue { get; set; }

        [Display(Name = "Sales Manager")]
        public int SalesManagerIdFk { get; set; }

        [ForeignKey("SalesManagerIdFk")]
        public virtual User User { get; set; }
       
        public string SalesPersonAssign { get; set; }

        [Display(Name = "Customer")]
        public int CustomerIdFk { get; set; }

        [ForeignKey("CustomerIdFk")]
        public virtual Customer Customer { get; set; }
        //public int? CustomerIdFk { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }

        //public Customer CustomerIdFkNavigation { get; set; }
        //public SalesManager SalesManagerIdFkNavigation { get; set; }
        //public ICollection<Order> Order { get; set; }
        //public ICollection<SalesInvoice> SalesInvoice { get; set; }
    }
}
