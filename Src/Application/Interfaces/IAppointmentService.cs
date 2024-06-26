using Application.DTOs;
using Core.Entities;

namespace Application.Interfaces;

public interface IAppointmentService
{
    Task<IEnumerable<AppointmentResponseDto>> GetAllAsync(int userId, string cacheKey);
    Task<IEnumerable<AppointmentResponseDto>> GetByIdAsync(int userId, int id, string cacheKey);
    Task<AppointmentResponseDto> AddAsync(int userId, AppointmentRequestDto appointmentRequestDto, string cacheKey);
    Task<AppointmentResponseDto> UpdateAsync(int userId, int id, AppointmentRequestDto appointmentRequestDto, string cacheKey);
    Task<bool> RemoveAsync(int userId, int id);
}