using Application.DTOs;
using Application.Interfaces;
using Infrastructure.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/establishment/working-days")]
public class WorkingDayController : ControllerBase
{
    private readonly IWorkingDayService _workingDayService;
    private readonly IAuthService _authService;

    public WorkingDayController(IWorkingDayService workingDayService, IAuthService authService)
    {
        _workingDayService = workingDayService;
        _authService = authService;
    }
    
    [Authorize]
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var workingDays = await _workingDayService.GetAllAsync();
        
        return Ok(workingDays);
    }
    
    [Authorize]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        try
        {
            var workingDay = await _workingDayService.GetByIdAsync(id);
            
            return Ok(workingDay);
        }
        catch (WorkingDayNotFoundException)
        {
            return NotFound();
        }
    }
    
    [Authorize]
    [HttpPost]
    public async Task<IActionResult> AddAsync([FromBody] WorkingDayRequestDto workingDay)
    {
        var user = await _authService.GetUserFromRequestAsync(HttpContext.Request);
        try 
        {
            return Ok(await _workingDayService.CreateAsync(workingDay, user));
        }
        catch (WorkingDayNotFoundException)
        {
            return NotFound();
        }
    }
    
    [Authorize]
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(int id, [FromBody] WorkingDayRequestDto workingDay)
    {
        var user = await _authService.GetUserFromRequestAsync(HttpContext.Request);
        try
        {
            return Ok(await _workingDayService.UpdateAsync(id, workingDay, user));
        }
        catch (WorkingDayNotFoundException)
        {
            return NotFound();
        }
    }
    
    [Authorize]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var user = await _authService.GetUserFromRequestAsync(HttpContext.Request);
        try
        {
            return Ok(await _workingDayService.DeleteAsync(id, user));
        }
        catch (WorkingDayNotFoundException)
        {
            return NotFound();
        }
    }
    
}