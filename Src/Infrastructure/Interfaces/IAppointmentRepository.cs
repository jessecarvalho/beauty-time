using Core.Entities;

namespace Infrastructure.Interfaces;

public interface IAppointmentRepository
{
    public Task<IEnumerable<Appointment>> GetAllAsync (int userId);
    public Task<Appointment?> GetByIdAsync (int userId, int id);
    public Task<Appointment> AddAsync (int userId, Appointment appointment);
    public Task<Appointment> UpdateAsync (int id, int userId, Appointment appointment);
    public Task<bool> RemoveAsync (int id, int userId);
}