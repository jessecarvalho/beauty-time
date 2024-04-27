using Core.Entities;
using Infrastructure.Interfaces;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class ClientRepository : IClientRepository
{
    private readonly ApplicationDbContext _context;

    public ClientRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<Client>> GetAllAsync()
    {
        return await _context.Clients.ToListAsync();
    }

    public async Task<Client?> GetByIdAsync(int id)
    {
        return await _context.Clients.FindAsync(id);
    }

    public async Task<Client?> AddAsync(Client client)
    {
        await _context.Clients.AddAsync(client);
        await _context.SaveChangesAsync();
        return client;
    }

    public async Task<Client?> UpdateAsync(int id, Client client)
    {
        var existingClient = await _context.Clients.FindAsync(id);
        
        if (existingClient == null)
            throw new Exception($"Client {id} was not found");
        
        existingClient.Name = client.Name;
        existingClient.TelephoneNumber = client.TelephoneNumber;
        
        await _context.SaveChangesAsync();
        return existingClient;
    }

    public async Task<bool> RemoveAsync(int id)
    {
        var existingClient = await _context.Clients.FindAsync(id);
        
        if (existingClient == null)
            throw new Exception($"Client {id} was not found");
        
        _context.Clients.Remove(existingClient);
        var saveResult = await _context.SaveChangesAsync();
        
        return saveResult > 0;
    }
}