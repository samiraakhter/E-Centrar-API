using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceLayers.Model;
using ServiceLayers.Model.ViewModel;
using ServiceLayers.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayers.Services
{
    public interface IProductService
    {
        IEnumerable<Product> GetAll();
        Product GetById(int id);
        Product Create(Product product);
        Product Update(Product product);
        void Delete(int id);
    }
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _db;

        [BindProperty]
        public ProductViewModel ProductsVM { get; set; }

        public ProductService(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Product> GetAll()
        {
          //  var products = _db.Product.Include(m => m.ProductType).Include(m => m.ProductCategory);
            return _db.Product;
        }

        public Product GetById(int id)
        {
            return _db.Product.Find(id);
        }

        public Product Create(Product product)
        {
            product.CreatedBy = "Admin";
            product.CreatedDate = DateTime.Now;
            _db.Product.Add(product);
            _db.SaveChanges();
            return product;
           
        }

        public void Delete(int id)
        {
            var product = _db.Product.Find(id);
            if (product != null)
            {
                _db.Product.Remove(product);
                _db.SaveChanges();

            }
        }

        public Product Update(Product productParam)
        {
            var product = _db.Product.Find(productParam.Id);
            if (product == null)
                throw new Exception("Product not found");

            if (productParam.ProductName != product.ProductName)
            {
                // type has changed so check if the new type is already taken
                if (_db.Product.Any(x => x.ProductName == productParam.ProductName))
                    throw new Exception( productParam.ProductName + " is already taken");
            }
            
                //productTypes.UpdatedBy = User.Identity.Name;
                product.UpdatedBy = "Admin";
                product.UpdatedDate = DateTime.Now;
            product.ProductName = productParam.ProductName;
            product.Fullfilled = productParam.Fullfilled;
            product.Instock = productParam.Instock;
            product.Variants = productParam.Variants;
            product.IsActive = productParam.IsActive;
            product.OnHand = productParam.OnHand;
            product.ProductCategoryIdFk = productParam.ProductCategoryIdFk;
            product.ProductImage = productParam.ProductImage;
            product.ProductTypeIdFk = productParam.ProductTypeIdFk;
            product.Sku = productParam.Sku;


            _db.Product.Update(product);
            _db.SaveChanges();

            return product;
        }
    }
}
