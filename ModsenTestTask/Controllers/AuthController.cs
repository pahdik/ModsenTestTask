using Azure;
using Library.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;

namespace Library.WebApi.Controllers
{
    public class AuthController:Controller
    {
        IAuthService authService;
        public AuthController(IAuthService _authService)
        {
            authService= _authService;
        }
        [HttpGet("/token")]
        public async Task<IActionResult> Token()
        {
             var token=authService.GetToken();
            
            return Ok(new
                        {
                            access_token = token
                        });
        }
    }
}
