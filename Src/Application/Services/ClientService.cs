using System.Collections;
using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Core.Entities;
using Infrastructure.Interfaces;
using Infrastructure.Repositories;

namespace Application.Services;

public class ClientService : IClientService
{
    private readonly Mapper _mapper;
    private readonly IClientRepository _clientRepository;

    public ClientService (IClientRepository clientRepository, Mapper mapper)
    {
        _clientRepository = clientRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ClientResponseDto>> GetAllAsync()
    {
        var clients = await _clientRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<ClientResponseDto>>(clients);
    }

    public async Task<IEnumerable<ClientResponseDto>> GetByIdAsync(int id)
    {
        var client = await _clientRepository.GetByIdAsync(id);
        return _mapper.Map<IEnumerable<ClientResponseDto>>(client);
    }

    public async Task<ClientResponseDto> AddAsync(ClientRequestDto clientRequestDto)
    {
        var client = await _clientRepository.AddAsync(_mapper.Map<Client>(clientRequestDto));
        return _mapper.Map<ClientResponseDto>(client);
    }

    public async Task<ClientResponseDto> UpdateAsync(int id, ClientRequestDto clientRequestDto)
    {
        var client = await _clientRepository.UpdateAsync(id, _mapper.Map<Client>(clientRequestDto));
        return _mapper.Map<ClientResponseDto>(client);
    }
    
    public async Task<bool> RemoveAsync(int id)
    {
        return await _clientRepository.RemoveAsync(id);
    }
}