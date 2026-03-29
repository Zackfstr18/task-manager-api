using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TaskManagerAPI.Models.DTOs;
using TaskManagerAPI.Models.DTOs.Auth;
using TaskManagerAPI.Models.Responses;
using TaskManagerAPI.Services;

namespace TaskManagerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController: ControllerBase
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            var user = await _authService.RegisterAsync(dto);

            if (user == null)
            {
                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = "El usuario ya existe"
                });
            }

            return Ok(new ApiResponse<object>
            {
                Success = true,
                Message = "Usuario registrado correctamente"
            });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var token = await _authService.LoginAsync(dto);

            if (token == null)
            {
                return Unauthorized(new ApiResponse<object>
                {
                    Success = false,
                    Message = "Credenciales inválidas"
                });
            }

            return Ok(new ApiResponse<object>
            {
                Success = true,
                Message = "Login exitoso",
                Data = new { Token = token }
            });
        }

        [Authorize]
        [HttpGet("me")]
        public IActionResult GetCurrentUser()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var username = User.Identity?.Name;

            return Ok(new ApiResponse<object>
            {
                Success = true,
                Message = "Usuario autenticado",
                Data = new
                {
                    Id = userId,
                    Username = username
                }
            });
        }
    }
}
