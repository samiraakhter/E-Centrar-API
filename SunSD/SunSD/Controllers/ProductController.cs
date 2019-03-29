using System;
using System.Collections.Generic;
using System.Web;
using System.Threading.Tasks;
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
using Microsoft.Extensions.Logging;
using ServiceLayers;
using ServiceLayers.Model.ViewModel;
using System.Linq;

namespace SunSD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
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

        [HttpGet]
        public IActionResult Get()
        {
            var product = _productService.GetAll();
            return Ok(product);
        }

        //POST Create Action Method
        [HttpPost("Create")]
        public IActionResult Create( [FromBody]ProductDTO productDTO)
        {
            Product product = new Product();
            product.ProductName = productDTO.ProductName;
            //productDTO.ProductTypeIdFk = _db.ProductType.Id.Where(x => x.ProductTypeName == productDTO.productTypeName);
            //productType.CreatedBy = User.Identity.Name;
            //Image being save
            //string webRootPath = _hostingEnvironment.WebRootPath;
            //var files = HttpContext.Request.Form.Files;
            //var productFromDb = _db.Product.Find(ProductsVM.Products.Id);

            //if (files.Count != 0)
            //{
            //    //Image has been uploaded
            //    var uploads = Path.Combine(webRootPath, SD.ImageFolder);
            //    var extension = Path.GetExtension(files[0].FileName);
            //    using (var filestream = new FileStream(Path.Combine(uploads, ProductsVM.Products.Id + extension), FileMode.Create))
            //    {
            //        files[0].CopyTo(filestream);
            //    }
            //    productFromDb.ProductImage = @"\" + SD.ImageFolder + @"\" + ProductsVM.Products.Id + extension;
            //}
            //else
            //{
            //    var uploads = Path.Combine(webRootPath, SD.ImageFolder + @"\" + SD.DefaultProductImage);
            //    System.IO.File.Copy(uploads, webRootPath + @"\" + SD.ImageFolder + @"\" + ProductsVM.Products.Id + ".png");
            //    productFromDb.ProductImage = @"\" + SD.ImageFolder + @"\" + ProductsVM.Products.Id + ".png";
            //}
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

        //GET Delete Action method
        [HttpGet("Delete")]
        public void Delete(int id)
        {
            _productService.Delete(id);
        }
    }
}