using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServiceLayers.Model
{
    public partial class SalesInvoice
    {
        public int Id { get; set; }
        public string SalesInvoiceNo { get; set; }
        public DateTime SalesInvoiceDate { get; set; }

        //[Display(Name = "Sales Manager")]
        //public int SalesManagerIdFk { get; set; }

        //[ForeignKey("SalesManagerIdFk")]
        //public virtual User User { get; set; }
       // public int? SalesManagerIdFk { get; set; }
        
        public string SalesManagerAssign { get; set; }

        //[Display(Name = "Sales Order")]
        //public int SalesOrdernoFk { get; set; }

        //[ForeignKey("SalesOrdernoFk")]
        //public virtual SalesOrder SalesOrder { get; set; }
       // public int? SalesOrdernoFk { get; set; }
        public string PaymentTerm { get; set; }

        [Display(Name = "Customer")]
        public int CustomerIdFk { get; set; }

        [ForeignKey("CustomerIdFk")]
        public virtual Customer Customer { get; set; }
        //public int? CustomerIdFk { get; set; }

        public string CustomerName { get; set; }
        public DateTime PaymentDate { get; set; }
        public double Discount { get; set; }
        public string PO_WOno { get; set; }
        public string ModeOfPayment { get; set; }
        public string NotesToCustomer { get; set; }
        public string Product { get; set; }
        public double Rate { get; set; }
        public int Quantity { get; set; }
        public double Amount { get; set; }
        public double Tax { get; set; }
        public double SubTotal { get; set; }
        public string ShippingAndHandling { get; set; }
        public double Total { get; set; }
        public double? AmountDue { get; set; }
        public double Revenue { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }

        //public Customer CustomerIdFkNavigation { get; set; }
        //public SalesManager SalesManagerIdFkNavigation { get; set; }
        //public SalesOrder SalesOrdernoFkNavigation { get; set; }
    }
}
