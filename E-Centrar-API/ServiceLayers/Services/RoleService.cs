using Microsoft.AspNetCore.Mvc;
using ServiceLayers.Model;
using ServiceLayers.Model.ViewModel;
using ServiceLayers.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ServiceLayers.Services
{
    public interface IRoleService
    {
        IEnumerable<Role> GetAll();
        Role GetById(int id);
        Role Create(Role role);
        Role Update(Role role);
        void Delete(int id);
    }
    public class RoleService:IRoleService
    {
        private readonly ApplicationDbContext _db;

        public RoleService(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Role> GetAll()
        {

            return _db.Role;
        }

        public Role GetById(int id)
        {
            return _db.Role.Find(id);
        }

        public Role Create(Role role)
        {
            role.CreatedBy = "Admin";
            role.CreatedDate = DateTime.Now;
            role.IsActive = true;
           // role.RoleName = role.RoleName;
            
            _db.Role.Add(role);
            _db.SaveChanges();
            return role;

        }

        public void Delete(int id)
        {
            var role = _db.Role.Find(id);
            if (role != null)
            {
                _db.Role.Remove(role);
                _db.SaveChanges();

            }
        }

        public Role Update(Role roleparam)
        {
            var roles = _db.Role.Find(roleparam.Id);
            if (roles == null)
                throw new Exception("Product not found");

            if (roleparam.RoleName != roles.RoleName)
            {
                // type has changed so check if the new type is already taken
                if (_db.Role.Any(x => x.RoleName == roleparam.RoleName))
                    throw new Exception(roleparam.RoleName + " is already taken");
            }

            //productTypes.UpdatedBy = User.Identity.Name;
            roles.UpdatedBy = "Admin";
            roles.UpdatedDate = DateTime.Now;
            roles.IsActive = roleparam.IsActive;
            roles.RoleName = roleparam.RoleName;
            


            _db.Role.Update(roles);
            _db.SaveChanges();

            return roles;
        }
    }
}
