using System;
using System.Collections.Generic;

namespace ServiceLayers.Model
{
    public partial class Order
    {
        public Order()
        {
            GoodsNotes = new HashSet<GoodsNotes>();
            OrderLines = new HashSet<OrderLines>();
            ProductSelectedForOrder = new HashSet<ProductSelectedForOrder>();
        }

        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public int? CustomerIdFk { get; set; }
        public bool IsConfirmed { get; set; }
        public int ProductIdFk { get; set; }
        public int? SalesOrderIdFk { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }

        public Customer CustomerIdFkNavigation { get; set; }
        public Product ProductIdFkNavigation { get; set; }
        public SalesOrder SalesOrderIdFkNavigation { get; set; }
        public ICollection<GoodsNotes> GoodsNotes { get; set; }
        public ICollection<OrderLines> OrderLines { get; set; }
        public ICollection<ProductSelectedForOrder> ProductSelectedForOrder { get; set; }
    }
}
