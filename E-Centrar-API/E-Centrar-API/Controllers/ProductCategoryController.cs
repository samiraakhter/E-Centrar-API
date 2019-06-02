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
using ServiceLayers.DTOs;
using ServiceLayers.Model;
using ServiceLayers.Services;

namespace ECentrarApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoryController : ControllerBase
    {

        private IProductCategoryService _productCategoryService;
        private readonly IMapper _mapper;


        public ProductCategoryController(IProductCategoryService productCategoryService, IMapper mapper)
        {
            _productCategoryService = productCategoryService;
            _mapper = mapper;

        }

        [HttpGet]
        public IActionResult Get()
        {
            var productCategory = _productCategoryService.GetAll();
            return Ok(productCategory);
        }

       // [HttpGet]
       // [Produces("application/json")]
       //public JsonResult Get([DataSourceRequest]DataSourceRequest request)
       // {
       //     var productCategory = _productCategoryService.GetAll(
       // }

        //POST Create Action Method
        [HttpPost("Create")]
        [AllowAnonymous]
        public IActionResult Create([FromBody]ProductCategoryDTO productCategoryDTO)
        {
            ProductCategory productCategory = new ProductCategory();
            productCategory.ProductCategoryName = productCategoryDTO.ProductCategoryName;
            //productCategory.CreatedBy = User.Identity.Name;
            productCategory.CreatedBy = "Admin";
            productCategory.CreatedDate = DateTime.Now;
            var productCategoryEntity = _productCategoryService.Create(productCategory);
            var productCategories = _mapper.Map<ProductCategoryDTO>(productCategoryEntity);
            return Ok(productCategory);
        }

        //POST UPDATE Action Method
        [HttpPost("Update")]
        [AllowAnonymous]
        public IActionResult Update(int id, [FromBody]ProductCategory productCategory)
        {
            if (ModelState.IsValid)
            {
                productCategory.Id = id;
                //productCategory.UpdatedBy = User.Identity.Name;
                productCategory.UpdatedBy = "Admin";
                productCategory.UpdatedDate = DateTime.Now;
                var ProductCategoryEntity = _productCategoryService.Update(productCategory);
                return Ok(ProductCategoryEntity);
            }
            return BadRequest();
        }

        //GET Details Action method
        [HttpGet("Details")]
        public IActionResult Details(int id)
        {
            var productCategory = _productCategoryService.GetById(id);
            if (productCategory == null)
            {
                return NotFound();
            }
            return Ok(productCategory);
        }

        //GET Delete Action method
        [HttpGet("Delete")]
        public void Delete(int id)
        {
            _productCategoryService.Delete(id);
        }
    }
}