using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using ServiceLayers.Model;
using ServiceLayers.Model.ViewModel;

namespace ServiceLayers.Services
{
    public interface ISalesManagerService
    {
        IEnumerable<SalesManager> GetAll();
        SalesManager GetById(int id);
        SalesManager Create(SalesManager SalesManager);
        SalesManager Update(SalesManager SalesManager);
        void Delete(int id);
    }

    public class SalesManagerService:ISalesManagerService
    {
        private readonly ApplicationDbContext _db;

        public SalesManagerService(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<SalesManager> GetAll()
        {

            return _db.SalesManager;
        }

        public SalesManager GetById(int id)
        {
            return _db.SalesManager.Find(id);
        }
        public SalesManager Create(SalesManager SalesManager)
        {
            SalesManager.CreatedBy = "Admin";
            SalesManager.CreatedDate = DateTime.Now;
           
            _db.SalesManager.Add(SalesManager);
            _db.SaveChanges();
            return SalesManager;
        }

        public void Delete(int id)
        {
            var SalesManager = _db.SalesManager.Find(id);
            if (SalesManager != null)
            {
                _db.SalesManager.Remove(SalesManager);
                _db.SaveChanges();
            }

        }

        public SalesManager Update(SalesManager SalesManagerParam)
        {
            var SalesManager = _db.SalesManager.Find(SalesManagerParam.Id);
            if (SalesManager == null)
                throw new Exception("Customer not found");

            if (SalesManagerParam.FirstName != SalesManager.FirstName)
            {
                // type has changed so check if the new type is already taken
                if (_db.SalesManager.Any(x => x.FirstName == SalesManagerParam.FirstName))
                    throw new Exception(SalesManagerParam.FirstName + " is already taken");
            }

            //productTypes.UpdatedBy = User.Identity.Name;
            SalesManager.UpdatedBy = "Admin";
            SalesManager.UpdatedDate = DateTime.Now;
            SalesManager.CreatedBy = "Admin";

            _db.SalesManager.Update(SalesManager);
            _db.SaveChanges();

            return SalesManager;
        }

    }
}
