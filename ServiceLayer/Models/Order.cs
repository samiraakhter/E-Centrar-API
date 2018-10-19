using System;
using System.Collections.Generic;

namespace ServiceLayer.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderLines = new HashSet<OrderLines>();
            ProductSelectedForOrder = new HashSet<ProductSelectedForOrder>();
        }

        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public Guid CustomerIdFk { get; set; }
        public bool IsConfirmed { get; set; }
        public int ProductIdFk { get; set; }
        public string SalesOrderIdFk { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }

        public ICollection<OrderLines> OrderLines { get; set; }
        public ICollection<ProductSelectedForOrder> ProductSelectedForOrder { get; set; }
    }
}
