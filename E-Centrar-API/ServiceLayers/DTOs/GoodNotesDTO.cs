using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayers.DTOs
{
    public class GoodsNotesDTO
    {
        public int Id { get; set; }
        public int OrderIdFk { get; set; }
        public string OrderStatus { get; set; }
        public string DeliverTo { get; set; }
        public string Warehouse { get; set; }
        public bool Printed { get; set; }
        public bool Picked { get; set; }
        public bool Packed { get; set; }
        public bool Shipped { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
    }
}
