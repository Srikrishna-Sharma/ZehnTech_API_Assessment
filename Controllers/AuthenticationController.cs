using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZehnTech_API_Assessment.DTOs;
using ZehnTech_API_Assessment.Interfaces;

namespace ZehnTech_API_Assessment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationManager _authenticationManager;

        public AuthenticationController(IAuthenticationManager authenticationManager )
        {
            _authenticationManager = authenticationManager;
        }
        [HttpPost]
        [Route("authenticate")]
        
        public IActionResult Authenticate([FromBody] Credentials credentials)
        {
            string token = _authenticationManager.Authenticate(credentials.Email, credentials.Password);
            if (string.IsNullOrEmpty(token))
                return Unauthorized("Invalid Credentials");
            else return Ok(token);
        }
    }
}