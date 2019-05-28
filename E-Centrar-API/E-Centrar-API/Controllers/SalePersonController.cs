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
    public class SalePersonController : ControllerBase
    {
        private ISalesPersonService _salespersonService;
        private readonly IMapper _mapper;

        public SalePersonController(ISalesPersonService salespersonService, IMapper mapper)
        {
            _salespersonService = salespersonService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var salesperson = _salespersonService.GetAll();
            return Ok(salesperson);
        }

        //POST Create Action Method
        [HttpPost("Create")]
        [AllowAnonymous]
        public IActionResult Create([FromBody]SalesPersonDTO salespersonDTO)
        {
            SalesPerson salesperson = new SalesPerson();
            salesperson.FirstName = salespersonDTO.FirstName;
            salesperson.Address = salespersonDTO.Address;
            salesperson.IsActive = salespersonDTO.IsActive;
            salesperson.LastName = salespersonDTO.LastName;
            salesperson.MobileNo = salespersonDTO.MobileNo;
            salesperson.Password = salespersonDTO.PhoneNo;
            salesperson.PhoneNo = salespersonDTO.PhoneNo;
            salesperson.Salary = salespersonDTO.Salary;
            salesperson.UserName = salespersonDTO.UserName;
           
            
            var salepersonEntity = _salespersonService.Create(salesperson);
            var sales = _mapper.Map<SalesPersonDTO>(salepersonEntity);


            return Ok(salesperson);
        }
        //POST UPDATE Action Method
        [HttpPost("Update")]
        [AllowAnonymous]
        public IActionResult Update(int id, [FromBody] SalesPerson saleperson)
        {
            if (ModelState.IsValid)
            {
                saleperson.Id = id;
                //productTypes.UpdatedBy = User.Identity.Name;
                saleperson.UpdatedBy = "Admin";
                saleperson.UpdatedDate = DateTime.Now;
                var salespersonEntity = _salespersonService.Update(saleperson);
                return Ok(salespersonEntity);
            }
            return BadRequest();
        }

        //GET Details Action method
        [HttpGet("Details")]
        public IActionResult Details(int id)
        {
            var salesPerson = _salespersonService.GetById(id);
            if (salesPerson == null)
            {
                return NotFound();
            }
            return Ok(salesPerson);
        }

        //GET Delete Action method
        [HttpGet("Delete")]
        public void Delete(int id)
        {
            _salespersonService.Delete(id);
        }
    }
}
