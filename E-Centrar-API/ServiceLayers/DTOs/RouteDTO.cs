using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.DTOs
{
    public class RouteDTO
    {
        public int Id { get; set; }
        public string RouteName { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public DateTime DateOfVisit { get; set; }
        public bool isRepeatable { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool isActive { get; set; }
        public int SalesPerson { get; set; }

    }
}
