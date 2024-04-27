using Core.Entities;

namespace Infrastructure.Interfaces;

public interface IClientRepository
{
    public Task<IEnumerable<Client>> GetAllAsync();
    public Task<Client?> GetByIdAsync(int id);
    public Task<Client?> AddAsync(Client client);
    public Task<Client?> UpdateAsync(int id, Client client);
    public Task<bool> RemoveAsync(int id);
}