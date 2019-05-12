using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayers.DTOs;
using ServiceLayers.Services;
using ServiceLayers.Model;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;

namespace SunSD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartViewModelController : ControllerBase
    {
        private IShoppingCartViewModelService _shoppingcartService;
        private readonly IMapper _mapper;

        public ShoppingCartViewModelController(IShoppingCartViewModelService shoppingcartService, IMapper mapper)
        {
            _shoppingcartService = shoppingcartService;
            _mapper = mapper;
        }

        //GetAll
        [HttpGet]
        public IActionResult Get()
        {
            var shopping = _shoppingcartService.GetAll();
            return Ok(shopping);
        }

        //POST Create Action Method
        [HttpPost("Create")]
        [AllowAnonymous]
        public IActionResult Create([FromBody] ShoppingCartViewModelDTO shoppingDTO)
        {
            ShoppingCartViewModel shopping = new ShoppingCartViewModel();
            shopping.ProductList = shoppingDTO.ProductList;
            var shoppingEntity = _shoppingcartService.Create(shopping);
            var shoppings = _mapper.Map<ShoppingCartViewModelDTO>(shoppingEntity);
            return Ok(shopping);
        }

        //POST UPDATE Action Method
        [HttpPost("Update")]
        [AllowAnonymous]
        public IActionResult Update(int id, [FromBody]ShoppingCartViewModel shoppingCartViewModel)
        {
            if (ModelState.IsValid)
            {
                shoppingCartViewModel.Id = id;
                //inventoryItemCategory.UpdatedBy = User.Identity.Name;
                var shoppingEntity = _shoppingcartService.Update(shoppingCartViewModel);
                return Ok(shoppingEntity);
            }
            return BadRequest();
        }

        //GET Details Action method
        [HttpGet("Details")]
        public IActionResult Details(int id)
        {
            var shopping = _shoppingcartService.GetById(id);
            if (shopping == null)
            {
                return NotFound();
            }
            return Ok(shopping);
        }

        //GET Delete Action method
        [HttpGet("Delete")]
        public void Delete(int id)
        {
            _shoppingcartService.Delete(id);
        }
    }
}