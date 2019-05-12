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
    public class PurchaseInvoiceController : ControllerBase
    {
        private IPurchaseInvoiceService _purchaseService;
        private readonly IMapper _mapper;

        public PurchaseInvoiceController(IPurchaseInvoiceService purchaseService, IMapper mapper)
        {
            _purchaseService = purchaseService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var purchaseInvoices = _purchaseService.GetAll();
            return Ok(purchaseInvoices);
        }

        //POST Create Action Method
        [HttpPost("Create")]
        [AllowAnonymous]
        public IActionResult Create([FromBody]PurchaseInvoiceDTO purchaseDTO)
        {
            PurchaseInvoice purchaseInvoice = new PurchaseInvoice();
            purchaseInvoice.Balance = purchaseDTO.Balance;
            //productType.CreatedBy = User.Identity.Name;
            purchaseInvoice.DueDate = purchaseDTO.DueDate;
            purchaseInvoice.InvoiceDate = purchaseDTO.InvoiceDate;
            purchaseInvoice.IsActive = purchaseDTO.IsActive;
            purchaseInvoice.PaidAmount = purchaseDTO.PaidAmount;
            purchaseInvoice.PaymentDate = purchaseDTO.PaymentDate;
            purchaseInvoice.PurchaseInvoiceNo = purchaseDTO.PurchaseInvoiceNo;
            purchaseInvoice.Revenue = purchaseDTO.Revenue;
            purchaseInvoice.Status = purchaseDTO.Status;
            purchaseInvoice.SupplierIdFk = purchaseDTO.SupplierIdFk;
            purchaseInvoice.Total = purchaseDTO.Total;
            
            var purchaseEntity = _purchaseService.Create(purchaseInvoice);
            var purchase = _mapper.Map<PurchaseInvoiceDTO>(purchaseEntity);


            return Ok(purchaseInvoice);
        }
        //POST UPDATE Action Method
        [HttpPost("Update")]
        [AllowAnonymous]
        public IActionResult Update(int id, [FromBody]PurchaseInvoice purchaseInvoice)
        {
            if (ModelState.IsValid)
            {
                purchaseInvoice.Id = id;
                //productTypes.UpdatedBy = User.Identity.Name;
                purchaseInvoice.UpdatedBy = "Admin";
                purchaseInvoice.UpdatedDate = DateTime.Now;
                var PurchaseEntity = _purchaseService.Update(purchaseInvoice);
                return Ok(PurchaseEntity);
            }
            return BadRequest();
        }

        //GET Details Action method
        [HttpGet("Details")]
        public IActionResult Details(int id)
        {
            var purchase = _purchaseService.GetById(id);
            if (purchase == null)
            {
                return NotFound();
            }
            return Ok(purchase);
        }

        //GET Delete Action method
        [HttpGet("Delete")]
        public void Delete(int id)
        {
            _purchaseService.Delete(id);
        }
    }
}