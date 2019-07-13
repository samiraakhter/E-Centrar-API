using System;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceLayers.Model;
using ServiceLayers;
using System.Linq;
using ServiceLayer.Services;
using ServiceLayer.DTOs;
using ServiceLayer.Model;
using Microsoft.EntityFrameworkCore;

namespace ECentrarApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RouteController : Controller
    {
        private IRouteService _routeService;
        private readonly IMapper _mapper;
        private ApplicationDbContext _db;

        public RouteController(IRouteService routeservice, IMapper mapper, ApplicationDbContext db)
            {
                _routeService = routeservice;
                _mapper = mapper;
                _db = db;
        }

        //GetAll
            [HttpGet("GetAll")]
            public IActionResult Get()
            {
                var routes = _routeService.GetAll();
                return Ok(routes);
            }

        [HttpGet]
        [Produces("application/json")]
        public JsonResult Get([DataSourceRequest]DataSourceRequest request)
        {
            try
            {
                var routes = _db.Route.Include(m => m.GetSalesPerson).ToList();
                return Json(routes.ToDataSourceResult(request));

            }
            catch (Exception ex)
            {

                Logger.Fatal(ex.Message);
                Logger.Fatal(ex.Source);
                Logger.Fatal(ex.StackTrace);
                if (ex.InnerException != null)
                {
                    Logger.Fatal(ex.InnerException.Message);
                    Logger.Fatal(ex.InnerException.Source);
                    Logger.Fatal(ex.InnerException.StackTrace);
                }
                return Json(new { message = ex.Message });
            }

            
        }

        //POST Create Action Method
        [HttpPost("Create")]
            public IActionResult Create([FromBody]RouteDTO routeDTO)
            {
            try
            {
                Route route = new Route();
                route.RouteName = routeDTO.RouteName;
                route.DateOfVisit = routeDTO.DateOfVisit;
                route.isActive = routeDTO.isActive;
                route.isRepeatable = routeDTO.isRepeatable;
                route.SalesPerson = routeDTO.SalesPerson;

                //productType.CreatedBy = User.Identity.Name;
                var routeEntity = _routeService.Create(route);
                var routes = _mapper.Map<RouteDTO>(routeEntity);


                return Ok(route);
            }
            catch (Exception ex)
            {

                Logger.Fatal(ex.Message);
                Logger.Fatal(ex.Source);
                Logger.Fatal(ex.StackTrace);
                if (ex.InnerException != null)
                {
                    Logger.Fatal(ex.InnerException.Message);
                    Logger.Fatal(ex.InnerException.Source);
                    Logger.Fatal(ex.InnerException.StackTrace);
                }
                return null;
            }
            }
            //POST UPDATE Action Method
            [HttpPost("Update")]
            [AllowAnonymous]
            public IActionResult Update(int id, [FromBody]Route route)
            {
                if (ModelState.IsValid)
                {
                    route.Id = id;
                    //productTypes.UpdatedBy = User.Identity.Name;
                    route.UpdatedBy = "Admin";
                    route.UpdatedDate = DateTime.Now;
                    var routeEntity = _routeService.Update(route);
                    return Ok(routeEntity);
                }
                return BadRequest();
            }

            //GET Details Action method
            [HttpGet("Details")]
            public IActionResult Details(int id)
            {
                var route = _routeService.GetById(id);
                if (route == null)
                {
                    return NotFound();
                }
                return Ok(route);
            }

        //GET Delete Action method
        [HttpDelete("Delete")]
        public void Delete(int id)
            {
                _routeService.Delete(id);
            }
        }

}