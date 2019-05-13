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
    public interface IProductInfoService
    {
        IEnumerable<ProductInfo> GetAll();
        ProductInfo GetById(int id);
        ProductInfo Create(ProductInfo productinfo);
        ProductInfo Update(ProductInfo productinfo);
        void Delete(int id);
    }

    public class ProductInfoService : IProductInfoService
    {
        private readonly ApplicationDbContext _db;
         [BindProperty]
         public ProductViewModel ProductsVM { get; set; }

        public ProductInfoService(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<ProductInfo> GetAll()
        {

            return _db.ProductInfo;
        }

        public ProductInfo GetById(int id)
        {
            return _db.ProductInfo.Find(id);
        }
        public ProductInfo Create(ProductInfo productinfo)
        {
            productinfo.CreatedBy = "Admin";
            productinfo.CreatedDate = DateTime.Now;
            productinfo.CanBeExpensed = true;
            productinfo.CanBePurchased = true;
            productinfo.CanBeSold = true;
            productinfo.Ean = "aaa";
            productinfo.ProductCategoryIdFk = 3;
            productinfo.ProductImage = "working";
            productinfo.ProductTypeIdFk = 4;
            productinfo.IsActive = true;
            productinfo.ModelSku = "10";
            productinfo.ProductName = "juice";
            productinfo.Upc = "bbb";
            productinfo.ProductIdFk = 1;


            _db.ProductInfo.Add(productinfo);
            _db.SaveChanges();
            return productinfo;
        }
        public void Delete(int id)
        {
            var productinfo = _db.ProductInfo.Find(id);
            if (productinfo != null)
            {
                _db.ProductInfo.Remove(productinfo);
                _db.SaveChanges();

            }
        }

        public ProductInfo Update(ProductInfo productinfoParam)
        {
            var productinfo = _db.ProductInfo.Find(productinfoParam.Id);
            if (productinfo == null)
                throw new Exception("Product not found");

            if (productinfoParam.ProductName != productinfo.ProductName)
            {
                // type has changed so check if the new type is already taken
                if (_db.ProductInfo.Any(x => x.ProductName == productinfoParam.ProductName))
                    throw new Exception(productinfoParam.ProductName + " is already taken");
            }

            //productTypes.UpdatedBy = User.Identity.Name;
            productinfo.UpdatedBy = "Admin";
            productinfo.UpdatedDate = DateTime.Now;
            productinfo.CanBeExpensed = productinfoParam.CanBeExpensed;
            productinfo.CanBePurchased = productinfoParam.CanBePurchased;
            productinfo.CanBeSold = productinfoParam.CanBeSold;
            productinfo.Ean = productinfoParam.Ean;
            productinfo.ProductCategoryIdFk = productinfoParam.ProductCategoryIdFk;
            productinfo.ProductImage = productinfoParam.ProductImage;
            productinfo.ProductTypeIdFk = productinfoParam.ProductTypeIdFk;
            productinfo.IsActive = productinfoParam.IsActive;
            productinfo.ModelSku = productinfoParam.ModelSku;
            productinfo.ProductName = productinfoParam.ProductName;
            productinfo.Upc = productinfoParam.Upc;
            productinfo.ProductIdFk = productinfoParam.ProductIdFk;

            _db.ProductInfo.Update(productinfo);
            _db.SaveChanges();

            return productinfo;
        }
    }
}