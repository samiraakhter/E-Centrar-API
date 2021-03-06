﻿using System;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayers.DTOs;
using ServiceLayers.Model;
using ServiceLayers.Services;
using Microsoft.AspNetCore.Hosting.Internal;
using System.IO;
using ServiceLayers.Utility;
using ServiceLayers;
using ServiceLayers.Model.ViewModel;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace SunSD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private IProductService _productService;
        [BindProperty]
        public ProductViewModel ProductsVM { get; set; }
        private readonly IMapper _mapper;
        private readonly HostingEnvironment _hostingEnvironment;
        private ApplicationDbContext _db;

        public ProductController(IProductService productService, IMapper mapper, HostingEnvironment hostingEnvironment, ApplicationDbContext db)
        {
            _productService = productService;
            _mapper = mapper;
            _hostingEnvironment = hostingEnvironment;
            _db = db;
        }

        //GetAll
        [HttpGet("GetAll")]
        public IActionResult Get()
        {
            var products = _productService.GetAll();
            return Ok(products);
        }

        [HttpGet]
        [Produces("application/json")]
        public JsonResult Get([DataSourceRequest]DataSourceRequest request)
        {

            var products = _db.Product.Include(m => m.ProductCategory).Include(m => m.ProductType).ToList();
            return Json(products.ToDataSourceResult(request));
        }
        [HttpGet("Users")]
        [Produces("application/json")]
        public JsonResult GetUser([DataSourceRequest]DataSourceRequest request)
        {

            var users = _db.User.Include(m => m.Role).ToList();
            return Json(users.ToDataSourceResult(request));
        }

        //POST Action Method for picture
        [HttpPost("Temp")]
        [Produces("application/json")]
        public string Temp(IFormFile file)
        {
            try
            {
                string path = "";
                string pic = "";
                string webRootPath = _hostingEnvironment.WebRootPath;
                var uploads = Path.Combine(webRootPath, SD.ImageFolder);
                //if (Directory.Exists(webRootPath))
                //{
                //    var files = Directory.EnumerateFiles(uploads);
                //    foreach (var item in files)
                //    {
                //        if (System.IO.File.Exists(item))
                //        {
                //            System.IO.File.Delete(item);
                //        }
                //    }
                //}
                if (file != null)
                {
                    pic = Path.GetFileName(file.FileName);
                    path = Path.Combine(uploads, pic);
                    // file is uploaded
                    using (var filestream = new FileStream(Path.Combine(uploads, pic), FileMode.Create))
                    {
                        file.CopyTo(filestream);
                    }
                }
                return @"\" + SD.ImageFolder + @"\" + pic;
            }
            catch (Exception ex)
            {

                Logger.Fatal(ex.Message);
                Logger.Fatal(ex.Source);
                Logger.Fatal(ex.TargetSite.Name);
                Logger.Fatal(ex.StackTrace);
                if (ex.InnerException != null)
                {
                    Logger.Fatal(ex.InnerException.Message);
                    Logger.Fatal(ex.InnerException.Source);
                    Logger.Fatal(ex.InnerException.TargetSite.Name);
                    Logger.Fatal(ex.InnerException.StackTrace);
                }
                return "";
            }
        }

        //POST Create Action Method
        [HttpPost("Create")]
        public IActionResult Create( [FromBody]ProductDTO productDTO)
        {
            Product product = new Product();
            product.ProductName = productDTO.ProductName;
            //productType.CreatedBy = User.Identity.Name;
            product.Fullfilled = productDTO.Fullfilled;
            product.Instock = productDTO.Instock;
            product.IsActive = productDTO.IsActive;
            product.OnHand = productDTO.OnHand;
            product.ProductCategoryIdFk = productDTO.ProductCategoryIdFk;
            product.ProductImage = productDTO.ProductImage;
            product.ProductTypeIdFk = productDTO.ProductTypeIdFk;
            product.Sku = productDTO.Sku;
            product.Variants = productDTO.Variants;

            var productEntity = _productService.Create(product);
            var products = _mapper.Map<ProductDTO>(productEntity);
            return Ok(product);
           
        }

        //POST UPDATE Action Method
        [HttpPost("Update")]
        [AllowAnonymous]
        public IActionResult Update(int id, [FromBody]Product products)
        {
            if (ModelState.IsValid)
            {
                products.Id = id;
                //productTypes.UpdatedBy = User.Identity.Name;
                products.UpdatedBy = "Admin";
                products.UpdatedDate = DateTime.Now;
                var ProductEntity = _productService.Update(products);
                return Ok(ProductEntity);
            }
            return BadRequest();
        }

        //GET Details Action method
        [HttpGet("Details")]
        public IActionResult Details(int id)
        {
            var product = _productService.GetById(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        //POST UPDATE Action Method
        [HttpPost("UpdateStock")]
        [AllowAnonymous]
        public IActionResult UpdateStock(int id, int Instocks)
        {
            var product = _productService.GetById(id);
            product.Instock = Instocks;
            if (ModelState.IsValid)
            {
              //  products.Id = id;
                //productTypes.UpdatedBy = User.Identity.Name;
               
                var ProductEntity = _productService.UpdateStock(product);
                return Ok();
            }
            return BadRequest();
        }

        //GET Delete Action method
        [HttpDelete("Delete")]
        public void Delete(int id)
        {
            _productService.Delete(id);
        }
    }
}