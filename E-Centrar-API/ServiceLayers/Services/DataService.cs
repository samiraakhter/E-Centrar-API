using ServiceLayers.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.Services
{

    public interface IDataService
    {
        Product UpdateStock(int productId, int quantity);
    }
    public class DataService : IDataService
    {
        private readonly ApplicationDbContext _db;
        public DataService(ApplicationDbContext db)
        {
            _db = db;
        }
        public Product UpdateStock(int productId,int quantity)
        {
            var product = _db.Product.Find(productId);
            if (product == null)
                throw new Exception("Product not found");

          

            //productTypes.UpdatedBy = User.Identity.Name;
           
            product.Instock = product.Instock - quantity;


            _db.Product.Update(product);
            _db.SaveChanges();

            return product;
        }
    }

}