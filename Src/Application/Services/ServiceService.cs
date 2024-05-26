using System.Numerics;
using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Core.Entities;
using Infrastructure.Interfaces;

namespace Application.Services;

public class ServiceService : IServiceService
{
    private readonly IMapper _mapper;
    private readonly IServiceRepository _serviceRepository;
        
    public ServiceService(IServiceRepository serviceRepository, IMapper mapper)
    {
        _serviceRepository = serviceRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ServiceResponseDto>> GetAllAsync()
    {
        var services = await _serviceRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<ServiceResponseDto>>(services);
    }

    public async Task<ServiceResponseDto> GetByIdAsync(int id)
    {
        var service = await _serviceRepository.GetByIdAsync(id);
        return _mapper.Map<ServiceResponseDto>(service);
    }

    public async Task<ServiceResponseDto> AddAsync(ServiceRequestDto serviceRequestDto)
    {
        var service = await _serviceRepository.AddAsync(_mapper.Map<Service>(serviceRequestDto));
        return _mapper.Map<ServiceResponseDto>(service);
    }

    public async Task<ServiceResponseDto> UpdateAsync(int id, ServiceRequestDto serviceRequestDto)
    {
        var service = await _serviceRepository.UpdateAsync(id, _mapper.Map<Service>(serviceRequestDto));
        return _mapper.Map<ServiceResponseDto>(service);
    }

    public async Task<bool> RemoveAsync(int id)
    {
        return await _serviceRepository.RemoveAsync(id);
    }
}