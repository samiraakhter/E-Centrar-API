using ServiceLayers.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.Model
{
    public class CustomerRoute
    {
            public int CustomerId { get; set; }
            public int RouteId { get; set; }

            //-----------------------------
            //Relationships

            public Customer Customer { get; set; }
            public Route Route { get; set; }
        
    }
}
