using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayers.DTOs
{
    public class SupplierDTO
    {
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
    }
}
