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
using Kendo.Mvc.UI;
using Microsoft.EntityFrameworkCore;
using Kendo.Mvc.Extensions;

namespace ECentrarApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : Controller
    {
        private IInventoryService _inventoryService;
        private readonly IMapper _mapper;
        private ApplicationDbContext _db;


        public InventoryController(IInventoryService inventoryService, IMapper mapper, ApplicationDbContext db)
        {
            _inventoryService = inventoryService;
            _mapper = mapper;
            _db = db;
        }

        //GetAll
        [HttpGet("GetAll")]
        public IActionResult Get()
        {
            var inventory = _inventoryService.GetAll();
            return Ok(inventory);
        }

        [HttpGet]
        [Produces("application/json")]
        public JsonResult Get([DataSourceRequest]DataSourceRequest request)
        {

            var inventories = _db.Inventory.Include(m => m.Product).ToList();
            return Json(inventories.ToDataSourceResult(request));
        }

        //POST Create Action Method
        [HttpPost("Create")]
        [AllowAnonymous]
        public IActionResult Create([FromBody]InventoryDTO inventoryDTO)
        {
            Inventory inventory = new Inventory();
            inventory.Amount = inventoryDTO.Amount;
            inventory.DefaultLocation = inventoryDTO.DefaultLocation;
            inventory.ProductFk = inventoryDTO.ProductFk;
            //inventory.InventoryItemFk = inventoryDTO.InventoryItemFk;
            //inventory.InventoryItemTypeFk = inventoryDTO.InventoryItemTypeFk;
            inventory.IsActive = inventoryDTO.IsActive;
            inventory.MinimumStockLevel = inventoryDTO.MinimumStockLevel;
            inventory.ReorderQuantity = inventoryDTO.ReorderQuantity;
            inventory.Unit = inventoryDTO.Unit;
            var inventoryEntity = _inventoryService.Create(inventory);
            var inventorys = _mapper.Map<InventoryDTO>(inventoryEntity);
            return Ok(inventory);
        }

        //POST UPDATE Action Method
        [HttpPost("Update")]
        [AllowAnonymous]
        public IActionResult Update(int id, [FromBody]Inventory inventory)
        {
            if (ModelState.IsValid)
            {
                inventory.Id = id;
                //inventoryItemCategory.UpdatedBy = User.Identity.Name;
                var InventoryEntity = _inventoryService.Update(inventory);
                return Ok(InventoryEntity);
            }
            return BadRequest();
        }

        //GET Details Action method
        [HttpGet("Details")]
        public IActionResult Details(int id)
        {
            var inventory = _inventoryService.GetById(id);
            if (inventory == null)
            {
                return NotFound();
            }
            return Ok(inventory);
        }

        //GET Delete Action method
        [HttpDelete("Delete")]
        public void Delete(int id)
        {
            _inventoryService.Delete(id);
        }
    }
}