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
    public class InventoryItemTypeController : ControllerBase
    {
        private IInventoryItemTypeService _inventoryItemTypeService;
        private readonly IMapper _mapper;

        public InventoryItemTypeController(IInventoryItemTypeService inventoryItemTypeService, IMapper mapper)
        {
            _inventoryItemTypeService = inventoryItemTypeService;
            _mapper = mapper;
        }

        //GetAll
        [HttpGet]
        public IActionResult Get()
        {
            var inventoryItemType = _inventoryItemTypeService.GetAll();
            return Ok(inventoryItemType);
        }

        //POST Create Action Method
        [HttpPost("Create")]
        [AllowAnonymous]
        public IActionResult Create([FromBody]InventoryItemTypeDTO inventoryItemTypeDTO)
        {
            InventoryItemType inventoryItemType = new InventoryItemType();
            inventoryItemType.InventoryItemTypeName = inventoryItemTypeDTO.InventoryItemTypeName;
            var inventoryItemTypeEntity = _inventoryItemTypeService.Create(inventoryItemType);
            var inventoryItemCategories = _mapper.Map<InventoryItemTypeDTO>(inventoryItemTypeEntity);
            return Ok(inventoryItemType);
        }

        //POST UPDATE Action Method
        [HttpPost("Update")]
        [AllowAnonymous]
        public IActionResult Update(int id, [FromBody]InventoryItemType inventoryItemType)
        {
            if (ModelState.IsValid)
            {
                inventoryItemType.Id = id;
                //inventoryItemType.UpdatedBy = User.Identity.Name;
                var InventoryItemTypeEntity = _inventoryItemTypeService.Update(inventoryItemType);
                return Ok(InventoryItemTypeEntity);
            }
            return BadRequest();
        }

        //GET Details Action method
        [HttpGet("Details")]
        public IActionResult Details(int id)
        {
            var inventoryItemType = _inventoryItemTypeService.GetById(id);
            if (inventoryItemType == null)
            {
                return NotFound();
            }
            return Ok(inventoryItemType);
        }

        //GET Delete Action method
        [HttpGet("Delete")]
        public void Delete(int id)
        {
            _inventoryItemTypeService.Delete(id);
        }
    }
}