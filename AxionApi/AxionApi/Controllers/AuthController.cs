using Axion.Application;
using AxionApi.Domain.DTOs;
using AxionApi.Domain.Models;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace AxionApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly LoginUser _loginUser;
        private readonly RegisterUser _registerUser;

        public AuthController(LoginUser loginUser, RegisterUser registerUser)
        {
            _loginUser = loginUser;
            _registerUser = registerUser;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegisterDto request)
        {
            var result = await _registerUser.Execute(request);
            if (result != "User registered successfully.")
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDto request)
        {
            var result = await _loginUser.Execute(request);
            if (result == null)
            {
                return BadRequest("Invalid credentials.");
            }
            return Ok(result);
        }
    }

}
