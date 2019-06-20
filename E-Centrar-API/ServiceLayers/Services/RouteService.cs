using ServiceLayer.Model;
using ServiceLayers.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceLayer.Services
{
    public interface IRouteService
    {
        IEnumerable<Route> GetAll();
        Route GetById(int id);
        Route Create(Route route);
        Route Update(Route route);
        void Delete(int id);
    }
    public class RouteService : IRouteService
    {
        private readonly ApplicationDbContext _db;

        public RouteService(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Route> GetAll()
        {
            //  var Routes = _db.Route.Include(m => m.RouteType).Include(m => m.RouteCategory);
            return _db.Route;
        }

        public Route GetById(int id)
        {
            return _db.Route.Find(id);
        }

        public Route Create(Route route)
        {
            route.CreatedBy = "Admin";
            route.CreatedDate = DateTime.Today;
            _db.Route.Add(route);
            _db.SaveChanges();
            return route;

        }

        public void Delete(int id)
        {
            var route = _db.Route.Find(id);
            if (route != null)
            {
                _db.Route.Remove(route);
                _db.SaveChanges();

            }
        }

        public Route Update(Route routeParam)
        {
            var route = _db.Route.Find(routeParam.Id);
            if (route == null)
                throw new Exception("Route not found");

            if (routeParam.RouteName != route.RouteName)
            {
                // type has changed so check if the new type is already taken
                if (_db.Route.Any(x => x.RouteName == routeParam.RouteName))
                    throw new Exception(routeParam.RouteName + " is already taken");
            }

            //routeTypes.UpdatedBy = User.Identity.Name;
            route.UpdatedBy = "Admin";
            route.UpdatedDate = DateTime.Now;
            route.RouteName = routeParam.RouteName;
            route.Latitude = routeParam.Latitude;
            route.Longitude = routeParam.Longitude;
            route.DateOfVisit = routeParam.DateOfVisit;
            route.isRepeatable = routeParam.isRepeatable;
            route.isActive = routeParam.isActive;
            route.SalesPerson = routeParam.SalesPerson;

            _db.Route.Update(route);
            _db.SaveChanges();

            return route;
        }
    }
}
