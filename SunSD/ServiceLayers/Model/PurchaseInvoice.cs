using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServiceLayers.Model
{
    public partial class PurchaseInvoice
    {
        public int Id { get; set; }
        public string PurchaseInvoiceNo { get; set; }

        [Display(Name = "Supplier")]
        public int SupplierIdFk { get; set; }

        [ForeignKey("SupplierIdFk")]
        public virtual Supplier Supplier { get; set; }

        //public int? SupplierIdFk { get; set; }
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

        //public Supplier SupplierIdFkNavigation { get; set; }
    }
}
