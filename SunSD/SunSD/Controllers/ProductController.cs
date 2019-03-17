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
    public class ProductController : ControllerBase
    {
        private IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var product = _productService.GetAll();
            return Ok(product);
        }

        //POST Create Action Method
        [HttpPost("Create")]
        [AllowAnonymous]
        public IActionResult Create([FromBody]ProductDTO productDTO)
        {
            Product product = new Product();
            product.ProductName = productDTO.ProductName;
            //productType.CreatedBy = User.Identity.Name;
            var productEntity = _productService.Create(product);
            var products = _mapper.Map<ProductDTO>(productEntity);
           
          
            return Ok(product);
        }
        //POST UPDATE Action Method
        [HttpPost("Update")]
        [AllowAnonymous]
        public IActionResult Update(int id, [FromBody]Product products)
        {
            if (ModelState.IsValid)
            {
                products.Id = id;
                //productTypes.UpdatedBy = User.Identity.Name;
                products.UpdatedBy = "Admin";
                products.UpdatedDate = DateTime.Now;
                var ProductEntity = _productService.Update(products);
                return Ok(ProductEntity);
            }
            return BadRequest();
        }

        //GET Details Action method
        [HttpGet("Details")]
        public IActionResult Details(int id)
        {
            var product = _productService.GetById(id);
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
            _productService.Delete(id);
        }
    }
}