using Core.Entities;

namespace Infrastructure.Interfaces;

public interface IServiceRepository
{
    public Task<IEnumerable<Service>> GetAllAsync();
    public Task<Service?> GetByIdAsync(int id);
    public Task<Service?> AddAsync(Service service);
    public Task<Service?> UpdateAsync(int id, Service service);
    public Task<bool> RemoveAsync(int id);
}