using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayers.Model.ViewModel
{
    public class ProductViewModel
    {
        public Product Products { get; set; }
        public IEnumerable<ProductType> ProductTypes { get; set; }
        public IEnumerable<ProductCategory> ProductCategories { get; set; }
    }
}
