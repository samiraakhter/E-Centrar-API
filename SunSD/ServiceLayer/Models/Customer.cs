using System;
using System.Collections.Generic;

namespace ServiceLayer.Models
{
    public partial class Customer
    {
        public Customer()
        {
            SalesInvoice = new HashSet<SalesInvoice>();
            SalesOrder = new HashSet<SalesOrder>();
        }

        public Guid CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Guid SalesManagerIdFk { get; set; }
        public string EnterpriseName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string PhoneNo { get; set; }
        public string MobileNo { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string PaymentMethod { get; set; }

        public SalesManager SalesManagerIdFkNavigation { get; set; }
        public ICollection<SalesInvoice> SalesInvoice { get; set; }
        public ICollection<SalesOrder> SalesOrder { get; set; }
    }
}
