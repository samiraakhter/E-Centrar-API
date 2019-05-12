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
    public class InventoryItemController : ControllerBase
    {
        private IInventoryItemService _inventoryItemService;
        private readonly IMapper _mapper;

        public InventoryItemController(IInventoryItemService inventoryItemService, IMapper mapper)
        {
            _inventoryItemService = inventoryItemService;
            _mapper = mapper;
        }

        //GetAll
        [HttpGet]
        public IActionResult Get()
        {
            var inventoryItem = _inventoryItemService.GetAll();
            return Ok(inventoryItem);
        }

        //POST Create Action Method
        [HttpPost("Create")]
        [AllowAnonymous]
        public IActionResult Create([FromBody]InventoryItemDTO inventoryItemDTO)
        {
            InventoryItem inventoryItem = new InventoryItem();
            inventoryItem.InventoryItemName = inventoryItemDTO.InventoryItemName;
            inventoryItem.InventoryItemCategoryFk = inventoryItemDTO.InventoryItemCategoryFk;
            var inventoryItemEntity = _inventoryItemService.Create(inventoryItem);
            var inventoryItems = _mapper.Map<InventoryItemDTO>(inventoryItemEntity);
            return Ok(inventoryItem);
        }

        //POST UPDATE Action Method
        [HttpPost("Update")]
        [AllowAnonymous]
        public IActionResult Update(int id, [FromBody]InventoryItem inventoryItem)
        {
            if (ModelState.IsValid)
            {
                inventoryItem.Id = id;
                //inventoryItemCategory.UpdatedBy = User.Identity.Name;
                var InventoryItemEntity = _inventoryItemService.Update(inventoryItem);
                return Ok(InventoryItemEntity);
            }
            return BadRequest();
        }

        //GET Details Action method
        [HttpGet("Details")]
        public IActionResult Details(int id)
        {
            var inventoryItem = _inventoryItemService.GetById(id);
            if (inventoryItem == null)
            {
                return NotFound();
            }
            return Ok(inventoryItem);
        }

        //GET Delete Action method
        [HttpGet("Delete")]
        public void Delete(int id)
        {
            _inventoryItemService.Delete(id);
        }
    }
}