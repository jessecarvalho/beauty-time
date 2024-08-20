using System.Numerics;
using System.Text.Json;
using Application.DTOs;
using Application.Interfaces;
using Core.Interfaces;
using Infrastructure.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("/api/services")]
public class ServiceController : ControllerBase
{
    private readonly IServiceService _serviceService;
    private readonly IRedisService _redisService;
    private readonly IAuthService _authService;
    
    public ServiceController(IServiceService serviceService, IRedisService redisService, IAuthService authService)
    {
        _serviceService = serviceService;
        _redisService = redisService;
        _authService = authService;
    }
    
    [Authorize]
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var user = await _authService.GetUserFromRequestAsync(HttpContext.Request);
        var servicesInCache = await _redisService.GetValueAsync("services");
        
        if (servicesInCache is not null)
        {
            return Ok(JsonSerializer.Deserialize<List<ServiceResponseDto>>(servicesInCache));
        }
        
        var services = await _serviceService.GetAllAsync(user.Id);
        
        await _redisService.SetValueAsync("services", JsonSerializer.Serialize(services), TimeSpan.FromMinutes(1));
        
        return Ok(services);
    }
    
    [Authorize]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        var user = await _authService.GetUserFromRequestAsync(HttpContext.Request);
        var serviceInCache = await _redisService.GetValueAsync($"service-{id}");
        
        if (serviceInCache is not null)
        {
            return Ok(JsonSerializer.Deserialize<ServiceResponseDto>(serviceInCache));
        }
        
        try
        {
            var service = await _serviceService.GetByIdAsync(id, user.Id);
            
            await _redisService.SetValueAsync($"service-{id}", JsonSerializer.Serialize(service), TimeSpan.FromMinutes(1));
            
            return Ok(service);
        } catch (ServiceNotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
    
    [Authorize]
    [HttpPost]
    public async Task<IActionResult> AddAsync(ServiceRequestDto serviceRequestDto)
    {
        var user = await _authService.GetUserFromRequestAsync(HttpContext.Request);
        try
        {
            return Ok(await _serviceService.AddAsync(serviceRequestDto, user.Id));
        } catch (ServiceAlreadyExistsException e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(int id, ServiceRequestDto serviceRequestDto)
    {
        var user = await _authService.GetUserFromRequestAsync(HttpContext.Request);

        try
        {
            return Ok(await _serviceService.UpdateAsync(id, serviceRequestDto, user.Id));
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
            return Ok(await _serviceService.RemoveAsync(id, user.Id));
        } catch (ServiceNotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
    
}