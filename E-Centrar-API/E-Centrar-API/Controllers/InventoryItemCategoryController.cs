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
    public class InventoryItemCategoryController : ControllerBase
    {
        private IInventoryItemCategoryService _inventoryItemCategoryService;
        private readonly IMapper _mapper;

        public InventoryItemCategoryController(IInventoryItemCategoryService inventoryItemCategoryService, IMapper mapper)
        {
            _inventoryItemCategoryService = inventoryItemCategoryService;
            _mapper = mapper;
        }

        //GetAll
        [HttpGet]
        public IActionResult Get()
        {
            var inventoryItemCategory = _inventoryItemCategoryService.GetAll();
            return Ok(inventoryItemCategory);
        }

        //POST Create Action Method
        [HttpPost("Create")]
        [AllowAnonymous]
        public IActionResult Create([FromBody]InventoryItemCategoryDTO inventoryItemCategoryDTO)
        {
            InventoryItemCategory inventoryItemCategory = new InventoryItemCategory();
            inventoryItemCategory.InventoryItemCategoryName = inventoryItemCategoryDTO.InventoryItemCategoryName;
            var inventoryItemCategoryEntity = _inventoryItemCategoryService.Create(inventoryItemCategory);
            var inventoryItemCategories = _mapper.Map<InventoryItemCategoryDTO>(inventoryItemCategoryEntity);
            return Ok(inventoryItemCategory);
        }

        //POST UPDATE Action Method
        [HttpPost("Update")]
        [AllowAnonymous]
        public IActionResult Update(int id, [FromBody]InventoryItemCategory inventoryItemCategory)
        {
            if (ModelState.IsValid)
            {
                inventoryItemCategory.Id = id;
                //inventoryItemCategory.UpdatedBy = User.Identity.Name;
                var InventoryItemCategoryEntity = _inventoryItemCategoryService.Update(inventoryItemCategory);
                return Ok(InventoryItemCategoryEntity);
            }
            return BadRequest();
        }

        //GET Details Action method
        [HttpGet("Details")]
        public IActionResult Details(int id)
        {
            var inventoryItemCategory = _inventoryItemCategoryService.GetById(id);
            if (inventoryItemCategory == null)
            {
                return NotFound();
            }
            return Ok(inventoryItemCategory);
        }

        //GET Delete Action method
        [HttpGet("Delete")]
        public void Delete(int id)
        {
            _inventoryItemCategoryService.Delete(id);
        }
    }
}