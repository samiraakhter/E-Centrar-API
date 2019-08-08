using System;
using System.Collections.Generic;
using System.Text;
using ServiceLayers.Model;
using ServiceLayers.Model.ViewModel;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ServiceLayers.Services
{
    public interface IOrderLineService
    {
        IEnumerable<OrderLines> GetAll();
        OrderLines GetById(int id);
        OrderLines Create(OrderLines orderlines);
        OrderLines Update(OrderLines orderlines);
        void Delete(int id);
        IEnumerable<OrderLines> GetOrders(int orderId);
    }

    public class OrderLinesService: IOrderLineService
    {
        private readonly ApplicationDbContext _db;
        public OrderLinesService(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<OrderLines> GetAll()
        {

            return _db.OrderLines;
        }

        public OrderLines GetById(int id)
        {
            return _db.OrderLines.Find(id);
        }

        public IEnumerable<OrderLines> GetOrders(int orderId)
        {
            var lines = _db.OrderLines.Where(r => r.OrderIdFk == orderId).Include(m => m.Product).ToList(); 
            return lines;
        }
        public OrderLines Create(OrderLines orderlines)
        {
            orderlines.CreatedBy = "Admin";
            orderlines.CreatedDate = DateTime.Now;
            orderlines.IsActive = true;
            _db.OrderLines.Add(orderlines);
            _db.SaveChanges();
            return orderlines;
        }
        public void Delete(int id)
        {
            var orderlines = _db.OrderLines.Find(id);
            if (orderlines != null)
            {
                _db.OrderLines.Remove(orderlines);
                _db.SaveChanges();

            }
        }

        public OrderLines Update(OrderLines orderlinesParam)
        {
            var orderline = _db.OrderLines.Find(orderlinesParam.Id);
            if (orderline == null)
                throw new Exception("Product not found");

            if (orderlinesParam.Order != orderline.Order)
            {
                // type has changed so check if the new type is already taken
                if (_db.OrderLines.Any(x => x.Order == orderlinesParam.Order))
                    throw new Exception(orderlinesParam.Order + " is already taken");
            }

            //productTypes.UpdatedBy = User.Identity.Name;
            orderline.UpdatedBy = "Admin";
            orderline.UpdatedDate = DateTime.Now;
            orderline.Price = orderlinesParam.Price;
            orderline.OrderIdFk = orderlinesParam.OrderIdFk;
            orderline.Quantity = orderlinesParam.Quantity;
            orderline.ProductIdFk = orderlinesParam.ProductIdFk;
            orderline.TotalPrice = orderlinesParam.TotalPrice;
            orderline.IsActive = orderlinesParam.IsActive;


            _db.OrderLines.Update(orderline);
            _db.SaveChanges();

            return orderline;
        }

    }
}
