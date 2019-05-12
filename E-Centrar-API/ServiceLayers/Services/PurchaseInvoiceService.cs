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
    public interface IPurchaseInvoiceService
    {
        IEnumerable<PurchaseInvoice> GetAll();
        PurchaseInvoice GetById(int id);
        PurchaseInvoice Create(PurchaseInvoice purchaseInvoice);
        PurchaseInvoice Update(PurchaseInvoice purchaseInvoice);
        void Delete(int id);
    }
    public class PurchaseInvoiceService : IPurchaseInvoiceService
    {
        private readonly ApplicationDbContext _db;

        public PurchaseInvoiceService(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<PurchaseInvoice> GetAll()
        {

            return _db.PurchaseInvoice;
        }

        public PurchaseInvoice GetById(int id)
        {
            return _db.PurchaseInvoice.Find(id);
        }

        public PurchaseInvoice Create(PurchaseInvoice purchaseInvoice)
        {
            purchaseInvoice.CreatedBy = "Admin";
            purchaseInvoice.CreatedDate = DateTime.Now;
            purchaseInvoice.IsActive = true;



            _db.PurchaseInvoice.Add(purchaseInvoice);
            _db.SaveChanges();
            return purchaseInvoice;

        }

        public void Delete(int id)
        {
            var purchaseInvoice = _db.PurchaseInvoice.Find(id);
            if (purchaseInvoice != null)
            {
                _db.PurchaseInvoice.Remove(purchaseInvoice);
                _db.SaveChanges();

            }
        }

        public PurchaseInvoice Update(PurchaseInvoice purchaseParam)
        {
            var purchase = _db.PurchaseInvoice.Find(purchaseParam.Id);
            if (purchase == null)
                throw new Exception("Product not found");

            if (purchaseParam.Balance != purchase.Balance)
            {
                // type has changed so check if the new type is already taken
                if (_db.PurchaseInvoice.Any(x => x.Balance == purchaseParam.Balance))
                    throw new Exception(purchaseParam.Balance + " is already taken");
            }

            //productTypes.UpdatedBy = User.Identity.Name;
            purchase.UpdatedBy = "Admin";
            purchase.UpdatedDate = DateTime.Now;
            purchase.Balance = purchaseParam.Balance;
            purchase.DueDate = purchaseParam.DueDate;
            purchase.IsActive = purchaseParam.IsActive;
            purchase.InvoiceDate = purchaseParam.InvoiceDate;
            purchase.PaidAmount = purchaseParam.PaidAmount;
            purchase.PaymentDate = purchaseParam.PaymentDate;
            purchase.PurchaseInvoiceNo = purchaseParam.PurchaseInvoiceNo;
            purchase.Revenue = purchaseParam.Revenue;
            purchase.Status = purchaseParam.Status;
            purchase.Supplier = purchaseParam.Supplier;
            purchase.SupplierIdFk = purchaseParam.SupplierIdFk;
            purchase.Total = purchaseParam.Total;



            _db.PurchaseInvoice.Update(purchase);
            _db.SaveChanges();

            return purchase;
        }
    }
}
