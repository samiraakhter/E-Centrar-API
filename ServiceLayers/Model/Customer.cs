using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServiceLayers.Model
{
    public partial class Customer
    {
        //public Customer()
        //{
        //    Order = new HashSet<Order>();
        //    SalesInvoice = new HashSet<SalesInvoice>();
        //    SalesOrder = new HashSet<SalesOrder>();
        //}

        public int Id { get; set; }
        public Guid CustomerId { get; set; }

        [Display(Name = "Sales Manager")]
        public int FK_SalesManager { get; set; }

        [ForeignKey("FK_SalesManager")]
        public virtual SalesManager SalesManager { get; set; }

        // public int? FkSalesManager { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
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

        //public SalesManager FkSalesManagerNavigation { get; set; }
        //public ICollection<Order> Order { get; set; }
        //public ICollection<SalesInvoice> SalesInvoice { get; set; }
        //public ICollection<SalesOrder> SalesOrder { get; set; }
    }
}
