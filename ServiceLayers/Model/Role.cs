using System;
using System.Collections.Generic;

namespace ServiceLayers.Model
{
    public partial class Role
    {
        //public Role()
        //{
        //    SalesManager = new HashSet<SalesManager>();
        //}

        public int Id { get; set; }
        public string RoleName { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }

       // public ICollection<SalesManager> SalesManager { get; set; }
    }
}
