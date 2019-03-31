using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiceLayers.DTOs;
using ServiceLayers.Model;

namespace ServiceLayers.Services
{
    public interface IShoppingCartViewModelService
    {
        IEnumerable<ShoppingCartViewModel> GetAll();
        ShoppingCartViewModel GetById(int id);
        ShoppingCartViewModel Create(ShoppingCartViewModel shoppingCartViewModel);
        ShoppingCartViewModel Update(ShoppingCartViewModel shoppingCartViewModel);
        void Delete(int id);
    }

   public class ShoppingCartViewModelService:IShoppingCartViewModelService
    {
        private readonly ApplicationDbContext _db;

        public ShoppingCartViewModelService(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<ShoppingCartViewModel> GetAll()
        {
            return _db.ShoppingCartViewModel;
        }

        public ShoppingCartViewModel GetById(int id)
        {
            return _db.ShoppingCartViewModel.Find(id);
        }

        public ShoppingCartViewModel Create(ShoppingCartViewModel shoppingCartViewModel)
        {
            //productCategory.CreatedBy = User.Identity.Name;
            shoppingCartViewModel.CreatedBy = "Admin";
            shoppingCartViewModel.CreatedDate = DateTime.Now;
            _db.ShoppingCartViewModel.Add(shoppingCartViewModel);
            _db.SaveChanges();

            return shoppingCartViewModel;
        }

        public void Delete(int id)
        {
            var shoppingCartViewModel = _db.ShoppingCartViewModel.Find(id);
            if (shoppingCartViewModel != null)
            {
                _db.ShoppingCartViewModel.Remove(shoppingCartViewModel);
                _db.SaveChanges();
            }
        }

        public ShoppingCartViewModel Update(ShoppingCartViewModel shoppingParam)
        {
            var shoppingCartViewModel = _db.ShoppingCartViewModel.Find(shoppingParam.Id);
            if (shoppingCartViewModel == null)
                throw new Exception("Product Category not found");

            if (shoppingParam.ProductList != shoppingCartViewModel.ProductList)
            {
                // Category has changed so check if the new Category is already taken
                if (_db.ShoppingCartViewModel.Any(x => x.ProductList == shoppingParam.ProductList))
                    throw new Exception("This" + shoppingParam.ProductList + " is already taken");
            }
            shoppingCartViewModel.ProductList = shoppingParam.ProductList;
            shoppingCartViewModel.UpdatedBy = "Admin";
            shoppingCartViewModel.UpdatedDate = DateTime.Now;
            _db.ShoppingCartViewModel.Update(shoppingCartViewModel);
            _db.SaveChanges();
            return shoppingCartViewModel;
        }

    }
}
