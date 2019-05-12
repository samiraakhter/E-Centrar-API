using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiceLayers.Model;
namespace ServiceLayers.Services
{
    public interface IAdminService
    {
        IEnumerable<Admin> GetAll();
        Admin GetById(int id);
        Admin Create(Admin admin);
        Admin Update(Admin admin);
        void Delete(int id);

    }

    public class AdminService:IAdminService
    {
        private readonly ApplicationDbContext _db;

        public AdminService(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Admin> GetAll()
        {
            return _db.Admin;
        }

        public Admin GetById(int id)
        {
            return _db.Admin.Find(id);
        }

        public Admin Create(Admin admin)
        {
            //productCategory.CreatedBy = User.Identity.Name;
            admin.CreatedBy = "Admin";
            admin.CreatedDate = DateTime.Now;
            admin.AdminName = "sana";
            admin.Email = "thesana@gmail.com";
            admin.IsActive = true;
            admin.Password = "000000";
            admin.UserName = "saba";
            _db.Admin.Add(admin);
            _db.SaveChanges();

            return admin;
        }

        public void Delete(int id)
        {
            var admin = _db.Admin.Find(id);
            if (admin != null)
            {
                _db.Admin.Remove(admin);
                _db.SaveChanges();
            }
        }

        public Admin Update(Admin adminParam)
        {
            var admin = _db.Admin.Find(adminParam.Id);
            if (admin == null)
                throw new Exception("Product Category not found");

            if (adminParam.AdminName != admin.AdminName)
            {
                // Category has changed so check if the new Category is already taken
                if (_db.Admin.Any(x => x.AdminName == adminParam.AdminName))
                    throw new Exception("This" + adminParam.AdminName + " is already taken");
            }
            admin.AdminName = adminParam.AdminName;
            admin.UpdatedBy = "Admin";
            admin.UpdatedDate = DateTime.Now;
           
            _db.Admin.Update(admin);
            _db.SaveChanges();
            return admin;
        }

    }
}
