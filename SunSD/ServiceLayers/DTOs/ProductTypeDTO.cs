using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayers.DTOs
{
     public class ProductTypeDTO
    {
        public int Id { get; set; }
        public string ProductTypeName { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
