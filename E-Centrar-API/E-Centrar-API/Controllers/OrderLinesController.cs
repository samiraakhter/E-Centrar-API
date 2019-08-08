using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayers.DTOs;
using ServiceLayers.Model;
using ServiceLayers.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Kendo.Mvc.UI;
using Microsoft.EntityFrameworkCore;
using Kendo.Mvc.Extensions;

namespace ECentrarApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderLinesController : Controller
    {
        private IOrderLineService _orderlineService;
        private readonly IMapper _mapper;
        private ApplicationDbContext _db;

        public OrderLinesController(IOrderLineService orderlineService, IMapper mapper, ApplicationDbContext db)
        {
            _orderlineService = orderlineService;
            _mapper = mapper;
            _db = db;
        }

        [HttpGet]
        [Produces("application/json")]
        public JsonResult Get([DataSourceRequest]DataSourceRequest request)
        {

            var inventories = _db.OrderLines.Include(m => m.Order).Include(m => m.Product).ToList();
            return Json(inventories.ToDataSourceResult(request));
        }

        //GetAll
        [HttpGet("GetAll")]
        public IActionResult Get()
        {
            var orderline = _orderlineService.GetAll();
            return Ok(orderline);
        }

        //POST Create Action Method
        [HttpPost("Create")]
        [AllowAnonymous]
        public IActionResult Create([FromBody]OrderLinesDTO orderlineDTO)
        {
            OrderLines orderline = new OrderLines();
            orderline.Price= orderlineDTO.Price;
            orderline.OrderIdFk = orderlineDTO.OrderIdFk;
            orderline.Quantity = orderlineDTO.Quantity;
            orderline.ProductIdFk = orderlineDTO.ProductIdFk;
            orderline.TotalPrice = orderlineDTO.TotalPrice;
           
            var orderlineEntity = _orderlineService.Create(orderline);
            var orderlines = _mapper.Map<OrderLinesDTO>(orderlineEntity);
            return Ok(orderline);
        }

        //POST UPDATE Action Method
        [HttpPost("Update")]
        [AllowAnonymous]
        public IActionResult Update(int id, [FromBody] OrderLines orderline)
        {
            if (ModelState.IsValid)
            {
                orderline.Id = id;
                //inventoryItemCategory.UpdatedBy = User.Identity.Name;
                var orderlineEntity = _orderlineService.Update(orderline);
                return Ok(orderlineEntity);
            }
            return BadRequest();
        }

        //GET Details Action method
        [HttpGet("Details")]
        public IActionResult Details(int id)
        {
            var orderline = _orderlineService.GetById(id);
            if (orderline == null)
            {
                return NotFound();
            }
            return Ok(orderline);
        }
        //orderlines of particular order
        [HttpGet("GetOrder")]
        [Produces("application/json")]
        public JsonResult GetOrder(int id, [DataSourceRequest]DataSourceRequest request)
        {
            var orderline = _orderlineService.GetOrders(id);
            return Json(orderline.ToDataSourceResult(request));
        }

        //GET Delete Action method
        [HttpGet("Delete")]
        public void Delete(int id)
        {
            _orderlineService.Delete(id);
        }
    }
}