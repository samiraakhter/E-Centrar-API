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

namespace ECentrarApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductOptionController : ControllerBase
    {
        private IProductOptionService _productoptionService;
        private readonly IMapper _mapper;

        public ProductOptionController(IProductOptionService productoptionService, IMapper mapper)
        {
            _productoptionService = productoptionService;
            _mapper = mapper;
        }

        //GetAll
        [HttpGet]
        public IActionResult Get()
        {
            var productoption = _productoptionService.GetAll();
            return Ok(productoption);
        }

        //POST Create Action Method
        [HttpPost("Create")]
        [AllowAnonymous]
        public IActionResult Create([FromBody] ProductOptionDTO productoptionDTO)
        {
            ProductOption productoption = new ProductOption();
            productoption.Name = productoptionDTO.Name;
            productoption.Option = productoptionDTO.Option;
            productoption.IsActive = productoptionDTO.IsActive;
            var productoptionEntity = _productoptionService.Create(productoption);
            var admins = _mapper.Map<ProductOptionDTO>(productoptionEntity);
            return Ok(productoption);
        }

        //POST UPDATE Action Method
        [HttpPost("Update")]
        [AllowAnonymous]
        public IActionResult Update(int id, [FromBody]ProductOption productoption)
        {
            if (ModelState.IsValid)
            {
                productoption.Id = id;
                //inventoryItemCategory.UpdatedBy = User.Identity.Name;
                var productoptionEntity = _productoptionService.Update(productoption);
                return Ok(productoption);
            }
            return BadRequest();
        }

        //GET Details Action method
        [HttpGet("Details")]
        public IActionResult Details(int id)
        {
            var productoption = _productoptionService.GetById(id);
            if (productoption == null)
            {
                return NotFound();
            }
            return Ok(productoption);
        }

        //GET Delete Action method
        [HttpGet("Delete")]
        public void Delete(int id)
        {
            _productoptionService.Delete(id);
        }

    }
}