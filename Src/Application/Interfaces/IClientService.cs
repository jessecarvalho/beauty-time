using Application.DTOs;

namespace Application.Interfaces;

public interface IClientService
{
    Task<IEnumerable<ClientResponseDto>> GetAllAsync();
    Task<IEnumerable<ClientResponseDto>> GetByIdAsync(int id);
    Task<ClientResponseDto> AddAsync(ClientRequestDto clientRequestDto);
    Task<ClientResponseDto> UpdateAsync(int id, ClientRequestDto clientRequestDto);
    Task<bool> RemoveAsync(int id);
}