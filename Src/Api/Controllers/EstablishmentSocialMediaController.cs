using Application.DTOs;
using Application.Interfaces;
using Infrastructure.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("/api/establishment/social-media")]
public class EstablishmentSocialMediaController : ControllerBase
{
    private readonly IEstablishmentSocialMediaService _establishmentSocialMediaService;
    
    public EstablishmentSocialMediaController(IEstablishmentSocialMediaService establishmentSocialMediaService)
    {
        _establishmentSocialMediaService = establishmentSocialMediaService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        return Ok(await _establishmentSocialMediaService.GetAllAsync());
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        try
        {
            return Ok(await _establishmentSocialMediaService.GetByIdAsync(id));
        } catch (ServiceNotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
    
    [HttpPost]
    public async Task<IActionResult> AddAsync(EstablishmentSocialMediaRequestDto establishmentSocialMediaRequestDto)
    {
        try
        {
            return Ok(await _establishmentSocialMediaService.AddAsync(establishmentSocialMediaRequestDto));
        } catch (ServiceNotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(int id, EstablishmentSocialMediaRequestDto establishmentSocialMediaRequestDto)
    {
        try
        {
            return Ok(await _establishmentSocialMediaService.UpdateAsync(id, establishmentSocialMediaRequestDto));
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
            return Ok(await _establishmentSocialMediaService.RemoveAsync(id));
        } catch (ServiceNotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
}