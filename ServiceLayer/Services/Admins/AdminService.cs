using Microsoft.EntityFrameworkCore;
using ServiceLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.Admins
{
    public class AdminService : IAdminService
    {
        SunSDContext db;
        public AdminService(SunSDContext _db)
        {
            db = _db;
        }
        public async Task<Guid> AddAdmin(Admin admin)
        {
            
            if (db != null)
            {
                admin.AdminId = Guid.NewGuid();
                admin.CreatedDate = DateTime.Now;

                await db.Admin.AddAsync(admin);
                await db.SaveChangesAsync();

                return admin.AdminId;
            }
            return Guid.Empty;
        }

        public async Task DeleteAdmin(Guid? adminId)
        {
            if (db != null)
            {
                //Find the Admin for specific Admin id
                var admin = await db.Admin.FirstOrDefaultAsync(x => x.AdminId == adminId);

                if (admin != null)
                {
                    //Delete that admin
                    db.Admin.Remove(admin);

                    //Commit the transaction
                    await db.SaveChangesAsync();
                }
            }
        }

        public async Task<Admin> GetAdmin(Guid? adminId)
        {
            if (db != null)
            {
                return await db.Admin.SingleOrDefaultAsync(m => m.AdminId == adminId);
            }

            return null;
        }

        public async Task<List<Admin>> GetAdmins()
        {
            if (db != null)
            {
                return await db.Admin.ToListAsync();
            }

            return null;
        }

        public async Task UpdateAdmin(Admin admin)
        {
            if (db != null)
            {
                //Delete that admin
                db.Admin.Update(admin);

                //Commit the transaction
                await db.SaveChangesAsync();
            }
        }
    }
}
