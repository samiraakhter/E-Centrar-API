using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayers.DTOs
{
  public  class SaleOrderDTO
    {
        public int Id { get; set; }
        public string SalesOrderNo { get; set; }
        public string EnterpriseName { get; set; }
        public string ProductName { get; set; }
        public string Category { get; set; }
        public string Status { get; set; }
        public double Revenue { get; set; }
        public int SalesManagerIdFk { get; set; }
        public int CustomerIdFk { get; set; }
        public string SalesPersonAssign { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
    }
}
