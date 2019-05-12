using ServiceLayers.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceLayers.Services
{
    public interface IInventoryItemCategoryService
    {
        IEnumerable<InventoryItemCategory> GetAll();
        InventoryItemCategory GetById(int id);
        InventoryItemCategory Create(InventoryItemCategory inventoryItemCategory);
        InventoryItemCategory Update(InventoryItemCategory inventoryItemCategory);
        void Delete(int id);
    }
    public class InventoryItemCategoryService : IInventoryItemCategoryService
    {
        private readonly ApplicationDbContext _db;

        public InventoryItemCategoryService(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<InventoryItemCategory> GetAll()
        {
            return _db.InventoryItemCategory;
        }

        public InventoryItemCategory GetById(int id)
        {
            return _db.InventoryItemCategory.Find(id);
        }

        public InventoryItemCategory Create(InventoryItemCategory inventoryItemCategory)
        {
            //productCategory.CreatedBy = User.Identity.Name;
            inventoryItemCategory.CreatedBy = "Admin";
            inventoryItemCategory.CreatedDate = DateTime.Now;
            _db.InventoryItemCategory.Add(inventoryItemCategory);
            _db.SaveChanges();

            return inventoryItemCategory;
        }

        public void Delete(int id)
        {
            var inventoryItemCategory = _db.InventoryItemCategory.Find(id);
            if (inventoryItemCategory != null)
            {
                _db.InventoryItemCategory.Remove(inventoryItemCategory);
                _db.SaveChanges();
            }
        }

        public InventoryItemCategory Update(InventoryItemCategory inventoryItemCategoryParam)
        {
            var inventoryItemCategory = _db.InventoryItemCategory.Find(inventoryItemCategoryParam.Id);
            if (inventoryItemCategory == null)
                throw new Exception("Product Category not found");

            if (inventoryItemCategoryParam.InventoryItemCategoryName != inventoryItemCategory.InventoryItemCategoryName)
            {
                // Category has changed so check if the new Category is already taken
                if (_db.InventoryItemCategory.Any(x => x.InventoryItemCategoryName == inventoryItemCategoryParam.InventoryItemCategoryName))
                    throw new Exception("This" + inventoryItemCategoryParam.InventoryItemCategoryName + " is already taken");
            }
            inventoryItemCategory.InventoryItemCategoryName = inventoryItemCategoryParam.InventoryItemCategoryName;
            inventoryItemCategory.UpdatedBy = "Admin";
            inventoryItemCategory.UpdatedDate = DateTime.Now;
            _db.InventoryItemCategory.Update(inventoryItemCategory);
            _db.SaveChanges();
            return inventoryItemCategory;
        }
    }
}
