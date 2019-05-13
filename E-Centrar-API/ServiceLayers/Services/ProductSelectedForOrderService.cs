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
    public interface IProductSelectedForOrderService
    {
        IEnumerable<ProductSelectedForOrder> GetAll();
        ProductSelectedForOrder GetById(int id);
        ProductSelectedForOrder Create(ProductSelectedForOrder productSelectedForOrder);
        ProductSelectedForOrder Update(ProductSelectedForOrder productSelectedForOrder);
        void Delete(int id);
    }
    public class ProductSelectedForOrderService: IProductSelectedForOrderService
    {
        private readonly ApplicationDbContext _db;
       [BindProperty]
        public ProductViewModel ProductsVM { get; set; }

        public ProductSelectedForOrderService(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<ProductSelectedForOrder> GetAll()
        {

            return _db.ProductSelectedForOrder;
        }

        public ProductSelectedForOrder GetById(int id)
        {
            return _db.ProductSelectedForOrder.Find(id);
        }

        public ProductSelectedForOrder Create(ProductSelectedForOrder productorder)
        {
            productorder.CreatedBy = "Admin";
            productorder.CreatedDate = DateTime.Now;
            productorder.IsActive = true;
            
            
            _db.ProductSelectedForOrder.Add(productorder);
            _db.SaveChanges();
            return productorder;

        }

        public void Delete(int id)
        {
            var productorder = _db.ProductSelectedForOrder.Find(id);
            if (productorder != null)
            {
                _db.ProductSelectedForOrder.Remove(productorder);
                _db.SaveChanges();

            }
        }

        public ProductSelectedForOrder Update(ProductSelectedForOrder productParam)
        {
            var product = _db.ProductSelectedForOrder.Find(productParam.Id);
            if (product == null)
                throw new Exception("Product not found");

            if (productParam.OrderIdFk != product.OrderIdFk)
            {
                // type has changed so check if the new type is already taken
                if (_db.ProductSelectedForOrder.Any(x => x.OrderIdFk == productParam.OrderIdFk))
                    throw new Exception(productParam.OrderIdFk + " is already taken");
            }

            //productTypes.UpdatedBy = User.Identity.Name;
            product.UpdatedBy = "Admin";
            product.UpdatedDate = DateTime.Now;
            product.OrderIdFk = productParam.OrderIdFk;
           
            product.ProductIdFk = productParam.ProductIdFk;
            product.ProductIdFk = productParam.ProductIdFk;
            product.IsActive = productParam.IsActive;
           


            _db.ProductSelectedForOrder.Update(product);
            _db.SaveChanges();

            return product;
        }
    }
    }
