using Application.DTOs;
using Application.Interfaces;
using Application.Services;
using Infrastructure.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/appointment")]
public class AppointmentController : ControllerBase
{
    private readonly IAppointmentServices _appointmentServices;
    
    public AppointmentController(IAppointmentServices appointmentServices)
    {
        _appointmentServices = appointmentServices;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        return Ok(await _appointmentServices.GetAllAsync());
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        try
        {
            return Ok(await _appointmentServices.GetByIdAsync(id));
        } catch (ServiceNotFoundException e)
        {
            return NotFound(e.Message);
        }
        
    }
    
    [HttpPost]
    public async Task<IActionResult> AddAsync(AppointmentRequestDto appointmentRequestDto)
    {
        return Ok(await _appointmentServices.AddAsync(appointmentRequestDto));
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(int id, AppointmentRequestDto appointmentRequestDto)
    {
        try
        {
            return Ok(await _appointmentServices.UpdateAsync(id, appointmentRequestDto));
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
            return Ok(await _appointmentServices.RemoveAsync(id));
        } catch (ServiceNotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
    
}