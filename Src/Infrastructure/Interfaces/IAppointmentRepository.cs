using Core.Entities;

namespace Infrastructure.Interfaces;

public interface IAppointmentRepository
{
    public Task<IEnumerable<Appointment>> GetAllAsync ();
    public Task<Appointment?> GetByIdAsync (int id);
    public Task<Appointment> AddAsync (Appointment appointment);
    public Task<Appointment> UpdateAsync (int id, Appointment appointment);
    public Task<bool> RemoveAsync (int id);
}