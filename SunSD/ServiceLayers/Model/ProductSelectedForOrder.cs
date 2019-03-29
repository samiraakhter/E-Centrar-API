using System;
using System.Collections.Generic;

namespace ServiceLayers.Model
{
    public partial class ProductSelectedForOrder
    {
        public int Id { get; set; }
        public int OrderIdFk { get; set; }
        public int ProductIdFk { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }

        public Order OrderIdFkNavigation { get; set; }
        public Product ProductIdFkNavigation { get; set; }
    }
}
