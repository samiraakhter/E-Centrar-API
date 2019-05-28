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
    public class SalesInvoiceController : ControllerBase
    {
        private ISalesInvoiceService _salesinvoiceService;
        private readonly IMapper _mapper;

        public SalesInvoiceController(ISalesInvoiceService salesinvoiceService, IMapper mapper)
        {
            _salesinvoiceService = salesinvoiceService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var sales = _salesinvoiceService.GetAll();
            return Ok(sales);
        }

        //POST Create Action Method
        [HttpPost("Create")]
        [AllowAnonymous]
        public IActionResult Create([FromBody]SalesInvoiceDTO salesDTO)
        {
            SalesInvoice sales = new SalesInvoice();
            sales.Amount = salesDTO.Amount;
            sales.AmountDue = salesDTO.AmountDue;
            sales.CustomerIdFk = salesDTO.CustomerIdFk;
            sales.CustomerName = salesDTO.CustomerName;
            sales.Discount = salesDTO.Discount;
            sales.IsActive = salesDTO.IsActive;
            sales.ModeOfPayment = salesDTO.ModeOfPayment;
            sales.NotesToCustomer = sales.NotesToCustomer;
            sales.PaymentDate = salesDTO.PaymentDate;
            sales.PaymentTerm = salesDTO.PaymentTerm;
            sales.PO_WOno = salesDTO.PO_WOno;
            sales.Product = salesDTO.Product;
            sales.Quantity = salesDTO.Quantity;
            sales.Rate = salesDTO.Rate;
            sales.Revenue = salesDTO.Revenue;
            sales.SalesInvoiceDate = salesDTO.SalesInvoiceDate;
            sales.SalesInvoiceNo = salesDTO.SalesInvoiceNo;
          //  sales.SalesOrdernoFk = salesDTO.SalesOrdernoFk;
            sales.ShippingAndHandling = salesDTO.ShippingAndHandling;
            sales.SubTotal = salesDTO.SubTotal;
            sales.Tax = salesDTO.Total;
            sales.Total = salesDTO.Total;
           
      

            //productType.CreatedBy = User.Identity.Name;
            var salesEntity = _salesinvoiceService.Create(sales);
            var saleinvoice = _mapper.Map<PurchaseOrderDTO>(salesEntity);


            return Ok(sales);
        }
        //POST UPDATE Action Method
        [HttpPost("Update")]
        [AllowAnonymous]
        public IActionResult Update(int id, [FromBody]SalesInvoice sales)
        {
            if (ModelState.IsValid)
            {
                sales.Id = id;
                //productTypes.UpdatedBy = User.Identity.Name;
                sales.UpdatedBy = "Admin";
                sales.UpdatedDate = DateTime.Now;
                var SalesInvoiceEntity = _salesinvoiceService.Update(sales);
                return Ok(SalesInvoiceEntity);
            }
            return BadRequest();
        }

        //GET Details Action method
        [HttpGet("Details")]
        public IActionResult Details(int id)
        {
            var sales = _salesinvoiceService.GetById(id);
            if (sales == null)
            {
                return NotFound();
            }
            return Ok(sales);
        }

        //GET Delete Action method
        [HttpGet("Delete")]
        public void Delete(int id)
        {
            _salesinvoiceService.Delete(id);
        }
    }
}