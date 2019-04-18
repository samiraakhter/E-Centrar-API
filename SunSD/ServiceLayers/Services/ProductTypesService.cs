using ServiceLayers.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceLayers.Services
{
    public interface IProductTypeService
    {
        IEnumerable<ProductType> GetAll();
        ProductType GetById(int id);
        ProductType Create(ProductType productType);
        ProductType Update(ProductType productTypes);
        void Delete(int id);
    }
   public class ProductTypesService : IProductTypeService
    {
        private readonly ApplicationDbContext _db;
        //private readonly User user;

        public ProductTypesService(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<ProductType> GetAll()
        {
            return _db.ProductType;
        }

        public ProductType GetById(int id)
        {
            return _db.ProductType.Find(id);
        }

        public ProductType Create(ProductType productType)
        {
            //productType.CreatedBy = User.Identity.Name;
            productType.CreatedBy = "Admin";
            productType.CreatedDate = DateTime.Now;
            _db.ProductType.Add(productType);
            _db.SaveChanges();

            return productType;
        }

        public void Delete(int id)
        {
            var productType = _db.ProductType.Find(id);
            if (productType != null)
            {
                _db.ProductType.Remove(productType);
                _db.SaveChanges();
                
            }
        }

        public ProductType Update(ProductType productTypeParam)
        {
            var productType = _db.ProductType.Find(productTypeParam.Id);
            if (productType == null)
                throw new Exception("Product Type not found");

            if (productTypeParam.ProductTypeName != productType.ProductTypeName)
            {
                // type has changed so check if the new type is already taken
                if (_db.ProductType.Any(x => x.ProductTypeName == productTypeParam.ProductTypeName))
                    throw new Exception("type " + productTypeParam.ProductTypeName + " is already taken");
            }
            productType.ProductTypeName = productTypeParam.ProductTypeName;
            //productTypes.UpdatedBy = User.Identity.Name;
            productType.UpdatedBy = "Admin";
            productType.UpdatedDate = DateTime.Now;

            _db.ProductType.Update(productType);
            _db.SaveChanges();
            return productType;
        }
    }
}