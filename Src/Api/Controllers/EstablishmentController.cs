using System.Text.Json;
using Application.DTOs;
using Application.Interfaces;
using Core.Interfaces;
using Infrastructure.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/establishment")]
public class EstablishmentController : ControllerBase
{
    private readonly IEstablishmentService _establishmentService;
    private readonly IRedisService _redisService;
    private readonly IAuthService _authService;
    
    public EstablishmentController(IEstablishmentService establishmentService, IRedisService redisService, IAuthService authService)
    {
        _establishmentService = establishmentService;
        _redisService = redisService;
        _authService = authService;
    }
    
    [Authorize]
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var establishmentsInCache = await _redisService.GetValueAsync("establishments");
        
        if (establishmentsInCache is not null)
        {
            return Ok(JsonSerializer.Deserialize<List<EstablishmentResponseDto>>(establishmentsInCache));
        }
        
        var establishments = await _establishmentService.GetAllAsync();
        
        await _redisService.SetValueAsync("establishments", JsonSerializer.Serialize(establishments), TimeSpan.FromMinutes(1));
        
        return Ok(establishments);
    }
    
    [Authorize]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        
        var establishmentInCache = await _redisService.GetValueAsync($"establishment-{id}");
        
        if (establishmentInCache is not null)
        {
            return Ok(JsonSerializer.Deserialize<EstablishmentResponseDto>(establishmentInCache));
        }
        
        try
        {
            var establishment = await _establishmentService.GetByIdAsync(id);
            await _redisService.SetValueAsync($"establishment-{id}", JsonSerializer.Serialize(establishment), TimeSpan.FromMinutes(1));
            return Ok(establishment);
        } catch (ServiceNotFoundException e)
        {
            await _redisService.SetValueAsync($"establishment-{id}", "null", TimeSpan.FromMinutes(1));
            return NotFound(e.Message);
        }
    }
    
    [Authorize]
    [HttpGet]
    public async Task<IActionResult> GetEstablishmentClientsAsync()
    {
        var user = await _authService.GetUserFromRequestAsync(HttpContext.Request);
        var users = await _establishmentService.GetClientsByEstablishmentIdAsync(user.Id);
        return Ok(users);
    }
    
    [Authorize]
    [HttpPost]
    public async Task<IActionResult> AddAsync(EstablishmentRequestDto establishmentRequestDto)
    {
        var user = await _authService.GetUserFromRequestAsync(HttpContext.Request);
        try
        {
            return Ok(await _establishmentService.AddAsync(establishmentRequestDto, user.Id));
        }  catch (EstablishmentAlreadyExistsException e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [Authorize]
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(int id, EstablishmentRequestDto establishmentRequestDto)
    {
        var user = await _authService.GetUserFromRequestAsync(HttpContext.Request);

        try
        {
            return Ok(await _establishmentService.UpdateAsync(id, establishmentRequestDto, user.Id));
        } catch (ServiceNotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
    
    [Authorize]
    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoveAsync(int id)
    {
        var user = await _authService.GetUserFromRequestAsync(HttpContext.Request);

        try
        {
            return Ok(await _establishmentService.RemoveAsync(id, user.Id));
        } catch (ServiceNotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
}