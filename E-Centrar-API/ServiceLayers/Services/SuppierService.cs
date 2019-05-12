using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiceLayers.Model;


namespace ServiceLayers.Services
{
    public interface ISupplierService
    {
        IEnumerable<Supplier> GetAll();
        Supplier GetById(int id);
        Supplier Create(Supplier supplier);
        Supplier Update(Supplier supplier);
        void Delete(int id);
    }
   public class SuppierService: ISupplierService
    {
        private readonly ApplicationDbContext _db;

        public SuppierService(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Supplier> GetAll()
        {
            return _db.Supplier;
        }

        public Supplier GetById(int id)
        {
            return _db.Supplier.Find(id);
        }

        public Supplier Create(Supplier supplier)
        {
            //productCategory.CreatedBy = User.Identity.Name;
            supplier.CreatedBy = "Admin";
            supplier.CreatedDate = DateTime.Now;
            _db.Supplier.Add(supplier);
            _db.SaveChanges();

            return supplier;
        }
        public void Delete(int id)
        {
            var supplier = _db.Supplier.Find(id);
            if (supplier != null)
            {
                _db.Supplier.Remove(supplier);
                _db.SaveChanges();
            }
        }

        public Supplier Update(Supplier supplierParam)
        {
            var supplier = _db.Supplier.Find(supplierParam.Id);
            if (supplier == null)
                throw new Exception("Product Category not found");

            if (supplierParam.Suppliername != supplier.Suppliername)
            {
                // Category has changed so check if the new Category is already taken
                if (_db.Supplier.Any(x => x.Suppliername == supplierParam.Suppliername))
                    throw new Exception("This" + supplierParam.Suppliername + " is already taken");
            }
            supplier.Suppliername = supplierParam.Suppliername;
            supplier.UpdatedBy = "Admin";
            supplier.UpdatedDate = DateTime.Now;
            _db.Supplier.Update(supplier);
            _db.SaveChanges();
            return supplier;
        }

    }
}
