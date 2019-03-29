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
    public class PurchaseOrderController : ControllerBase
    {
        private IPurchaseOrderService _purchaseService;
        private readonly IMapper _mapper;

        public PurchaseOrderController(IPurchaseOrderService purchaseService, IMapper mapper)
        {
            _purchaseService = purchaseService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var product = _purchaseService.GetAll();
            return Ok(product);
        }

        //POST Create Action Method
        [HttpPost("Create")]
        [AllowAnonymous]
        public IActionResult Create([FromBody]PurchaseOrderDTO purchaseDTO)
        {
            PurchaseOrder purchase = new PurchaseOrder();
            purchase.PurchaseOrderNo = purchaseDTO.PurchaseOrderNo;
            //productType.CreatedBy = User.Identity.Name;
            var purchaseEntity = _purchaseService.Create(purchase);
            var products = _mapper.Map<PurchaseOrderDTO>(purchaseEntity);


            return Ok(purchase);
        }
        //POST UPDATE Action Method
        [HttpPost("Update")]
        [AllowAnonymous]
        public IActionResult Update(int id, [FromBody]PurchaseOrder purchase)
        {
            if (ModelState.IsValid)
            {
                purchase.Id = id;
                //productTypes.UpdatedBy = User.Identity.Name;
                purchase.UpdatedBy = "Admin";
                purchase.UpdatedDate = DateTime.Now;
                var PurchaseEntity = _purchaseService.Update(purchase);
                return Ok(PurchaseEntity);
            }
            return BadRequest();
        }

        //GET Details Action method
        [HttpGet("Details")]
        public IActionResult Details(int id)
        {
            var purchase = _purchaseService.GetById(id);
            if (purchase == null)
            {
                return NotFound();
            }
            return Ok(purchase);
        }

        //GET Delete Action method
        [HttpGet("Delete")]
        public void Delete(int id)
        {
            _purchaseService.Delete(id);
        }
    }
}