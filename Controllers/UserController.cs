using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZehnTech_API_Assessment.DTOs;
using ZehnTech_API_Assessment.Interfaces;
using ZehnTech_API_Assessment.Repositories.Interfaces;
using ZehnTech_API_Assessment.services;

namespace ZehnTech_API_Assessment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IEmailService _emailService;

        public UserController(IUserService userService, IEmailService emailService)
        {
            _userService = userService;
            _emailService = emailService;
        }

        [HttpPost]
        [Route("register")]
        public IActionResult registerUser([FromBody] UserDTO user)
        {
            if (_userService.SaveUser(user))
            {
                _emailService.SendEmail(user.Email);
                return StatusCode(201);
            }
            return StatusCode(500);
        }
        [HttpGet]
        [Authorize]
        [Route("GetUserProfile/{email}")]
        public IActionResult registerUser([FromRoute] string email)
        {
            var user = _userService.GetUserProfile(email);
                return Ok(User);
        }
    }
}