using Core.Entities;

namespace Infrastructure.Interfaces;

public interface IWorkingDayRepository
{
    public Task<IEnumerable<WorkingDay>?> GetAllAsync();
    public Task<WorkingDay> GetByIdAsync(int id);
    public Task<WorkingDay> AddAsync(WorkingDay workingDay, User user);
    public Task<WorkingDay> UpdateAsync(int id, WorkingDay workingDay, User user);
    public Task<bool> DeleteAsync(int id, User user);
}