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
    public class RoleController : ControllerBase
    {
        private IRoleService _roleService;
        private readonly IMapper _mapper;

        public RoleController(IRoleService roleervice, IMapper mapper)
        {
            _roleService = roleervice;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var roles = _roleService.GetAll();
            return Ok(roles);
        }

        //POST Create Action Method
        [HttpPost("Create")]
        [AllowAnonymous]
        public IActionResult Create([FromBody]RoleDTO roleDTO)
        {
            Role role = new Role();
            role.RoleName = roleDTO.RoleName;
            //productType.CreatedBy = User.Identity.Name;
            var roleEntity = _roleService.Create(role);
            var roles = _mapper.Map<RoleDTO>(roleEntity);
           

            return Ok(role);
        }
        //POST UPDATE Action Method
        [HttpPost("Update")]
        [AllowAnonymous]
        public IActionResult Update(int id, [FromBody]Role role)
        {
            if (ModelState.IsValid)
            {
                role.Id = id;
                //productTypes.UpdatedBy = User.Identity.Name;
                role.UpdatedBy = "Admin";
                role.UpdatedDate = DateTime.Now;
                var roleEntity = _roleService.Update(role);
                return Ok(roleEntity);
            }
            return BadRequest();
        }

        //GET Details Action method
        [HttpGet("Details")]
        public IActionResult Details(int id)
        {
            var role = _roleService.GetById(id);
            if (role == null)
            {
                return NotFound();
            }
            return Ok(role);
        }

        //GET Delete Action method
        [HttpGet("Delete")]
        public void Delete(int id)
        {
            _roleService.Delete(id);
        }
    }
}