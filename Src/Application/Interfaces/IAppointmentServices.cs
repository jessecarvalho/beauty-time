using Application.DTOs;

namespace Application.Interfaces;

public interface IAppointmentServices
{
    Task<IEnumerable<AppointmentResponseDto>> GetAllAsync();
    Task<IEnumerable<AppointmentResponseDto>> GetByIdAsync(int id);
    Task<AppointmentResponseDto> AddAsync(AppointmentRequestDto appointmentRequestDto);
    Task<AppointmentResponseDto> UpdateAsync(int id, AppointmentRequestDto appointmentRequestDto);
    Task<bool> RemoveAsync(int id);
}