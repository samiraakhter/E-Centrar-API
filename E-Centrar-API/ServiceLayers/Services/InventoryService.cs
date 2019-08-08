using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using ServiceLayers.Model;
using ServiceLayers.Model.ViewModel;
using System.Linq;

namespace ServiceLayers.Services
{
    public interface IInventoryService
    {
        IEnumerable<Inventory> GetAll();
        Inventory GetById(int id);
        Inventory Create(Inventory inventory);
        Inventory Update(Inventory inventory);
        void Delete(int id);
    }
      public class InventoryService: IInventoryService
    {
        private readonly ApplicationDbContext _db;
        public InventoryService(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Inventory> GetAll()
        {

            return _db.Inventory;
        }

        public Inventory GetById(int id)
        {
            return _db.Inventory.Find(id);
        }
        public Inventory Create(Inventory inventory)
        {
            inventory.CreatedBy = "Admin";
            inventory.CreatedDate = DateTime.Now;
            
            _db.Inventory.Add(inventory);
            _db.SaveChanges();
            return inventory;
        }
        public void Delete(int id)
        {
            var inventory = _db.Inventory.Find(id);
            if (inventory != null)
            {
                _db.Inventory.Remove(inventory);
                _db.SaveChanges();

            }
        }

        public Inventory Update(Inventory inventoryParam)
        {
            var inventory = _db.Inventory.Find(inventoryParam.Id);
            if (inventory == null)
                throw new Exception("Product not found");

            if (inventoryParam.Amount != inventory.Amount)
            {
                // type has changed so check if the new type is already taken
                if (_db.Inventory.Any(x => x.Amount == inventoryParam.Amount))
                    throw new Exception(inventoryParam.Amount + " is already taken");
            }

            //productTypes.UpdatedBy = User.Identity.Name;
            inventory.UpdatedBy = "Admin";
            inventory.UpdatedDate = DateTime.Now;

            inventory.Amount = inventoryParam.Amount;
            inventory.ProductFk = inventoryParam.ProductFk;
           // inventory.Product = inventoryParam.Product;
            inventory.DefaultLocation = inventoryParam.DefaultLocation;
            //inventory.InventoryItemFk = inventoryParam.InventoryItemFk;
            //inventory.InventoryItemTypeFk = inventoryParam.InventoryItemTypeFk;
            inventory.IsActive = inventoryParam.IsActive;
            inventory.MinimumStockLevel = inventoryParam.MinimumStockLevel;
            inventory.ReorderQuantity = inventoryParam.ReorderQuantity;
            inventory.Unit = inventoryParam.Unit;
            
            _db.Inventory.Update(inventory);
            _db.SaveChanges();

            return inventory;
        }

        //public Inventory UpdateStock(Product productParam)
        //{
        //    var product = _db.Product.Find(productParam.Id);
        //    if (inventory == null)
        //        throw new Exception("Product not found");

        //    if (productParam.Amount != inventory.Amount)
        //    {
        //        // type has changed so check if the new type is already taken
        //        if (_db.Inventory.Any(x => x.Amount == productParam.Amount))
        //            throw new Exception(productParam.Amount + " is already taken");
        //    }

        //    //productTypes.UpdatedBy = User.Identity.Name;
        //    inventory.UpdatedBy = "Admin";
        //    inventory.UpdatedDate = DateTime.Now;

        //    inventory.Amount = productParam.Amount;
        //    inventory.ProductFk = productParam.ProductFk;
        //    // inventory.Product = inventoryParam.Product;
        //    inventory.DefaultLocation = productParam.DefaultLocation;
        //    //inventory.InventoryItemFk = inventoryParam.InventoryItemFk;
        //    //inventory.InventoryItemTypeFk = inventoryParam.InventoryItemTypeFk;
        //    inventory.IsActive = productParam.IsActive;
        //    inventory.MinimumStockLevel = productParam.MinimumStockLevel;
        //    inventory.ReorderQuantity = productParam.ReorderQuantity;
        //    inventory.Unit = productParam.Unit;

        //    _db.Inventory.Update(inventory);
        //    _db.SaveChanges();

        //    return inventory;
        //}

    }
}
