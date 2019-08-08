using ServiceLayers.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.Model
{
    public class MasterData
    {
        public int userId { get; set; }
        public IEnumerable<Product>  Products { get; set; }
        public IEnumerable<Inventory> inventories { get; set; }
        public IEnumerable<Customer>  Customers { get; set; } 
    }
}
