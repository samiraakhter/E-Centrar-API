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
    public class CustomerController : ControllerBase
    {
        private ICustomerService _customerService;
        private readonly IMapper _mapper;

        public CustomerController(ICustomerService customerService, IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var customer = _customerService.GetAll();
            return Ok(customer);
        }

        //POST Create Action Method
        [HttpPost("Create")]
        [AllowAnonymous]
        public IActionResult Create([FromBody] CustomerDTO customerDTO)
        {
            Customer customer = new Customer();
            customer.FirstName = customerDTO.FirstName;
            customer.LastName = customerDTO.LastName;
            customer.MobileNo = customerDTO.MobileNo;
            customer.PaymentMethod = customerDTO.PaymentMethod;
            customer.PhoneNo = customerDTO.PhoneNo;
            customer.FK_SalesManager = customerDTO.FK_SalesManager;
            customer.Email = customerDTO.Email;
            customer.EnterpriseName = customerDTO.EnterpriseName;
            

            //productType.CreatedBy = User.Identity.Name;
            var customerEntity = _customerService.Create(customer);
            var customers = _mapper.Map<CustomerDTO>(customerEntity);


            return Ok(customer);
        }
        //POST UPDATE Action Method
        [HttpPost("Update")]
        [AllowAnonymous]
        public IActionResult Update(int id, [FromBody]Customer customer)
        {
            if (ModelState.IsValid)
            {
                customer.Id = id;
                //productTypes.UpdatedBy = User.Identity.Name;
               
                var customerEntity = _customerService.Update(customer);
                return Ok(customerEntity);
            }
            return BadRequest();
        }

        //GET Details Action method
        [HttpGet("Details")]
        public IActionResult Details(int id)
        {
            var customer = _customerService.GetById(id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        //GET Delete Action method
        [HttpGet("Delete")]
        public void Delete(int id)
        {
            _customerService.Delete(id);
        }
    }
}