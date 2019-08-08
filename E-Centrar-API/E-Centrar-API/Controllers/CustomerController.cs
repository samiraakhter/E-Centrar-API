using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceLayers.DTOs;
using ServiceLayers.Model;
using ServiceLayers.Services;

namespace ECentrarApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : Controller
    {
        private ICustomerService _customerService;
        private readonly IMapper _mapper;
        private ApplicationDbContext _db;

        public CustomerController(ICustomerService customerService, IMapper mapper, ApplicationDbContext db)
        {
            _customerService = customerService;
            _mapper = mapper;
            _db = db;
        }

        [HttpGet("GetAll")]
        public IActionResult Get()
        {
            var customer = _customerService.GetAll();
            return Ok(customer);
        }

        [HttpGet]
        [Produces("application/json")]
        public JsonResult Get([DataSourceRequest]DataSourceRequest request)
        {

            var customers = _db.Customer.Include(m => m.Route).Include(m => m.User).ToList();
            return Json(customers.ToDataSourceResult(request));
        }

        //POST Create Action Method
        [HttpPost("Create")]
        
        public IActionResult Create([FromBody]CustomerDTO customerDTO)
        {
            Customer customer = new Customer();
            customer.CustomerId = new Guid();
            customer.FirstName = customerDTO.FirstName;
            customer.LastName = customerDTO.LastName;
            customer.Address = customerDTO.Address;
            customer.MobileNo = customerDTO.MobileNo;
            customer.PaymentMethod = customerDTO.PaymentMethod;
            customer.PhoneNo = customerDTO.PhoneNo;
            customer.IsActive = customerDTO.IsActive;
            customer.FK_SalesManager = customerDTO.FK_SalesManager;
            customer.Email = customerDTO.Email;
            customer.EnterpriseName = customerDTO.EnterpriseName;
            customer.Longitude = customerDTO.Longitude;
            customer.Latitude = customerDTO.Latitude;
            customer.FK_RouteId = customerDTO.FK_RouteId;


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