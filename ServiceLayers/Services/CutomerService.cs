using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using ServiceLayers.Model;
using ServiceLayers.Model.ViewModel;

namespace ServiceLayers.Services
{
    public interface ICustomerService
    {
        IEnumerable<Customer> GetAll();
        Customer GetById(int id);
        Customer Create(Customer customer);
        Customer Update(Customer customer);
        void Delete(int id);
    }

    public class CutomerService : ICustomerService
    {
        private readonly ApplicationDbContext _db;
       // [BindProperty]
       // public ProductViewModel ProductsVM { get; set; }

        public CutomerService(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Customer> GetAll()
        {

            return _db.Customer;
        }

        public Customer GetById(int id)
        {
            return _db.Customer.Find(id);
        }
        public Customer Create(Customer customer)
        {
            customer.CreatedBy = "Admin";
            customer.CreatedDate = DateTime.Now;
            customer.Address = "hsaasja";
            _db.Customer.Add(customer);
            _db.SaveChanges();
            return customer;
        }

        public void Delete(int id)
        {
            var customer = _db.Customer.Find(id);
            if (customer != null)
            {
                _db.Customer.Remove(customer);
                _db.SaveChanges();
            }

        }

        public Customer Update(Customer customerParam)
        {
            var customer = _db.Customer.Find(customerParam.Id);
            if (customer == null)
                throw new Exception("Customer not found");

            if (customerParam.FirstName != customer.FirstName)
            {
                // type has changed so check if the new type is already taken
                if (_db.Customer.Any(x => x.FirstName == customerParam.FirstName))
                    throw new Exception(customerParam.FirstName + " is already taken");
            }

            //productTypes.UpdatedBy = User.Identity.Name;
            customer.FirstName = customerParam.FirstName;
            customer.LastName = customerParam.LastName;
            customer.MobileNo = customerParam.MobileNo;
            customer.PaymentMethod = customerParam.PaymentMethod;
            customer.PhoneNo = customerParam.PhoneNo;
            customer.SalesManager = customerParam.SalesManager;
            customer.IsActive = customerParam.IsActive;
            customer.FK_SalesManager = customerParam.FK_SalesManager;
            customer.EnterpriseName = customerParam.EnterpriseName;
            customer.Address = customerParam.Address;
            
            customer.UpdatedBy = "Admin";
            customer.UpdatedDate = DateTime.Now;
            
            
            _db.Customer.Update(customer);
            _db.SaveChanges();

            return customer;
        }

    }
}
