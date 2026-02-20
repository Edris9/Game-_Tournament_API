using Game__Tournament_API.Dtos;
using Game__Tournament_API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Game__Tournament_API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _service;

    public AuthController(IAuthService service)
    {
        _service = service;
    }

    [HttpPost("register")]
    public async Task<ActionResult<AuthResponseDTO>> Register(RegisterDTO dto)
    {
        var result = await _service.RegisterAsync(dto);
        if (result == null) return BadRequest("Email already exists");
        return Ok(result);
    }

    [HttpPost("login")]
    public async Task<ActionResult<AuthResponseDTO>> Login(LoginDTO dto)
    {
        var result = await _service.LoginAsync(dto);
        if (result == null) return Unauthorized("Invalid email or password");
        return Ok(result);
    }
}