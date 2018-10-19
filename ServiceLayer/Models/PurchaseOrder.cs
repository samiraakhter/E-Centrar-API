using System;
using System.Collections.Generic;

namespace ServiceLayer.Models
{
    public partial class PurchaseOrder
    {
        public string PurchaseOrderId { get; set; }
        public string Reference { get; set; }
        public Guid SupplierIdFk { get; set; }
        public string Untaxed { get; set; }
        public double Total { get; set; }
        public string Status { get; set; }
        public double Revenue { get; set; }
        public DateTime OrderDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }

        public Supplier SupplierIdFkNavigation { get; set; }
    }
}
