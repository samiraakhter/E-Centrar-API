using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayers.DTOs;
using ServiceLayers.Model;
using ServiceLayers.Services;

namespace SunSD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesOrderController : ControllerBase
    {
        private ISalesOrderService _salesorderService;
        private readonly IMapper _mapper;

        public SalesOrderController(ISalesOrderService salesorderService, IMapper mapper)
        {
            _salesorderService = salesorderService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var salesOrders = _salesorderService.GetAll();
            return Ok(salesOrders);
        }

        //POST Create Action Method
        [HttpPost("Create")]
        [AllowAnonymous]
        public IActionResult Create([FromBody]SaleOrderDTO salesorderDTO)
        {
            SalesOrder SalesOrder = new SalesOrder();
            SalesOrder.EnterpriseName = salesorderDTO.EnterpriseName;
            //productType.CreatedBy = User.Identity.Name;
            var saleorderEntity = _salesorderService.Create(SalesOrder);
            var sales = _mapper.Map<SaleOrderDTO>(saleorderEntity);


            return Ok(SalesOrder);
        }
        //POST UPDATE Action Method
        [HttpPost("Update")]
        [AllowAnonymous]
        public IActionResult Update(int id, [FromBody]SalesOrder SaleOrder)
        {
            if (ModelState.IsValid)
            {
                SaleOrder.Id = id;
                //productTypes.UpdatedBy = User.Identity.Name;
                SaleOrder.UpdatedBy = "Admin";
                SaleOrder.UpdatedDate = DateTime.Now;
                var salesorderEntity = _salesorderService.Update(SaleOrder);
                return Ok(salesorderEntity);
            }
            return BadRequest();
        }

        //GET Details Action method
        [HttpGet("Details")]
        public IActionResult Details(int id)
        {
            var SaleOrder = _salesorderService.GetById(id);
            if (SaleOrder == null)
            {
                return NotFound();
            }
            return Ok(SaleOrder);
        }

        //GET Delete Action method
        [HttpGet("Delete")]
        public void Delete(int id)
        {
            _salesorderService.Delete(id);
        }
    }
}