﻿using System;
using System.Collections.Generic;

namespace ServiceLayer.Models
{
    public partial class ShoppingCartViewModel
    {
        public int Id { get; set; }
        public string ProductList { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
    }
}
