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
    [HttpGet("client")]
    [ProducesResponseType(typeof(IEnumerable<AppointmentResponseDto>), 200)]
    public async Task<IActionResult> GetAllByClientIdAsync()
    {
        var user = await _authService.GetUserFromRequestAsync(HttpContext.Request);
        var cacheKey = $"appointment-clients-{user.Id}";
        
        try
        {
            var appointments = await _appointmentService.GetAllAsync(user.Id, cacheKey);

            return Ok(appointments);
        }
        catch (ArgumentException e)
        {
            return BadRequest(e.Message);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
        
    }
    
    [Authorize]
    [HttpGet("establishment")]
    [ProducesResponseType(typeof(IEnumerable<AppointmentResponseDto>), 200)]
    public async Task<IActionResult> GetAllByEstablishmentIdAsync()
    {
        var user = await _authService.GetUserFromRequestAsync(HttpContext.Request);
        var cacheKey = $"appointment-establishment-{user.Id}";
        
        try
        {
            var appointments = await _appointmentService.GetAllAsync(user.Id, cacheKey);

            return Ok(appointments);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
    
    [Authorize]
    [HttpGet("client/{id}")]
    [ProducesResponseType(typeof(AppointmentResponseDto), 200)]
    public async Task<IActionResult> GetAppointmentByIdAndClientIdAsync(int id)
    {
        var user = await _authService.GetUserFromRequestAsync(HttpContext.Request);
        var cacheKey = $"client-{user.Id}-appointments-{id}";

        try
        {
            var appointment = await _appointmentService.GetByIdAsync(user.Id, id, cacheKey);
            return Ok(appointment);
        } 
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
        
    }
    
    [Authorize]
    [HttpPost("client")]
    [ProducesResponseType(typeof(AppointmentResponseDto), 200)]
    public async Task<IActionResult> AddAppointmentByClientIdAsync(AppointmentRequestDto appointmentRequestDto)
    {
        var user = await _authService.GetUserFromRequestAsync(HttpContext.Request);
        var cacheKey = $"appointment-{user.Id}";
        
        try
        {
            return Ok(await _appointmentService.AddAsync(user.Id, appointmentRequestDto, cacheKey));
        } catch (UnauthorizedAccessException e)
        {
            return Unauthorized(e.Message);
        } catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
        
    }
    
    
    [Authorize]
    [HttpPut("{id}")]
    [ProducesResponseType(typeof(AppointmentResponseDto), 200)]
    public async Task<IActionResult> UpdateAppointmentByIdAsync(int id, AppointmentRequestDto appointmentRequestDto)
    {
        var user = await _authService.GetUserFromRequestAsync(HttpContext.Request);
        var cacheKey = $"clients-{user.Id}";

        try
        {
            return Ok(await _appointmentService.UpdateAsync(user.Id, id, appointmentRequestDto, cacheKey));
        } catch (AppointmentNotFoundException e)
        {
            return NotFound(e.Message);
        } catch (UnauthorizedAccessException e)
        {
            return Unauthorized(e.Message);
        } catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
    
    [Authorize]
    [HttpDelete("establishment/{id}")]
    [ProducesResponseType(typeof(bool), 200)]
    public async Task<IActionResult> RemoveAppointmentByClientIdAsync(int id)
    {
        var user = await _authService.GetUserFromRequestAsync(HttpContext.Request);

        try
        {
            return Ok(await _appointmentService.RemoveAsync(id, user.Id ));
        } catch (ServiceNotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
    
    [Authorize]
    [HttpDelete("client/{id}")]
    [ProducesResponseType(typeof(bool), 200)]
    public async Task<IActionResult> RemoveAppointmentByEstablishmentAsync(int id)
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