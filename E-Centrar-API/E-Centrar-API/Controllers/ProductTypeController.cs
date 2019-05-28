using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayers.Model;
using ServiceLayers.DTOs;
using ServiceLayers.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;

namespace ECentrarApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductTypeController : ControllerBase
    {
        private IProductTypeService _productTypesService;
        private readonly IMapper _mapper;

        public ProductTypeController(IProductTypeService productTypesService , IMapper mapper)
        {
            _productTypesService = productTypesService;
            _mapper = mapper;
        }

        //GetAll
        [HttpGet]
        public IActionResult Get()
        {
            var productTypes = _productTypesService.GetAll();
            return Ok(productTypes);
        }

        //POST Create Action Method
        [HttpPost("Create")]
        [AllowAnonymous]
        public IActionResult Create([FromBody]ProductTypeDTO productTypeDTO )
        {
            ProductType productType = new ProductType();
            productType.ProductTypeName = productTypeDTO.ProductTypeName;
            var productTypeEntity = _productTypesService.Create(productType);
            var productTypes = _mapper.Map<ProductTypeDTO>(productTypeEntity);
            return Ok(productType);
        }

        //POST UPDATE Action Method
        [HttpPost("Update")]
        [AllowAnonymous]
        public IActionResult Update(int id, [FromBody]ProductType productTypes)
        {
            if (ModelState.IsValid)
            {
                productTypes.Id = id;
                var ProductTypeEntity = _productTypesService.Update(productTypes);
                return Ok(ProductTypeEntity);
            }
            return BadRequest();
        }

        //GET Details Action method
        [HttpGet("Details")]
        public IActionResult Details(int id)
        {
            var productType = _productTypesService.GetById(id);
            if (productType == null)
            {
                return NotFound();
            }
            return Ok(productType);
        }

        //GET Delete Action method
        [HttpGet("Delete")]
        public void Delete(int id)
        {
             _productTypesService.Delete(id);
        }
    }
}