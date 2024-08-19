using System.Numerics;
using Application.DTOs;
using Application.DTOs.User;
using Application.Interfaces;
using AutoMapper;
using Core.Entities;
using Infrastructure.Interfaces;

namespace Application.Services;

public class EstablishmentService : IEstablishmentService
{
    private readonly IMapper _mapper;
    private readonly IEstablishmentRepository _establishmentRepository;
    
    public EstablishmentService (IEstablishmentRepository establishmentRepository, IMapper mapper)
    {
        _establishmentRepository = establishmentRepository;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<EstablishmentResponseDto>> GetAllAsync()
    {
        var establishments = await _establishmentRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<EstablishmentResponseDto>>(establishments);
    }

    public async Task<EstablishmentResponseDto> GetByIdAsync(int id)
    {
        var establishment = await _establishmentRepository.GetByIdAsync(id);
        return _mapper.Map<EstablishmentResponseDto>(establishment);
    }
    
    public async Task<List<UserResponseDto>> GetClientsByEstablishmentIdAsync(int id)
    {
        var establishment = await _establishmentRepository.GetClientsByEstablishmentIdAsync(id);
        return _mapper.Map<List<UserResponseDto>>(establishment);
    }
    
    public async Task<EstablishmentResponseDto> AddAsync(EstablishmentRequestDto establishmentRequestDto, int userId)
    {
        var newEstablishment = _mapper.Map<Establishment>(establishmentRequestDto);
        newEstablishment.UserId = userId;
        var barberShop = await _establishmentRepository.AddAsync(newEstablishment);
        return _mapper.Map<EstablishmentResponseDto>(barberShop);
    }
    
    public async Task<EstablishmentResponseDto> UpdateAsync(int id, EstablishmentRequestDto establishmentRequestDto, int userId)
    {
        var establishmentToUpdate = _mapper.Map<Establishment>(establishmentRequestDto);
        establishmentToUpdate.UserId = userId;
        var updatedEstablishment = await _establishmentRepository.UpdateAsync(id, establishmentToUpdate);
        return _mapper.Map<EstablishmentResponseDto>(updatedEstablishment);
    }
    
    public async Task<bool> RemoveAsync(int id, int userId)
    {
        return await _establishmentRepository.RemoveAsync(id, userId);
    }
}