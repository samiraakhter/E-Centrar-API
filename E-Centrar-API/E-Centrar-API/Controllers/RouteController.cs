using System;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.DTOs;
using ServiceLayer.Model;
using ServiceLayer.Services;
using ServiceLayers;

namespace ECentrarApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RouteController : ControllerBase
    {
        private IRouteService _routeService;
            private readonly IMapper _mapper;

            public RouteController(IRouteService routeservice, IMapper mapper)
            {
                _routeService = routeservice;
                _mapper = mapper;
            }

            [HttpGet]
            public IActionResult Get()
            {
                var routes = _routeService.GetAll();
                return Ok(routes);
            }

            //POST Create Action Method
            [HttpPost("Create")]
            public IActionResult Create([FromBody]RouteDTO routeDTO)
            {
            try
            {
                Route route = new Route();
                route.RouteName = routeDTO.RouteName;
                route.Latitude = routeDTO.Latitude;
                route.Longitude = routeDTO.Longitude;
                route.DateOfVisit = route.DateOfVisit;
                route.isActive = route.isActive;
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
            [HttpGet("Delete")]
            public void Delete(int id)
            {
                _routeService.Delete(id);
            }
        }

}