using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayers.DTOs
{
    public class SalesPersonDTO
    {
        public int Id { get; set; }
        public Guid SalesPersonId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string VehicleNo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNo { get; set; }
        public string MobileNo { get; set; }
        public string Address { get; set; }
        public string Salary { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
    }
}
