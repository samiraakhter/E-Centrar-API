using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayers.DTOs
{
    public class CustomerDTO
    {
        public int Id { get; set; }
        public Guid CustomerId { get; set; }
        public int FK_SalesManager { get; set; }
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
        public int FK_RouteId { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }


    }
}
