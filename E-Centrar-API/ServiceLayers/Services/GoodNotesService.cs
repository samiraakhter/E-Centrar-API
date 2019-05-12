using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ServiceLayers.Model;

namespace ServiceLayers.Services
{
    public interface IGoodNotesService
    {
        IEnumerable<GoodsNotes> GetAll();
        GoodsNotes GetById(int id);
        GoodsNotes Create(GoodsNotes goodsNotes);
        GoodsNotes Update(GoodsNotes goodsNotes);
        void Delete(int id);
    }

    public class GoodNotesService: IGoodNotesService
    {
        private readonly ApplicationDbContext _db;
        public GoodNotesService(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<GoodsNotes> GetAll()
        {

            return _db.GoodsNotes;
        }

        public GoodsNotes GetById(int id)
        {
            return _db.GoodsNotes.Find(id);
        }

        public GoodsNotes Create(GoodsNotes goodsNotes)
        {
            goodsNotes.CreatedBy = "Admin";
            goodsNotes.CreatedDate = DateTime.Now;
            
            _db.GoodsNotes.Add(goodsNotes);
            _db.SaveChanges();
            return goodsNotes;
        }

        public void Delete(int id)
        {
            var goodsNotes = _db.GoodsNotes.Find(id);
            if (goodsNotes != null)
            {
                _db.GoodsNotes.Remove(goodsNotes);
                _db.SaveChanges();

            }
        }
        public GoodsNotes Update(GoodsNotes goodsNotesParam)
        {
            var goodsNotes = _db.GoodsNotes.Find(goodsNotesParam.Id);
            if (goodsNotes == null)
                throw new Exception("Product not found");

            if (goodsNotesParam.OrderStatus != goodsNotes.OrderStatus)
            {
                // type has changed so check if the new type is already taken
                if (_db.GoodsNotes.Any(x => x.OrderStatus == goodsNotesParam.OrderStatus))
                    throw new Exception(goodsNotesParam.OrderStatus + " is already taken");
            }

            //productTypes.UpdatedBy = User.Identity.Name;
            goodsNotes.UpdatedBy = "Admin";
            goodsNotes.UpdatedDate = DateTime.Now;
            goodsNotes.IsActive = goodsNotesParam.IsActive;
            goodsNotes.DeliverTo = goodsNotesParam.DeliverTo;
            goodsNotes.Order = goodsNotesParam.Order;
            goodsNotes.OrderIdFk = goodsNotesParam.OrderIdFk;
            goodsNotes.OrderStatus = goodsNotesParam.OrderStatus;
            goodsNotes.Packed = goodsNotesParam.Packed;
            goodsNotes.Picked = goodsNotesParam.Picked;
            goodsNotes.Printed = goodsNotesParam.Printed;
            goodsNotes.Shipped = goodsNotesParam.Shipped;
            goodsNotes.Warehouse = goodsNotesParam.Warehouse;
           
            _db.GoodsNotes.Update(goodsNotes);
            _db.SaveChanges();

            return goodsNotes;
        }

    }
}
