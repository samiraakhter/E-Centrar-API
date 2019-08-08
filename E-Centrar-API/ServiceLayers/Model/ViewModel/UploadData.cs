using ServiceLayers.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.Model.ViewModel
{
    public class UploadData
    {
        public int userId { get; set; }
        public IEnumerable<Data> Data { get; set; }
        public IEnumerable<Order> Orders { get; set; }
        public IEnumerable<OrderLines> OrderLines { get; set; }
    }
}
