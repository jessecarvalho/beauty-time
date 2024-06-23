using Core.Entities;
using Infrastructure.Exceptions;
using Infrastructure.Interfaces;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _context;

    public UserRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<User>?> GetAllAsync()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task<User> GetByIdAsync(int id)
    {
        var user = await _context.Users.FindAsync(id);

        if (user is null)
            throw new UserNotFoundException();

        return user;
    }

    public async Task<User> AddAsync(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task<User> UpdateAsync(int id, User user)
    {
        var userToUpdate = await _context.Users.FindAsync(id);

        if (userToUpdate is null)
            throw new UserNotFoundException();

        userToUpdate.Name = user.Name;
        userToUpdate.Email = user.Email;
        userToUpdate.Password = user.Password;
        userToUpdate.TelephoneNumber = user.TelephoneNumber;
        await _context.SaveChangesAsync();

        return userToUpdate;

    }

    public async Task<bool> DeleteAsync(int id)
    {
        var userToDelete = await _context.Users.FindAsync();

        if (userToDelete is null)
            throw new UserNotFoundException();

        _context.Users.Remove(userToDelete);

        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<User?> GetUserByEmailAsync(string email)
    {
        var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == email);
        return user;
    }
    
    public async Task<bool> CheckPasswordAsync(User user, string password)
    {
        return await Task.FromResult(user.Password == password);
    }
}