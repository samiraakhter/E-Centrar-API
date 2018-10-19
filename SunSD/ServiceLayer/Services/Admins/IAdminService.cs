using ServiceLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public interface IAdminService
    {
        Task<List<Admin>> GetAdmins();

        Task<Admin> GetAdmin(Guid? adminId);

        Task<Guid> AddAdmin(Admin admin);

        Task DeleteAdmin(Guid? adminId);

        Task UpdateAdmin(Admin admin);
    }
}
