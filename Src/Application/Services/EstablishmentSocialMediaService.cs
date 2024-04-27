using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Core.Entities;
using Infrastructure.Interfaces;
using Infrastructure.Repositories;

namespace Application.Services;
public class EstablishmentSocialMediaService : IEstablishmentSocialMediaService
{
    private readonly Mapper _mapper;
    private readonly IEstablishmentSocialMediaRepository _establishmentSocialMediaRepository;

    public EstablishmentSocialMediaService (IEstablishmentSocialMediaRepository establishmentSocialMediaRepository, Mapper mapper)
    {
        _establishmentSocialMediaRepository = establishmentSocialMediaRepository;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<EstablishmentSocialMediaResponseDto>> GetAllAsync()
    {
        var barberShopSocialMedias = await _establishmentSocialMediaRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<EstablishmentSocialMediaResponseDto>>(barberShopSocialMedias);
    }
    
    public async Task<IEnumerable<EstablishmentSocialMediaResponseDto>> GetByIdAsync(int id)
    {
        var barberShopSocialMedia = await _establishmentSocialMediaRepository.GetByIdAsync(id);
        return _mapper.Map<IEnumerable<EstablishmentSocialMediaResponseDto>>(barberShopSocialMedia);
    }
    
    public async Task<EstablishmentSocialMediaResponseDto> AddAsync(EstablishmentSocialMediaRequestDto establishmentSocialMediaRequestDto)
    {
        var barberShopSocialMedia = await _establishmentSocialMediaRepository.AddAsync(_mapper.Map<EstablishmentSocialMedia>(establishmentSocialMediaRequestDto));
        return _mapper.Map<EstablishmentSocialMediaResponseDto>(barberShopSocialMedia);
    }
    
    public async Task<EstablishmentSocialMediaResponseDto> UpdateAsync(int id, EstablishmentSocialMediaRequestDto establishmentSocialMediaRequestDto)
    {
        var barberShopSocialMedia = await _establishmentSocialMediaRepository.UpdateAsync(id, _mapper.Map<EstablishmentSocialMedia>(establishmentSocialMediaRequestDto));
        return _mapper.Map<EstablishmentSocialMediaResponseDto>(barberShopSocialMedia);
    }
    
    public async Task<bool> RemoveAsync(int id)
    {
        return await _establishmentSocialMediaRepository.RemoveAsync(id);
    }
    
}