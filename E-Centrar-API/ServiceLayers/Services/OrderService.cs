using System;
using System.Collections.Generic;
using System.Text;
using ServiceLayers.Model;
using ServiceLayers.Model.ViewModel;
using System.Linq;


namespace ServiceLayers.Services
{
    public interface IOrderService
    {
        IEnumerable<Order> GetAll();
        Order GetById(int id);
        Order Create(Order order);
        Order Update(Order order);
        void Delete(int id);
    }
   public class OrderService: IOrderService
    {
        private readonly ApplicationDbContext _db;
        public OrderService(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Order> GetAll()
        {

            return _db.Order;
        }

        public Order GetById(int id)
        {
            return _db.Order.Find(id);
        }
        public Order Create(Order order)
        {
            order.CreatedBy = "Admin";
            order.CreatedDate = DateTime.Now;
            order.IsActive = true;
            _db.Order.Add(order);
            _db.SaveChanges();
            return order;
        }
        public void Delete(int id)
        {
            var order = _db.Order.Find(id);
            if (order != null)
            {
                _db.Order.Remove(order);
                _db.SaveChanges();

            }
        }

        public Order Update(Order orderParam)
        {
            var order = _db.Order.Find(orderParam.Id);
            if (order == null)
                throw new Exception("Product not found");

            if (orderParam.Customer != order.Customer)
            {
                // type has changed so check if the new type is already taken
                if (_db.Order.Any(x => x.Customer == orderParam.Customer))
                    throw new Exception(orderParam.Customer + " is already taken");
            }

            //productTypes.UpdatedBy = User.Identity.Name;
            order.UpdatedBy = "Admin";
            order.UpdatedDate = DateTime.Now;
            order.CustomerIdFk = orderParam.CustomerIdFk;
            order.IsActive = orderParam.IsActive;
            order.IsConfirmed = orderParam.IsConfirmed;
            order.OrderDate = orderParam.OrderDate;
            order.IsActive = orderParam.IsActive;


            _db.Order.Update(order);
            _db.SaveChanges();

            return order;
        }

    }
}
