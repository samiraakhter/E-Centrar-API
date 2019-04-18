using System;
using System.Collections.Generic;
using System.Text;
using ServiceLayers.Model;
using ServiceLayers.Model.ViewModel;
using System.Linq;

namespace ServiceLayers.Services
{

    public interface IInventoryItemService
    {
        IEnumerable<InventoryItem> GetAll();
        InventoryItem GetById(int id);
        InventoryItem Create(InventoryItem inventoryitem);
        InventoryItem Update(InventoryItem inventoryitem);
        void Delete(int id);
    }

    public class InventoryItemService: IInventoryItemService
    {
        private readonly ApplicationDbContext _db;
        public InventoryItemService(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<InventoryItem> GetAll()
        {

            return _db.InventoryItem;
        }

        public InventoryItem GetById(int id)
        {
            return _db.InventoryItem.Find(id);
        }
        public InventoryItem Create(InventoryItem inventoryitem)
        {
            inventoryitem.CreatedBy = "Admin";
            inventoryitem.CreatedDate = DateTime.Now;
            inventoryitem.IsActive = true;

            _db.InventoryItem.Add(inventoryitem);
            _db.SaveChanges();
            return inventoryitem;
        }
        public void Delete(int id)
        {
            var inventoryitem = _db.InventoryItem.Find(id);
            if (inventoryitem != null)
            {
                _db.InventoryItem.Remove(inventoryitem);
                _db.SaveChanges();

            }
        }

        public InventoryItem Update(InventoryItem inventoryitemParam)
        {
            var inventoryitem = _db.InventoryItem.Find(inventoryitemParam.Id);
            if (inventoryitem == null)
                throw new Exception("Product not found");

            if (inventoryitemParam.InventoryItemName != inventoryitem.InventoryItemName)
            {
                // type has changed so check if the new type is already taken
                if (_db.InventoryItem.Any(x => x.InventoryItemName == inventoryitemParam.InventoryItemName))
                    throw new Exception(inventoryitemParam.InventoryItemName + " is already taken");
            }

            //productTypes.UpdatedBy = User.Identity.Name;
            inventoryitem.UpdatedBy = "Admin";
            inventoryitem.UpdatedDate = DateTime.Now;
            inventoryitem.InventoryItemCategoryFk = inventoryitemParam.InventoryItemCategoryFk;
            inventoryitem.InventoryItemName = inventoryitemParam.InventoryItemName;
           
            inventoryitem.IsActive = inventoryitemParam.IsActive;


            _db.InventoryItem.Update(inventoryitem);
            _db.SaveChanges();

            return inventoryitem;
        }

    }
}
