using ServiceLayers.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceLayers.Services
{
    public interface IInventoryItemTypeService
    {
        IEnumerable<InventoryItemType> GetAll();
        InventoryItemType GetById(int id);
        InventoryItemType Create(InventoryItemType inventoryItemType);
        InventoryItemType Update(InventoryItemType inventoryItemType);
        void Delete(int id);
    }
    public class InventoryItemTypeService : IInventoryItemTypeService
    {
        private readonly ApplicationDbContext _db;

        public InventoryItemTypeService(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<InventoryItemType> GetAll()
        {
            return _db.InventoryItemType;
        }

        public InventoryItemType GetById(int id)
        {
            return _db.InventoryItemType.Find(id);
        }

        public InventoryItemType Create(InventoryItemType inventoryItemType)
        {
            //inventoryItemType.CreatedBy = User.Identity.Name;
            inventoryItemType.CreatedBy = "Admin";
            inventoryItemType.CreatedDate = DateTime.Now;
            _db.InventoryItemType.Add(inventoryItemType);
            _db.SaveChanges();

            return inventoryItemType;
        }

        public void Delete(int id)
        {
            var inventoryItemType = _db.InventoryItemType.Find(id);
            if (inventoryItemType != null)
            {
                _db.InventoryItemType.Remove(inventoryItemType);
                _db.SaveChanges();
            }
        }

        public InventoryItemType Update(InventoryItemType inventoryItemTypeParam)
        {
            var inventoryItemType = _db.InventoryItemType.Find(inventoryItemTypeParam.Id);
            if (inventoryItemType == null)
                throw new Exception("Product Type not found");

            if (inventoryItemTypeParam.InventoryItemTypeName != inventoryItemType.InventoryItemTypeName)
            {
                // type has changed so check if the new type is already taken
                if (_db.InventoryItemType.Any(x => x.InventoryItemTypeName == inventoryItemTypeParam.InventoryItemTypeName))
                    throw new Exception("This" + inventoryItemTypeParam.InventoryItemTypeName + " is already taken");
            }
            inventoryItemType.InventoryItemTypeName = inventoryItemTypeParam.InventoryItemTypeName;
            inventoryItemType.UpdatedBy = "Admin";
            inventoryItemType.UpdatedDate = DateTime.Now;
            _db.InventoryItemType.Update(inventoryItemType);
            _db.SaveChanges();
            return inventoryItemType;
        }
    }
}
