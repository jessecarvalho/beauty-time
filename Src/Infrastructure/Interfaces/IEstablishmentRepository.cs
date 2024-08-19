using Core.Entities;

namespace Infrastructure.Interfaces;

public interface IEstablishmentRepository
{
    public Task<IEnumerable<Establishment>> GetAllAsync ();
    public Task<Establishment?> GetByIdAsync (int id);
    public Task<Establishment> GetByUserIdAsync (int id);
    public Task<List<User>> GetClientsByEstablishmentIdAsync (int id);
    public Task<Establishment?> AddAsync (Establishment establishment);
    public Task<Establishment?> UpdateAsync (int id, Establishment establishment);
    public Task<bool> RemoveAsync (int id, int userId);
}