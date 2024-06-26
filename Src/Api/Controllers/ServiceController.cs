using System.Numerics;
using System.Text.Json;
using Application.DTOs;
using Application.Interfaces;
using Core.Interfaces;
using Infrastructure.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("/api/services")]
public class ServiceController : ControllerBase
{
    private readonly IServiceService _serviceService;
    private readonly IRedisService _redisService;
    
    public ServiceController(IServiceService serviceService, IRedisService redisService)
    {
        _serviceService = serviceService;
        _redisService = redisService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {

        var servicesInCache = await _redisService.GetValueAsync("services");
        
        if (servicesInCache is not null)
        {
            return Ok(JsonSerializer.Deserialize<List<ServiceResponseDto>>(servicesInCache));
        }
        
        var services = await _serviceService.GetAllAsync();
        
        await _redisService.SetValueAsync("services", JsonSerializer.Serialize(services), TimeSpan.FromMinutes(1));
        
        return Ok(services);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        var serviceInCache = await _redisService.GetValueAsync($"service-{id}");
        
        if (serviceInCache is not null)
        {
            return Ok(JsonSerializer.Deserialize<ServiceResponseDto>(serviceInCache));
        }
        
        try
        {
            var service = await _serviceService.GetByIdAsync(id);
            
            await _redisService.SetValueAsync($"service-{id}", JsonSerializer.Serialize(service), TimeSpan.FromMinutes(1));
            
            return Ok(service);
        } catch (ServiceNotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
    
    [HttpPost]
    public async Task<IActionResult> AddAsync(ServiceRequestDto serviceRequestDto)
    {
        return Ok(await _serviceService.AddAsync(serviceRequestDto));
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(int id, ServiceRequestDto serviceRequestDto)
    {
        try
        {
            return Ok(await _serviceService.UpdateAsync(id, serviceRequestDto));
        } catch (ServiceNotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoveAsync(int id)
    {
        try
        {
            return Ok(await _serviceService.RemoveAsync(id));
        } catch (ServiceNotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
    
}