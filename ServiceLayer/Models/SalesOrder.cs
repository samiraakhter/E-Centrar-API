using System;
using System.Collections.Generic;

namespace ServiceLayer.Models
{
    public partial class SalesOrder
    {
        public SalesOrder()
        {
            SalesInvoice = new HashSet<SalesInvoice>();
        }

        public string SalesOrderNo { get; set; }
        public string EnterpriseName { get; set; }
        public string ProductName { get; set; }
        public string Category { get; set; }
        public string Status { get; set; }
        public double Revenue { get; set; }
        public Guid SalesManagerIdFk { get; set; }
        public string SalesPersonAssign { get; set; }
        public Guid CustomerIdFk { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }

        public Customer CustomerIdFkNavigation { get; set; }
        public SalesManager SalesManagerIdFkNavigation { get; set; }
        public ICollection<SalesInvoice> SalesInvoice { get; set; }
    }
}
