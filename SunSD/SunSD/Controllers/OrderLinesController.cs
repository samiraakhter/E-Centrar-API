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

namespace SunSD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderLinesController : ControllerBase
    {
        private IOrderLineService _orderlineService;
        private readonly IMapper _mapper;

        public OrderLinesController(IOrderLineService orderlineService, IMapper mapper)
        {
            _orderlineService = orderlineService;
            _mapper = mapper;
        }

        //GetAll
        [HttpGet]
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
            orderline.Sku = orderlineDTO.Sku;
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

        //GET Delete Action method
        [HttpGet("Delete")]
        public void Delete(int id)
        {
            _orderlineService.Delete(id);
        }
    }
}