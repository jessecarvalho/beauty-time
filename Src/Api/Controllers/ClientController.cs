using System.Text.Json;
using Application.DTOs;
using Application.Interfaces;
using Core.Interfaces;
using Infrastructure.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("/api/client")]
public class ClientController : ControllerBase
{
    private readonly IClientService _clientService;
    private readonly IRedisService _redisService;
    
    public ClientController(IClientService clientService, IRedisService redisService)
    {
        _clientService = clientService;
        _redisService = redisService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var clientsInCache = await _redisService.GetValueAsync("clients");

        if (clientsInCache is not null)
            return Ok(JsonSerializer.Deserialize<IEnumerable<ClientResponseDto>>(clientsInCache));

        var clients = await _clientService.GetAllAsync();

        await _redisService.SetValueAsync("clients", JsonSerializer.Serialize(clients), TimeSpan.FromMinutes(1));

        return Ok(clients);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        try
        {
            var clientInCache = await _redisService.GetValueAsync($"client-{id}");

            if (clientInCache is not null)
                return Ok(JsonSerializer.Deserialize<ClientResponseDto>(clientInCache));

            var clients = await _clientService.GetByIdAsync(id);

            await _redisService.SetValueAsync($"client-{id}", JsonSerializer.Serialize(clients),
                TimeSpan.FromMinutes(1));

            return Ok(clients);
            
        } catch (ServiceNotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
    
    [HttpPost]
    public async Task<IActionResult> AddAsync(ClientRequestDto clientRequestDto)
    {
        return Ok(await _clientService.AddAsync(clientRequestDto));
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(int id, ClientRequestDto clientRequestDto)
    {
        try
        {
            return Ok(await _clientService.UpdateAsync(id, clientRequestDto));
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
            return Ok(await _clientService.RemoveAsync(id));
        } catch (ServiceNotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
    
    
}