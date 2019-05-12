using System;
using System.Collections.Generic;

namespace ServiceLayers.Model
{
    public partial class Supplier
    {
        public Supplier()
        {
            PurchaseInvoice = new HashSet<PurchaseInvoice>();
            PurchaseOrder = new HashSet<PurchaseOrder>();
        }

        public int Id { get; set; }
        public Guid SupplierId { get; set; }
        public string Suppliername { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
        public string MobileNo { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string PaymentMethod { get; set; }
        public string Address { get; set; }
        public string Company { get; set; }

        public ICollection<PurchaseInvoice> PurchaseInvoice { get; set; }
        public ICollection<PurchaseOrder> PurchaseOrder { get; set; }
    }
}
