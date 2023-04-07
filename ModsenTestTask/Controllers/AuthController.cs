using Library.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
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
            var responseModel = await _authService.AddUserAsync(model);
            if (responseModel.StatusCode == 404)
                return NotFound(responseModel.Message);

            return Ok(responseModel.Token);
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO model)
        {
            var responseModel = await _authService.SignInAsync(model);
            if(responseModel.StatusCode==404)
                return NotFound(responseModel.Message);

            return Ok(responseModel.Token);
        }
    }
}
