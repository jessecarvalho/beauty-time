using System.Text.Json;
using Application.DTOs;
using Application.Interfaces;
using Application.Services;
using Core.Interfaces;
using Infrastructure.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/appointment")]
public class AppointmentController : ControllerBase
{
    private readonly IAppointmentService _appointmentService;
    private readonly IRedisService _redisService;
    
    public AppointmentController(IAppointmentService appointmentService, IRedisService redisService)
    {
        _appointmentService = appointmentService;
        _redisService = redisService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var appointmentsInCache = await _redisService.GetValueAsync("clients");

        if (appointmentsInCache is not null)
            return Ok(JsonSerializer.Deserialize<IEnumerable<AppointmentResponseDto>>(appointmentsInCache));

        var appointment = await _appointmentService.GetAllAsync();
        
        await _redisService.SetValueAsync("clients", JsonSerializer.Serialize(appointment), TimeSpan.FromMinutes(1));

        return Ok(appointment);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        try
        {
            var appointmentInCache = await _redisService.GetValueAsync($"appointment-{id}");

            if (appointmentInCache is not null)
                return Ok(JsonSerializer.Deserialize<AppointmentResponseDto>(appointmentInCache));

            var appointment = await _appointmentService.GetByIdAsync(id);

            await _redisService.SetValueAsync($"appointment-{id}", JsonSerializer.Serialize(appointmentInCache),
                TimeSpan.FromMinutes(1));
            
            return Ok(appointment);
        } catch (ServiceNotFoundException e)
        {
            return NotFound(e.Message);
        }
        
    }
    
    [HttpPost]
    public async Task<IActionResult> AddAsync(AppointmentRequestDto appointmentRequestDto)
    {
        return Ok(await _appointmentService.AddAsync(appointmentRequestDto));
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(int id, AppointmentRequestDto appointmentRequestDto)
    {
        try
        {
            return Ok(await _appointmentService.UpdateAsync(id, appointmentRequestDto));
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
            return Ok(await _appointmentService.RemoveAsync(id));
        } catch (ServiceNotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
    
}