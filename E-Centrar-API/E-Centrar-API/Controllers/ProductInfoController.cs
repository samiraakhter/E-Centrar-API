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
    public class ProductInfoController : ControllerBase
    {
        private IProductInfoService _productinfoService;
        private readonly IMapper _mapper;

        public ProductInfoController(IProductInfoService productinfoService, IMapper mapper)
        {
            _productinfoService = productinfoService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var productinfo = _productinfoService.GetAll();
            return Ok(productinfo);
        }

        //POST Create Action Method
        [HttpPost("Create")]
        [AllowAnonymous]
        public IActionResult Create([FromBody]ProductInfoDTO productinfoDTO)
        {
            ProductInfo productinfo = new ProductInfo();
            productinfo.ProductName = productinfoDTO.ProductName;
            //productType.CreatedBy = User.Identity.Name;
            var productinfoEntity = _productinfoService.Create(productinfo);
            var productinfos = _mapper.Map<ProductInfoDTO>(productinfoEntity);


            return Ok(productinfo);
        }

        [HttpPost("Update")]
        [AllowAnonymous]
        public IActionResult Update(int id, [FromBody]ProductInfo productinfos)
        {
            if (ModelState.IsValid)
            {
                productinfos.Id = id;
                //productTypes.UpdatedBy = User.Identity.Name;
                productinfos.UpdatedBy = "Admin";
                productinfos.UpdatedDate = DateTime.Now;
                var ProductinfoEntity = _productinfoService.Update(productinfos);
                return Ok(ProductinfoEntity);
            }
            return BadRequest();
        }

        //GET Details Action method
        [HttpGet("Details")]
        public IActionResult Details(int id)
        {
            var productinfo = _productinfoService.GetById(id);
            if (productinfo == null)
            {
                return NotFound();
            }
            return Ok(productinfo);
        }

        //GET Delete Action method
        [HttpGet("Delete")]
        public void Delete(int id)
        {
            _productinfoService.Delete(id);
        }
    }
}