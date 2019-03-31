using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiceLayers.Model;
namespace ServiceLayers.Services
{
    public interface IProductOptionService
    {
        IEnumerable<ProductOption> GetAll();
        ProductOption GetById(int id);
        ProductOption Create(ProductOption admin);
        ProductOption Update(ProductOption admin);
        void Delete(int id);

    }
   public class ProductOptionService: IProductOptionService
    {
        private readonly ApplicationDbContext _db;

        public ProductOptionService(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<ProductOption> GetAll()
        {
            return _db.ProductOption;
        }

        public ProductOption GetById(int id)
        {
            return _db.ProductOption.Find(id);
        }

        public ProductOption Create(ProductOption productOption)
        {
            //productCategory.CreatedBy = User.Identity.Name;
            productOption.CreatedBy = "Admin";
            productOption.CreatedDate = DateTime.Now;
            _db.ProductOption.Add(productOption);
            _db.SaveChanges();

            return productOption;
        }

        public void Delete(int id)
        {
            var productOption = _db.ProductOption.Find(id);
            if (productOption != null)
            {
                _db.ProductOption.Remove(productOption);
                _db.SaveChanges();
            }
        }

        public ProductOption Update(ProductOption productOptionParam)
        {
            var productOption = _db.ProductOption.Find(productOptionParam.Id);
            if (productOption == null)
                throw new Exception("Product Category not found");

            if (productOptionParam.Name != productOption.Name)
            {
                // Category has changed so check if the new Category is already taken
                if (_db.ProductOption.Any(x => x.Name == productOptionParam.Name))
                    throw new Exception("This" + productOptionParam.Name + " is already taken");
            }
            productOption.Name = productOptionParam.Name;
            productOption.Option = productOptionParam.Option;
            productOption.IsActive = productOptionParam.IsActive;

            productOption.UpdatedBy = "Admin";
            productOption.UpdatedDate = DateTime.Now;
            _db.ProductOption.Update(productOption);
            _db.SaveChanges();
            return productOption;
        }
    }
}
