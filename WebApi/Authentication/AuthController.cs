using Core.DTOs;
using Core.Interfaces.Services;
using Core.Models;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebApi.Controllers;

namespace WebApi.Auth
{
    public class AuthController : BaseApiController
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService; 
        }

        [HttpPost("api/generate-token")]
        public IActionResult GenerateToken([FromBody] User user) //AuthService authService, [FromBody] User user 
        {
            //var user = new User
            //{
            //    Id = 1,
            //    UserName = "Jaz",
            //    Roles = new List<string> { "admin", "security" }
            //};
            //var token = _authservice.
            //    CreateToken(user);
            return Ok(_authService.CreateToken(user));
            //return Ok(new { token });
        }

        //private string GenerateToken1()
        //{
        //    return "fixed-token-example";

        //}
        [HttpPost("api/protected-endpoint")]
        //[Authorize]
        public IActionResult ProtectedEp([FromBody] string token)
        {
            if (!_authService.ValidateJwt(token))
                return Unauthorized("This endpoint requires a valid JWT");

            return Ok(_authService.ValidateJwt(token));
        }

        [Authorize(Roles = "admin")]
        [HttpGet("api/protected-endpoint-admin")]
        public IActionResult AdminOnly()
        {
            var user = HttpContext.User;
            var roles = user.Claims.Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value);
            return Ok($"This endpoint can be seen only by {string.Join(", ", roles)} users");
        }

        [Authorize(Roles = "security")]
        [HttpGet("api/protected-endpoint-security")]
        public IActionResult SecurityOnly()
        {
            var user = HttpContext.User;
            var roles = user.Claims.Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value);
            return Ok($"This endpoint can be seen only by {roles} users");
        }

        [Authorize(Roles = "admin, security")]
        [HttpGet("api/protected-endpoint-both")]
        public IActionResult AdminSecurity()
        {
            var user = HttpContext.User;
            var roles = user.Claims.Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value);
            return Ok($"This endpoint can be seen only by {string.Join(", ", roles)} users");
        }
    }
}
