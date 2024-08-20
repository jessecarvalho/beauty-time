
namespace Application.Interfaces;

using Application.DTOs;

public interface IServiceService
{
    Task<IEnumerable<ServiceResponseDto>> GetAllAsync(int userId);
    Task<ServiceResponseDto> GetByIdAsync(int id, int userId);
    Task<ServiceResponseDto> AddAsync(ServiceRequestDto serviceRequestDto, int userId);
    Task<ServiceResponseDto> UpdateAsync(int id, ServiceRequestDto serviceRequestDto, int userId);
    Task<bool> RemoveAsync(int id, int userId);
}