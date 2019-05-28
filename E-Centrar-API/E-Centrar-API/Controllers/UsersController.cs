using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using ServiceLayers.DTOs;
using ServiceLayers.Helpers;
using ServiceLayers.Model;
using ServiceLayers.Services;

namespace ECentrarApi.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    //[Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;
        public UsersController(IUserService userService, IMapper mapper, IOptions<AppSettings> appSettings)
        {
            _userService = userService;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]LoginDTO userParam)
        //public IActionResult Authenticate()
        {
            //LoginDTO userParam = new LoginDTO() { Username = "naveed", Password = "naveed" };
            //var user = _userService.Authenticate(userParam.Username, userParam.Password);

            var user = _userService.Authenticate(userParam.Username, userParam.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(user);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var user = User.Identity.Name;

            var users = _userService.GetAll();
            return Ok(users);
        }
        [AllowAnonymous]
        [HttpPost("Create")]
        public IActionResult Create([FromBody]UserDTO userParam)
        {
            User user = new User();
            user.FirstName = userParam.FirstName;
            user.LastName = userParam.LastName;
            user.Username = userParam.Username;
            var userEntity = _userService.Create(user, userParam.Password);
            var userDto = _mapper.Map<UserDTO>(userEntity);
            return Ok(user);
        }
    }
}