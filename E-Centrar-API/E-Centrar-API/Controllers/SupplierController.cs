using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using ServiceLayers.DTOs;
using ServiceLayers.Services;
using ServiceLayers.Model;

namespace ECentrarApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private ISupplierService _supplierService;
        private readonly IMapper _mapper;

        public SupplierController(ISupplierService supplierService, IMapper mapper)
        {
            _supplierService = supplierService;
            _mapper = mapper;
        }

        //GetAll
        [HttpGet]
        public IActionResult Get()
        {
            var supplier = _supplierService.GetAll();
            return Ok(supplier);
        }

        //POST Create Action Method
        [HttpPost("Create")]
        [AllowAnonymous]
        public IActionResult Create([FromBody] SupplierDTO supplierDTO)
        {
            Supplier supplier = new Supplier();
            supplier.Suppliername = supplierDTO.Suppliername;
            var supplierEntity = _supplierService.Create(supplier);
            var suppliers = _mapper.Map<SupplierDTO>(supplierEntity);
            return Ok(supplier);
        }

        //POST UPDATE Action Method
        [HttpPost("Update")]
        [AllowAnonymous]
        public IActionResult Update(int id, [FromBody]Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                supplier.Id = id;
                //inventoryItemCategory.UpdatedBy = User.Identity.Name;
                var supplierEntity = _supplierService.Update(supplier);
                return Ok(supplierEntity);
            }
            return BadRequest();
        }

        //GET Details Action method
        [HttpGet("Details")]
        public IActionResult Details(int id)
        {
            var supplier = _supplierService.GetById(id);
            if (supplier == null)
            {
                return NotFound();
            }
            return Ok(supplier);
        }

        //GET Delete Action method
        [HttpGet("Delete")]
        public void Delete(int id)
        {
            _supplierService.Delete(id);
        }
    }
}