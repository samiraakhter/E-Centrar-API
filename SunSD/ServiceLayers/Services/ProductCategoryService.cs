using ServiceLayers.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceLayers.Services
{
    public interface IProductCategoryService
    {
        IEnumerable<ProductCategory> GetAll();
        ProductCategory GetById(int id);
        ProductCategory Create(ProductCategory productCategory);
        ProductCategory Update(ProductCategory productCategory);
        void Delete(int id);
    }
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly ApplicationDbContext _db;
       // private readonly User user;

        public ProductCategoryService(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<ProductCategory> GetAll()
        {
            return _db.ProductCategory;
        }

        public ProductCategory GetById(int id)
        {
            return _db.ProductCategory.Find(id);
        }

        public ProductCategory Create(ProductCategory productCategory)
        {
            _db.ProductCategory.Add(productCategory);
            _db.SaveChanges();

            return productCategory;
        }

        public void Delete(int id)
        {
            var productCategory = _db.ProductCategory.Find(id);
            if (productCategory != null)
            {
                _db.ProductCategory.Remove(productCategory);
                _db.SaveChanges();

            }

        }

        public ProductCategory Update(ProductCategory productCategoryParam)
        {
            var productCategory = _db.ProductCategory.Find(productCategoryParam.Id);
            if (productCategory == null)
                throw new Exception("Product Category not found");

            if (productCategoryParam.ProductCategoryName != productCategory.ProductCategoryName)
            {
                // Category has changed so check if the new Category is already taken
                if (_db.ProductCategory.Any(x => x.ProductCategoryName == productCategoryParam.ProductCategoryName))
                    throw new Exception("Category " + productCategoryParam.ProductCategoryName + " is already taken");
            }
            productCategory.ProductCategoryName = productCategoryParam.ProductCategoryName;

            _db.ProductCategory.Update(productCategory);
            _db.SaveChanges();
            return productCategory;
        }
    }
}

