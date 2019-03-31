using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiceLayers.Model;

namespace ServiceLayers.Services
{
    public interface IPriceService
    {
        IEnumerable<Price> GetAll();
        Price GetById(int id);
        Price Create(Price price);
        Price Update(Price price);
        void Delete(int id);
    }

    public class PriceService : IPriceService
    {
        private readonly ApplicationDbContext _db;

        public PriceService(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Price> GetAll()
        {

            return _db.Price;
        }

        public Price GetById(int id)
        {
            return _db.Price.Find(id);
        }

        public Price Create(Price price)
        {
            //productCategory.CreatedBy = User.Identity.Name;
            price.CreatedBy = "Admin";
            price.CreatedDate = DateTime.Now;
            _db.Price.Add(price);
            _db.SaveChanges();

            return price;
        }

        public void Delete(int id)
        {
            var price = _db.Price.Find(id);
            if (price != null)
            {
                _db.Price.Remove(price);
                _db.SaveChanges();
            }
        }

        public Price Update(Price priceParam)
        {
            var price = _db.Price.Find(priceParam.Id);
            if (price == null)
                throw new Exception("Product Category not found");

            if (priceParam.Price1 != price.Price1)
            {
                // Category has changed so check if the new Category is already taken
                if (_db.Price.Any(x => x.Price1 == priceParam.Price1))
                    throw new Exception("This" + priceParam.Price1 + " is already taken");
            }
            price.Price1 = priceParam.Price1;
            
            price.Count = priceParam.Count;
            price.IsActive = priceParam.IsActive;

            price.UpdatedBy = "Admin";
            price.UpdatedDate = DateTime.Now;
            _db.Price.Update(price);
            _db.SaveChanges();
            return price;
        }
    }
}


