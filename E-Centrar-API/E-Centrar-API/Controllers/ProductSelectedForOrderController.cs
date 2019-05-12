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
    public class ProductSelectedForOrderController : ControllerBase
    {
        private IProductSelectedForOrderService _productorderService;
        private readonly IMapper _mapper;

        public ProductSelectedForOrderController(IProductSelectedForOrderService productorderService, IMapper mapper)
        {
            _productorderService = productorderService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var product = _productorderService.GetAll();
            return Ok(product);
        }

        //POST Create Action Method
        [HttpPost("Create")]
        [AllowAnonymous]
        public IActionResult Create([FromBody]ProductSelectedForOrderDTO productorderDTO)
        {
            ProductSelectedForOrder product = new ProductSelectedForOrder();
            product.OrderIdFk = productorderDTO.OrderIdFk;
            product.ProductIdFk = productorderDTO.ProductIdFk;
            //productType.CreatedBy = User.Identity.Name;
            var productorderEntity = _productorderService.Create(product);
            var products = _mapper.Map<ProductSelectedForOrderDTO>(productorderEntity);


            return Ok(product);
        }
        //POST UPDATE Action Method
        [HttpPost("Update")]
        [AllowAnonymous]
        public IActionResult Update(int id, [FromBody]ProductSelectedForOrder productorder)
        {
            if (ModelState.IsValid)
            {
                productorder.Id = id;
                //productTypes.UpdatedBy = User.Identity.Name;
                productorder.UpdatedBy = "Admin";
                productorder.UpdatedDate = DateTime.Now;
                var ProductOrderEntity = _productorderService.Update(productorder);
                return Ok(ProductOrderEntity);
            }
            return BadRequest();
        }

        //GET Details Action method
        [HttpGet("Details")]
        public IActionResult Details(int id)
        {
            var product = _productorderService.GetById(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        //GET Delete Action method
        [HttpGet("Delete")]
        public void Delete(int id)
        {
            _productorderService.Delete(id);
        }
    }
}