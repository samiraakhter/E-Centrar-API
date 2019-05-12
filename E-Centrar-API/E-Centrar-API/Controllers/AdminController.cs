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
    public class AdminController : ControllerBase
    {
        private IAdminService _adminService;
        private readonly IMapper _mapper;

        public AdminController(IAdminService adminService, IMapper mapper)
        {
            _adminService = adminService;
            _mapper = mapper;
        }

        //GetAll
        [HttpGet]
        public IActionResult Get()
        {
            var admin = _adminService.GetAll();
            return Ok(admin);
        }

        //POST Create Action Method
        [HttpPost("Create")]
        [AllowAnonymous]
        public IActionResult Create([FromBody] AdminDTO adminDTO)
        {
            Admin admin = new Admin();
            admin.AdminName = adminDTO.AdminName;
            var adminEntity = _adminService.Create(admin);
            var admins = _mapper.Map<AdminDTO>(adminEntity);
            return Ok(admin);
        }

        //POST UPDATE Action Method
        [HttpPost("Update")]
        [AllowAnonymous]
        public IActionResult Update(int id, [FromBody]Admin admin)
        {
            if (ModelState.IsValid)
            {
                admin.Id = id;
                //inventoryItemCategory.UpdatedBy = User.Identity.Name;
                var AdminEntity = _adminService.Update(admin);
                return Ok(AdminEntity);
            }
            return BadRequest();
        }

        //GET Details Action method
        [HttpGet("Details")]
        public IActionResult Details(int id)
        {
            var admin = _adminService.GetById(id);
            if (admin == null)
            {
                return NotFound();
            }
            return Ok(admin);
        }

        //GET Delete Action method
        [HttpGet("Delete")]
        public void Delete(int id)
        {
            _adminService.Delete(id);
        }

    }
}