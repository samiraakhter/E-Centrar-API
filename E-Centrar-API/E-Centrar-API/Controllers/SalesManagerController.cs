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
    public class SalesManagerController : ControllerBase
    {
        private ISalesManagerService _salesmanagerService;
        private readonly IMapper _mapper;

        public SalesManagerController(ISalesManagerService salesmanagerService, IMapper mapper)
        {
            _salesmanagerService = salesmanagerService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var managers = _salesmanagerService.GetAll();
            return Ok(managers);
        }

        //POST Create Action Method
        [HttpPost("Create")]
        [AllowAnonymous]
        public IActionResult Create([FromBody]SalesManagerDTO salesmanagerDTO)
        {
            SalesManager salesManager = new SalesManager();
            salesManager.FirstName = salesmanagerDTO.FirstName;
            //productType.CreatedBy = User.Identity.Name;
            var managerEntity = _salesmanagerService.Create(salesManager);
            //var sales = _mapper.Map<PurchaseOrderDTO>(managerEntity);


            return Ok(salesManager);
        }
        //POST UPDATE Action Method
        [HttpPost("Update")]
        [AllowAnonymous]
        public IActionResult Update(int id, [FromBody]SalesManager salesManager)
        {
            if (ModelState.IsValid)
            {
                salesManager.Id = id;
                //productTypes.UpdatedBy = User.Identity.Name;
                salesManager.UpdatedBy = "Admin";
                salesManager.UpdatedDate = DateTime.Now;
                var managerEntity = _salesmanagerService.Update(salesManager);
                return Ok(managerEntity);
            }
            return BadRequest();
        }

        //GET Details Action method
        [HttpGet("Details")]
        public IActionResult Details(int id)
        {
            var salesManager = _salesmanagerService.GetById(id);
            if (salesManager == null)
            {
                return NotFound();
            }
            return Ok(salesManager);
        }

        //GET Delete Action method
        [HttpGet("Delete")]
        public void Delete(int id)
        {
            _salesmanagerService.Delete(id);
        }
    }
}
