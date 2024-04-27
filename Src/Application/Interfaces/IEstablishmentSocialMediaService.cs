using Application.DTOs;

namespace Application.Interfaces;

public interface IEstablishmentSocialMediaService
{
    Task<IEnumerable<EstablishmentSocialMediaResponseDto>> GetAllAsync();
    Task<IEnumerable<EstablishmentSocialMediaResponseDto>> GetByIdAsync(int id);
    Task<EstablishmentSocialMediaResponseDto> AddAsync(EstablishmentSocialMediaRequestDto establishmentSocialMediaRequestDto);
    Task<EstablishmentSocialMediaResponseDto> UpdateAsync(int id, EstablishmentSocialMediaRequestDto establishmentSocialMediaRequestDto);
    Task<bool> RemoveAsync(int id);
}