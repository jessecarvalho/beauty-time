using Application.DTOs;
using Core.Entities;

namespace Application.Interfaces;

public interface IWorkingDayService
{
    public Task<IEnumerable<WorkingDayResponseDto>?> GetAllAsync();
    public Task<WorkingDayResponseDto> GetByIdAsync(int id);
    public Task<WorkingDayResponseDto> CreateAsync(WorkingDayRequestDto workingDay, User user);
    public Task<WorkingDayResponseDto> UpdateAsync(int id, WorkingDayRequestDto workingDay, User user);
    public Task<bool> DeleteAsync(int id, User user);
}