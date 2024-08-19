using System.Numerics;
using Application.DTOs;
using Application.DTOs.User;

namespace Application.Interfaces;

public interface IEstablishmentService
{
    Task<IEnumerable<EstablishmentResponseDto>> GetAllAsync();
    Task<EstablishmentResponseDto> GetByIdAsync(int id);
    Task<List<UserResponseDto>> GetClientsByEstablishmentIdAsync(int id);
    Task<EstablishmentResponseDto> AddAsync(EstablishmentRequestDto establishmentRequestDto, int userId);
    Task<EstablishmentResponseDto> UpdateAsync(int id, EstablishmentRequestDto establishmentRequestDto, int userId);
    Task<bool> RemoveAsync(int id, int userId);
}