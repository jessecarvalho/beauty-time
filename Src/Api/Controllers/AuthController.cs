using Application.DTOs.Authentication;
using Application.Interfaces;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;


[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;
    private readonly IRedisService _redisService;

    public AuthController(IAuthService authService, IRedisService redisService)
    {
        _authService = authService;
        _redisService = redisService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> LoginAsync(LoginRequestDto loginRequest)
    {
        var token = await _authService.LoginAsync(loginRequest);

        return Ok(token);
    }
}