using Azure;
using Library.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using Library.BLL.DTO;

namespace Library.WebApi.Controllers
{
    public class AuthController:Controller
    {
        IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService= authService;
        }
        
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDTO model)
        {
            if (!ModelState.IsValid) 
                return BadRequest(ModelState);
            string token;
            try
            {
                token = await _authService.AddUser(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(token);
        }
    }
}
