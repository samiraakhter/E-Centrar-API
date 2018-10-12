using System;
using System.Collections.Generic;

namespace ServiceLayer.Models
{
    public partial class PurchaseInvoice
    {
        public string PurchaseInvoiceId { get; set; }
        public Guid SupplierIdFk { get; set; }
        public DateTime PaymentDate { get; set; }
        public DateTime DueDate { get; set; }
        public double Balance { get; set; }
        public double PaidAmount { get; set; }
        public double Total { get; set; }
        public string Status { get; set; }
        public DateTime InvoiceDate { get; set; }
        public double Revenue { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }

        public Supplier SupplierIdFkNavigation { get; set; }
    }
}
