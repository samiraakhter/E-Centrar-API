using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayers.DTOs;
using ServiceLayers.Services;
using ServiceLayers.Model;

namespace SunSD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PriceController : ControllerBase
    {
        private IPriceService _priceService;
        private readonly IMapper _mapper;

        public PriceController(IPriceService priceService, IMapper mapper)
        {
            _priceService = priceService;
            _mapper = mapper;
        }

         //GetAll
        [HttpGet]
        public IActionResult Get()
        {
            var price = _priceService.GetAll();
            return Ok(price);
        }

        //POST Create Action Method
        [HttpPost("Create")]
        [AllowAnonymous]
        public IActionResult Create([FromBody] PriceDTO priceDTO)
        {
            Price price = new Price();
            price.Price1 = priceDTO.Price1;
            price.Count = priceDTO.Count;
            price.IsActive = priceDTO.IsActive;
            
            var priceEntity = _priceService.Create(price);
            var prices = _mapper.Map<PriceDTO>(priceEntity);
            return Ok(price);
        }

        //POST UPDATE Action Method
        [HttpPost("Update")]
        [AllowAnonymous]
        public IActionResult Update(int id, [FromBody]Price price)
        {
            if (ModelState.IsValid)
            {
                price.Id = id;
                //inventoryItemCategory.UpdatedBy = User.Identity.Name;
                var PriceEntity = _priceService.Update(price);
                return Ok(PriceEntity);
            }
            return BadRequest();
        }

        //GET Details Action method
        [HttpGet("Details")]
        public IActionResult Details(int id)
        {
            var price = _priceService.GetById(id);
            if (price == null)
            {
                return NotFound();
            }
            return Ok(price);
        }

        //GET Delete Action method
        [HttpGet("Delete")]
        public void Delete(int id)
        {
            _priceService.Delete(id);
        }
    }
}