using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        readonly IJwtAuthenticationManager jwtAuthenticationManager;
        public AuthenticationController(IJwtAuthenticationManager jwtAuthenticationManager)
        {
            this.jwtAuthenticationManager = jwtAuthenticationManager;
        }

        [HttpPost]
        [Route("Login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Login(string username, string password)
        {
            var token = jwtAuthenticationManager.Authenticate(username, password);
            if (token == null)
            {
                return Unauthorized("Not permitted to log in");
            }
            return Ok(token);
        }
    }
}
