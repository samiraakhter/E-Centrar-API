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
    public interface IPurchaseOrderService
    {
        IEnumerable<PurchaseOrder> GetAll();
        PurchaseOrder GetById(int id);
        PurchaseOrder Create(PurchaseOrder purchaseorder);
        PurchaseOrder Update(PurchaseOrder purchaseorder);
        void Delete(int id);
    }
    public class PurchaseOrderService: IPurchaseOrderService
    {
        private readonly ApplicationDbContext _db;

        public PurchaseOrderService(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<PurchaseOrder> GetAll()
        {

            return _db.PurchaseOrder;
        }

        public PurchaseOrder GetById(int id)
        {
            return _db.PurchaseOrder.Find(id);
        }

        public PurchaseOrder Create(PurchaseOrder purchaseorder)
        {
            purchaseorder.CreatedBy = "Admin";
            purchaseorder.CreatedDate = DateTime.Now;
            purchaseorder.IsActive = true;



            _db.PurchaseOrder.Add(purchaseorder);
            _db.SaveChanges();
            return purchaseorder;

        }

        public void Delete(int id)
        {
            var purchaseorder = _db.PurchaseOrder.Find(id);
            if (purchaseorder != null)
            {
                _db.PurchaseOrder.Remove(purchaseorder);
                _db.SaveChanges();

            }
        }

        public PurchaseOrder Update(PurchaseOrder purchaseParam)
        {
            var purchase = _db.PurchaseOrder.Find(purchaseParam.Id);
            if (purchase == null)
                throw new Exception("Product not found");

            if (purchaseParam.PurchaseOrderNo != purchase.PurchaseOrderNo)
            {
                // type has changed so check if the new type is already taken
                if (_db.PurchaseOrder.Any(x => x.PurchaseOrderNo == purchaseParam.PurchaseOrderNo))
                    throw new Exception(purchaseParam.PurchaseOrderNo + " is already taken");
            }

            //productTypes.UpdatedBy = User.Identity.Name;
            purchase.UpdatedBy = "Admin";
            purchase.UpdatedDate = DateTime.Now;
            purchase.PurchaseOrderNo = purchaseParam.PurchaseOrderNo;
            purchase.Reference = purchaseParam.Reference;
            purchase.Revenue = purchaseParam.Revenue;
            purchase.Status = purchaseParam.Status;
            purchase.Supplier = purchaseParam.Supplier;
            purchase.SupplierIdFk = purchaseParam.SupplierIdFk;
            purchase.Untaxed = purchaseParam.Untaxed;
            purchase.OrderDate = purchaseParam.OrderDate;
            purchase.IsActive = purchaseParam.IsActive;

            
            _db.PurchaseOrder.Update(purchase);
            _db.SaveChanges();

            return purchase;
        }
    }
}
