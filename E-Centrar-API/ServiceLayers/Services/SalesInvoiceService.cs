using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using ServiceLayers.Model;
using ServiceLayers.Model.ViewModel;

namespace ServiceLayers.Services
{
    public interface ISalesInvoiceService
    {
        IEnumerable<SalesInvoice> GetAll();
        SalesInvoice GetById(int id);
        SalesInvoice Create(SalesInvoice salesInvoice);
        SalesInvoice Update(SalesInvoice salesInvoice);
        void Delete(int id);
    }
   public class SalesInvoiceService:ISalesInvoiceService
    {
        private readonly ApplicationDbContext _db;
        public SalesInvoiceService(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<SalesInvoice> GetAll()
        {

            return _db.SalesInvoice;
        }

        public SalesInvoice GetById(int id)
        {
            return _db.SalesInvoice.Find(id);
        }
        public SalesInvoice Create(SalesInvoice SalesInvoice)
        {
            SalesInvoice.CreatedBy = "Admin";
            SalesInvoice.CreatedDate = DateTime.Now;
            
            _db.SalesInvoice.Add(SalesInvoice);
            _db.SaveChanges();
            return SalesInvoice;
        }

        public void Delete(int id)
        {
            var SalesInvoice = _db.SalesInvoice.Find(id);
            if (SalesInvoice != null)
            {
                _db.SalesInvoice.Remove(SalesInvoice);
                _db.SaveChanges();
            }

        }

        public SalesInvoice Update(SalesInvoice SalesInvoiceParam)
        {
            var SalesInvoices = _db.SalesInvoice.Find(SalesInvoiceParam.Id);
            if (SalesInvoices == null)
                throw new Exception("Customer not found");

            if (SalesInvoiceParam.Amount != SalesInvoices.Amount)
            {
                // type has changed so check if the new type is already taken
                if (_db.SalesInvoice.Any(x => x.Amount == SalesInvoiceParam.Amount))
                    throw new Exception(SalesInvoiceParam.Amount + " is already taken");
            }

            //productTypes.UpdatedBy = User.Identity.Name;
            SalesInvoices.UpdatedBy = "Admin";
            SalesInvoices.UpdatedDate = DateTime.Now;
            SalesInvoices.CreatedBy = "Admin";
            SalesInvoices.Amount = SalesInvoiceParam.Amount;
            SalesInvoices.AmountDue = SalesInvoiceParam.AmountDue;
            SalesInvoices.CustomerIdFk = SalesInvoiceParam.CustomerIdFk;
            SalesInvoices.CustomerName = SalesInvoiceParam.CustomerName;
            SalesInvoices.Discount = SalesInvoiceParam.Discount;
            SalesInvoices.IsActive = SalesInvoiceParam.IsActive;
            SalesInvoices.ModeOfPayment = SalesInvoiceParam.ModeOfPayment;
            SalesInvoices.NotesToCustomer = SalesInvoiceParam.NotesToCustomer;
            SalesInvoices.PaymentDate = SalesInvoiceParam.PaymentDate;
            SalesInvoices.PaymentTerm = SalesInvoiceParam.PaymentTerm;
            SalesInvoices.PO_WOno = SalesInvoiceParam.PO_WOno;
            SalesInvoices.Product = SalesInvoiceParam.Product;
            SalesInvoices.Quantity = SalesInvoiceParam.Quantity;
            SalesInvoices.Rate = SalesInvoiceParam.Rate;
            SalesInvoices.Revenue = SalesInvoiceParam.Revenue;
            SalesInvoices.SalesInvoiceDate = SalesInvoiceParam.SalesInvoiceDate;
            SalesInvoices.SalesInvoiceNo = SalesInvoiceParam.SalesInvoiceNo;
            SalesInvoices.SalesManagerIdFk = SalesInvoiceParam.SalesManagerIdFk;
            SalesInvoices.SalesOrdernoFk = SalesInvoiceParam.SalesOrdernoFk;
            SalesInvoices.ShippingAndHandling = SalesInvoiceParam.ShippingAndHandling;
            SalesInvoices.SubTotal = SalesInvoiceParam.SubTotal;
            SalesInvoices.Tax = SalesInvoiceParam.Total;
            SalesInvoices.Total = SalesInvoiceParam.Total;

            _db.SalesInvoice.Update(SalesInvoices);
            _db.SaveChanges();

            return SalesInvoices;
        }
    }
}
