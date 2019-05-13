using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiceLayers.Model;
using ServiceLayers.Model.ViewModel;

namespace ServiceLayers.Services
{
    public interface ISalesPersonService
    {
        IEnumerable<SalesPerson> GetAll();
        SalesPerson GetById(int id);
        SalesPerson Create(SalesPerson SalesPerson);
        SalesPerson Update(SalesPerson SalesPerson);
        void Delete(int id);
    }
    public class SalesPersonService: ISalesPersonService
    {
        private readonly ApplicationDbContext _db;
        public SalesPersonService(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<SalesPerson> GetAll()
        {

            return _db.SalesPerson;
        }

        public SalesPerson GetById(int id)
        {
            return _db.SalesPerson.Find(id);
        }
        public SalesPerson Create(SalesPerson salesPerson)
        {
            salesPerson.CreatedBy = "Admin";
            salesPerson.CreatedDate = DateTime.Now;
            
            _db.SalesPerson.Add(salesPerson);
            _db.SaveChanges();
            return salesPerson;
        }

        public void Delete(int id)
        {
            var salesPerson = _db.SalesPerson.Find(id);
            if (salesPerson != null)
            {
                _db.SalesPerson.Remove(salesPerson);
                _db.SaveChanges();
            }

        }

        public SalesPerson Update(SalesPerson SalesPersonParam)
        {
            var salesperson = _db.SalesPerson.Find(SalesPersonParam.Id);
            if (salesperson == null)
                throw new Exception("Customer not found");

            if (SalesPersonParam.FirstName != salesperson.FirstName)
            {
                // type has changed so check if the new type is already taken
                if (_db.SalesPerson.Any(x => x.FirstName == SalesPersonParam.FirstName))
                    throw new Exception(SalesPersonParam.FirstName + " is already taken");
            }

            //productTypes.UpdatedBy = User.Identity.Name;
            salesperson.UpdatedBy = "Admin";
            salesperson.UpdatedDate = DateTime.Now;
            salesperson.CreatedBy = "Admin";
            salesperson.Address = SalesPersonParam.Address;
            salesperson.FirstName = SalesPersonParam.FirstName;
            salesperson.IsActive = SalesPersonParam.IsActive;
            salesperson.LastName = SalesPersonParam.LastName;
            salesperson.MobileNo = SalesPersonParam.MobileNo;
            salesperson.Password = SalesPersonParam.Password;
            salesperson.PhoneNo = SalesPersonParam.PhoneNo;
            salesperson.Salary = SalesPersonParam.Salary;
            // salesperson.SalesPersonId = SalesPersonParam.SalesPersonId;
            salesperson.UserName = SalesPersonParam.UserName;

            _db.SalesPerson.Update(salesperson);
            _db.SaveChanges();

            return salesperson;
        }

    }
}
