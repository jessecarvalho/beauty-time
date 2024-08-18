using System.Text.Json;
using Application.DTOs.User;
using Application.Interfaces;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/users")]
public class UserController : ControllerBase
{
    private readonly IUserServices _userServices;
    private readonly IRedisService _redisService;
    private readonly IAuthService _authService;
    
    public UserController(IUserServices userServices, IRedisService redisService, IAuthService authService)
    {
        _userServices = userServices;
        _redisService = redisService;
        _authService = authService;
    }
    
    [Authorize]
    [HttpGet]
    public async Task<IActionResult> GetAllUsersAsync()
    {
        
        var usersInCache = await _redisService.GetValueAsync("users");
        
        if (usersInCache is not null)
            return Ok(JsonSerializer.Deserialize<List<User>>(usersInCache));
        
        var users = await _userServices.GetAllUsersAsync();
        
        await _redisService.SetValueAsync("users", JsonSerializer.Serialize(users), TimeSpan.FromMinutes(1));
        
        return Ok(users);
    }
    
    [Authorize]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserByIdAsync(int id)
    {
        var userInCache = await _redisService.GetValueAsync($"user-{id}");

        if (userInCache is not null)
            return Ok(JsonSerializer.Deserialize<User>(userInCache));

        try
        {
            var user = await _userServices.GetUserByIdAsync(id);

            await _redisService.SetValueAsync("$user-{id}", JsonSerializer.Serialize(user), TimeSpan.FromMinutes(1));

            return Ok(user);
        }
        catch (UserNotFoundException e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> AddUserAsync(UserRequestDto user)
    {
        try
        {
            var newUser = await _userServices.AddUserAsync(user);
            return Ok(newUser);

        }
        catch (EmailAlreadyExistsException e)
        {
            return BadRequest(e.Message);
        }
        

    }
    
    [Authorize]
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUserAsync(int id, UserRequestDto user)
    {
        var loggedUser = _authService.GetUserFromRequestAsync(HttpContext.Request);
        
        try
        {
            var updatedUser = await _userServices.UpdateUserAsync(id, user, loggedUser.Id);
            return Ok(updatedUser);
        }
        catch (EmailAlreadyExistsException e)
        {
            return BadRequest(e.Message);
        }
    }

    [Authorize]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUserAsync(int id)
    {
        return Ok(await _userServices.DeleteUserAsync(id));
    }
}