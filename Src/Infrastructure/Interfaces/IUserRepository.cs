using Core.Entities;

namespace Infrastructure.Interfaces;

public interface IUserRepository
{
    public Task<IEnumerable<User>?> GetAllAsync();
    public Task<User> GetByIdAsync(int id);
    public Task<User> AddAsync(User user);
    public Task<User> UpdateAsync(int id, User user);
    public Task<bool> DeleteAsync(int id);
    public Task<User?> GetUserByEmailAsync(string email);
    public Task<bool> CheckPasswordAsync(User user, string password);

}