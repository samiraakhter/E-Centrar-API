using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayers.DTOs
{
   public class OrderDTO
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public int CustomerIdFk { get; set; }
        public bool IsConfirmed { get; set; }
        public int ProductIdFk { get; set; }
        public int SalesOrderIdFk { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
    }
}
