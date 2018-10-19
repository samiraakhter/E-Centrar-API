using System;
using System.Collections.Generic;

namespace ServiceLayer.Models
{
    public partial class SalesInvoice
    {
        public string SalesInvoiceNo { get; set; }
        public DateTime SalesInvoiceDate { get; set; }
        public Guid SalesManagerIdFk { get; set; }
        public string SalesManagerAssign { get; set; }
        public string SalesOrdernoFk { get; set; }
        public string PaymentTerm { get; set; }
        public Guid CustomerIdFk { get; set; }
        public string CustomerName { get; set; }
        public DateTime PaymentDate { get; set; }
        public double Discount { get; set; }
        public string PoWono { get; set; }
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

        public Customer CustomerIdFkNavigation { get; set; }
        public Supplier SalesManagerIdFkNavigation { get; set; }
        public SalesOrder SalesOrdernoFkNavigation { get; set; }
    }
}
