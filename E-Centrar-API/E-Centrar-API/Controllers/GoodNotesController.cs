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
    public class GoodNotesController : ControllerBase
    {
        private IGoodNotesService _goodnotesService;
        private readonly IMapper _mapper;

        public GoodNotesController(IGoodNotesService goodnotesService, IMapper mapper)
        {
            _goodnotesService = goodnotesService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var goodsNotes = _goodnotesService.GetAll();
            return Ok(goodsNotes);
        }

        //POST Create Action Method
        [HttpPost("Create")]
        [AllowAnonymous]
        public IActionResult Create([FromBody]GoodsNotesDTO goodNotesDTO)
        {
            GoodsNotes goodNotes = new GoodsNotes();
            goodNotes.OrderStatus = goodNotesDTO.OrderStatus;
            goodNotes.DeliverTo = goodNotesDTO.DeliverTo;
            goodNotes.IsActive = goodNotesDTO.IsActive;
            goodNotes.OrderIdFk = goodNotesDTO.OrderIdFk;
            goodNotes.OrderStatus = goodNotesDTO.OrderStatus;
            goodNotes.Packed = goodNotesDTO.Packed;
            goodNotes.Picked = goodNotesDTO.Picked;
            goodNotes.Printed = goodNotesDTO.Printed;
            goodNotes.Shipped = goodNotesDTO.Shipped;
            goodNotes.Warehouse = goodNotesDTO.Warehouse;

            //productType.CreatedBy = User.Identity.Name;
            var goodNotesEntity = _goodnotesService.Create(goodNotes);
            var goodnotes = _mapper.Map<GoodsNotesDTO>(goodNotesEntity);


            return Ok(goodNotes);
        }
        //POST UPDATE Action Method
        [HttpPost("Update")]
        [AllowAnonymous]
        public IActionResult Update(int id, [FromBody]GoodsNotes goodNotes)
        {
            if (ModelState.IsValid)
            {
                goodNotes.Id = id;
                //productTypes.UpdatedBy = User.Identity.Name;
                goodNotes.UpdatedBy = "Admin";
                goodNotes.UpdatedDate = DateTime.Now;
                var goodNotesEntity = _goodnotesService.Update(goodNotes);
                return Ok(goodNotesEntity);
            }
            return BadRequest();
        }

        //GET Details Action method
        [HttpGet("Details")]
        public IActionResult Details(int id)
        {
            var goodNotes = _goodnotesService.GetById(id);
            if (goodNotes == null)
            {
                return NotFound();
            }
            return Ok(goodNotes);
        }

        //GET Delete Action method
        [HttpGet("Delete")]
        public void Delete(int id)
        {
            _goodnotesService.Delete(id);
        }

    }
}