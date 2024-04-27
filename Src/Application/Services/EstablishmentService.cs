using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Core.Entities;
using Infrastructure.Interfaces;
using Infrastructure.Repositories;

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
        var barberShops = await _establishmentRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<EstablishmentResponseDto>>(barberShops);
    }

    public async Task<IEnumerable<EstablishmentResponseDto>> GetByIdAsync(int id)
    {
        var barberShop = await _establishmentRepository.GetByIdAsync(id);
        return _mapper.Map<IEnumerable<EstablishmentResponseDto>>(barberShop);
    }
    
    public async Task<EstablishmentResponseDto> AddAsync(EstablishmentRequestDto establishmentRequestDto)
    {
        var barberShop = await _establishmentRepository.AddAsync(_mapper.Map<Establishment>(establishmentRequestDto));
        return _mapper.Map<EstablishmentResponseDto>(barberShop);
    }
    
    public async Task<EstablishmentResponseDto> UpdateAsync(int id, EstablishmentRequestDto establishmentRequestDto)
    {
        var barberShop = await _establishmentRepository.UpdateAsync(id, _mapper.Map<Establishment>(establishmentRequestDto));
        return _mapper.Map<EstablishmentResponseDto>(barberShop);
    }
    
    public async Task<bool> RemoveAsync(int id)
    {
        return await _establishmentRepository.RemoveAsync(id);
    }
}