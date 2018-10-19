using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Models;
using ServiceLayer.Services;

namespace SunSD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        
        [HttpGet]
        [Route("GetAdmins")]
        public async Task<IActionResult> GetAdmin()
        {
            var admins = await _adminService.GetAdmins();
            if (admins == null)
            {
                return BadRequest();
            }

            return Ok(admins);
        }

        [HttpGet]
        [Route("GetAdmin")]
        public async Task<IActionResult> GetAdmin(Guid? adminId)
        {
            if (adminId == null)
            {
                return NotFound();
            }

            var admin = await _adminService.GetAdmin(adminId);
            if (admin == null)
            {
                return BadRequest();
            }

            return Ok(admin);
        }

        [HttpPost]
        [Route("AddAdmin")]
        public async Task<IActionResult> AddAdmin([FromBody]Admin model)
        {
            if (ModelState.IsValid)
            {
                var adminId = await _adminService.AddAdmin(model);
                if (adminId != null)
                {
                    return Ok(adminId);
                }
                else
                {
                    return BadRequest();
                }
            }

            return BadRequest();
        }

        [HttpPost]
        [Route("DeleteAdmin")]
        public async Task<IActionResult> DeleteAdmin(Guid? adminId)
        {
            if (adminId == null)
            {
                return NotFound();
            }

            await _adminService.DeleteAdmin(adminId);

            return Ok();
        }

        [HttpPost]
        [Route("UpdateAdmin")]
        public async Task<IActionResult> UpdateAdmin([FromBody]Admin model)
        {
            if (ModelState.IsValid)
            {
                await _adminService.UpdateAdmin(model);
                return Ok();
            }

            return BadRequest();
        }
    }
}