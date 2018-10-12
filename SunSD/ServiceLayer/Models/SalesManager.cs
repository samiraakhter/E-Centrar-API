using System;
using System.Collections.Generic;

namespace ServiceLayer.Models
{
    public partial class SalesManager
    {
        public SalesManager()
        {
            Customer = new HashSet<Customer>();
            SalesOrder = new HashSet<SalesOrder>();
        }

        public Guid SalesManagerId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int RoleIdFk { get; set; }
        public string Salary { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string PhoneNo { get; set; }
        public string MobileNo { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }

        public Role RoleIdFkNavigation { get; set; }
        public ICollection<Customer> Customer { get; set; }
        public ICollection<SalesOrder> SalesOrder { get; set; }
    }
}
