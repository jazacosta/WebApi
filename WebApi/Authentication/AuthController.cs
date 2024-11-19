using Core.DTOs;
using Core.Interfaces.Services;
using Core.Models;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers;

namespace WebApi.Auth
{
    public class AuthController : BaseApiController
    {
        private readonly IAuthService _authservice;

        public AuthController(IAuthService authService)
        {
            _authservice = authService; //your
        }

        [HttpGet("api/generate-token")]
        public IActionResult GenerateToken() //AuthService authService, [FromBody] User user 
        {
            var user = new User
            {
                Id = 1,
                UserName = "Jaz",
                Roles = new List<string> { "admin", "security" }
            };
            var token = _authservice.GenerateToken(user);
            //return Ok(_authService.GenerateToken(user));
            //var token = _tokenService.GenerateToken(userDTO.UserName, userDTO.Role);
            return Ok(new { token });
        }

        //private string GenerateToken1()
        //{
        //    return "fixed-token-example";

        //}
        [HttpGet("api/protected-endpoint")]
        [Authorize]
        public IActionResult ProtectedEp()
        {
            return Ok("This endpoint requires a valid JWT");
        }
        [HttpGet("api/protected-endpoint-security")]
        [Authorize(Roles = "admin")]
        public IActionResult AdminOnly()
        {
            return Ok("This endpoint can be seen only by admin users");
        }
        [HttpGet("api/protected-endpoint-admin")]
        [Authorize(Roles = "security")]
        public IActionResult SecurityOnly()
        {
            return Ok("This endpoint can be seen only by security users");
        }
        [HttpGet("api/protected-endpoint-both")]
        [Authorize(Roles = "admin,security")]
        public IActionResult AdminSecurity()
        {
            return Ok("This endpoint can be seen only by either admin users, security users or both");
        }
    }
}
