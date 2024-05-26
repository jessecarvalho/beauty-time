using System.Numerics;

namespace Application.Interfaces;

using Application.DTOs;

public interface IServiceService
{
    Task<IEnumerable<ServiceResponseDto>> GetAllAsync();
    Task<ServiceResponseDto> GetByIdAsync(int id);
    Task<ServiceResponseDto> AddAsync(ServiceRequestDto serviceRequestDto);
    Task<ServiceResponseDto> UpdateAsync(int id, ServiceRequestDto serviceRequestDto);
    Task<bool> RemoveAsync(int id);
}