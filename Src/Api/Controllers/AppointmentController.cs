using Application.DTOs;
using Application.Interfaces;
using Infrastructure.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/appointment")]
public class AppointmentController : ControllerBase
{
    private readonly IAppointmentService _appointmentService;
    private readonly IAuthService _authService;

    public AppointmentController(IAppointmentService appointmentService, IAuthService authService)
    {
        _appointmentService = appointmentService;
        _authService = authService;
    }
    
    [Authorize]
    [HttpGet()]
    [ProducesResponseType(typeof(IEnumerable<AppointmentResponseDto>), 200)]
    public async Task<IActionResult> GetAllByClientIdAsync()
    {
        var user = await _authService.GetUserFromRequestAsync(HttpContext.Request);
        var cacheKey = $"clients-{user.Id}";

        var appointments = await _appointmentService.GetAllAsync(user.Id, cacheKey);

        return Ok(appointments);
    }
    
    [Authorize]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        var user = await _authService.GetUserFromRequestAsync(HttpContext.Request);
        var cacheKey = $"clients-{user.Id}-appointments-{id}";

        try
        {
            var appointment = await _appointmentService.GetByIdAsync(user.Id, id, cacheKey);
            return Ok(appointment);
        } catch (ServiceNotFoundException e)
        {
            return NotFound(e.Message);
        }
        
    }
    
    [Authorize]
    [HttpPost]
    public async Task<IActionResult> AddAsync(AppointmentRequestDto appointmentRequestDto)
    {
        var user = await _authService.GetUserFromRequestAsync(HttpContext.Request);
        var cacheKey = $"clients-{user.Id}";

        return Ok(await _appointmentService.AddAsync(user.Id, appointmentRequestDto, cacheKey));
    }
    
    [Authorize]
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(int id, AppointmentRequestDto appointmentRequestDto)
    {
        var user = await _authService.GetUserFromRequestAsync(HttpContext.Request);
        var cacheKey = $"clients-{user.Id}";

        try
        {
            return Ok(await _appointmentService.UpdateAsync(user.Id, id, appointmentRequestDto, cacheKey));
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
            return Ok(await _appointmentService.RemoveAsync(user.Id, id));
        } catch (ServiceNotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
    
}