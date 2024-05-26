using System.Text.Json;
using Application.DTOs;
using Application.Interfaces;
using Core.Interfaces;
using Infrastructure.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/establishment")]
public class EstablishmentController : ControllerBase
{
    private readonly IEstablishmentService _establishmentService;
    private readonly IRedisService _redisService;
    
    public EstablishmentController(IEstablishmentService establishmentService, IRedisService redisService)
    {
        _establishmentService = establishmentService;
        _redisService = redisService;
    }
    
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
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        try
        {
            return Ok(await _establishmentService.GetByIdAsync(id));
        } catch (ServiceNotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
    
    [HttpPost]
    public async Task<IActionResult> AddAsync(EstablishmentRequestDto establishmentRequestDto)
    {
        return Ok(await _establishmentService.AddAsync(establishmentRequestDto));
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(int id, EstablishmentRequestDto establishmentRequestDto)
    {
        try
        {
            return Ok(await _establishmentService.UpdateAsync(id, establishmentRequestDto));
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
            return Ok(await _establishmentService.RemoveAsync(id));
        } catch (ServiceNotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
}