using System;
using System.Collections.Generic;

namespace ServiceLayer.Models
{
    public partial class Role
    {
        public Role()
        {
            SalesManager = new HashSet<SalesManager>();
        }

        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }

        public ICollection<SalesManager> SalesManager { get; set; }
    }
}
