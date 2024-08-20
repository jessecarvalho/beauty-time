using System.Numerics;
using Core.Entities;

namespace Infrastructure.Interfaces;

public interface IServiceRepository
{
    public Task<IEnumerable<Service>> GetAllAsync(int userId);
    public Task<Service?> GetByIdAsync(int id, int userId);
    public Task<Service?> AddAsync(Service service, int userId);
    public Task<Service?> UpdateAsync(int id, Service service, int userId);
    public Task<bool> RemoveAsync(int id, int userId);
}