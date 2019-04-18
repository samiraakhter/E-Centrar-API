using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayers.DTOs
{
   public class ProductOptionDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Option { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
    }
}
