using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using ServiceLayers.Model;
using ServiceLayers.Model.ViewModel;

namespace ServiceLayers.Services
{
    public interface ISalesOrderService
    {
        IEnumerable<SalesOrder> GetAll();
        SalesOrder GetById(int id);
        SalesOrder Create(SalesOrder SalesOrder);
        SalesOrder Update(SalesOrder SalesOrder);
        void Delete(int id);
    }

    public class SalesOrderService: ISalesOrderService
    {
        private readonly ApplicationDbContext _db;
        public SalesOrderService(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<SalesOrder> GetAll()
        {

            return _db.SalesOrder;
        }

        public SalesOrder GetById(int id)
        {
            return _db.SalesOrder.Find(id);
        }
        public SalesOrder Create(SalesOrder salesOrder)
        {
            salesOrder.CreatedBy = "Admin";
            salesOrder.CreatedDate = DateTime.Now;
            
            _db.SalesOrder.Add(salesOrder);
            _db.SaveChanges();
            return salesOrder;
        }

        public void Delete(int id)
        {
            var salesOrder = _db.SalesOrder.Find(id);
            if (salesOrder != null)
            {
                _db.SalesOrder.Remove(salesOrder);
                _db.SaveChanges();
            }

        }

        public SalesOrder Update(SalesOrder SalesOrderParam)
        {
            var salesOrder = _db.SalesOrder.Find(SalesOrderParam.Id);
            if (salesOrder == null)
                throw new Exception("Customer not found");

            if (SalesOrderParam.Revenue != salesOrder.Revenue)
            {
                // type has changed so check if the new type is already taken
                if (_db.SalesOrder.Any(x => x.Revenue == SalesOrderParam.Revenue))
                    throw new Exception(SalesOrderParam.Revenue + " is already taken");
            }

            //productTypes.UpdatedBy = User.Identity.Name;
            salesOrder.UpdatedBy = "Admin";
            salesOrder.UpdatedDate = DateTime.Now;
            salesOrder.CreatedBy = "Admin";

            _db.SalesOrder.Update(salesOrder);
            _db.SaveChanges();

            return salesOrder;
        }

    }
}
