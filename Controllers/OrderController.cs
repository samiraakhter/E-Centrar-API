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
    public class OrderController : ControllerBase
    {
        private IOrderService _orderService;
        private readonly IMapper _mapper;

        public OrderController(IOrderService orderService, IMapper mapper) //mappers p h error? henana yaha to nh hai h
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        //GetAll
        [HttpGet]
        public IActionResult Get()
        {
            var order = _orderService.GetAll();
            return Ok(order);
        }

        //POST Create Action Method
        [HttpPost("Create")]
        [AllowAnonymous]
        public IActionResult Create([FromBody]OrderDTO orderDTO)
        {
            Order order = new Order();
            order.CustomerIdFk = orderDTO.CustomerIdFk;
            order.IsActive = orderDTO.IsActive;
            order.IsConfirmed = orderDTO.IsConfirmed;
            order.OrderDate = orderDTO.OrderDate;
            order.ProductIdFk = orderDTO.ProductIdFk;
            order.SalesOrderIdFk = orderDTO.SalesOrderIdFk;
            

            var orderEntity = _orderService.Create(order);
            var orders = _mapper.Map<OrderDTO>(orderEntity);
            return Ok(order);
        }

        //POST UPDATE Action Method
        [HttpPost("Update")]
        [AllowAnonymous]
        public IActionResult Update(int id, [FromBody] Order order)
        {
            if (ModelState.IsValid)
            {
                order.Id = id;
                //inventoryItemCategory.UpdatedBy = User.Identity.Name;
                var orderEntity = _orderService.Update(order);
                return Ok(orderEntity);
            }
            return BadRequest();
        }

        //GET Details Action method
        [HttpGet("Details")]
        public IActionResult Details(int id)
        {
            var order = _orderService.GetById(id);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        //GET Delete Action method
        [HttpGet("Delete")]
        public void Delete(int id)
        {
            _orderService.Delete(id);
        }
    }
}