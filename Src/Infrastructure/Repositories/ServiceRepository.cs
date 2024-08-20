using Core.Entities;
using Infrastructure.Interfaces;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class ServiceRepository : IServiceRepository
{
    private readonly ApplicationDbContext _context;

    public ServiceRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<Service>> GetAllAsync(int userId)
    {
        var establishment = await _context.Establishments.FirstOrDefaultAsync(x => x.UserId == userId);

        if (establishment == null)
            throw new Exception($"Establishment for user {userId} was not found");
        
        return await _context.Services.Where(x => x.EstablishmentId == establishment.Id).ToListAsync();
    }

    public async Task<Service?> GetByIdAsync(int id, int userId)
    {
        var establishment = await _context.Establishments.FirstOrDefaultAsync(x => x.UserId == userId);

        if (establishment == null)
            throw new Exception($"Establishment for user {userId} was not found");
        
        var services = await _context.Services.FindAsync(id);
        return services;
    }

    public async Task<Service?> AddAsync(Service service, int id)
    {
        var establishment = await _context.Establishments.FindAsync(id);
        
        if (establishment == null)
            throw new Exception($"Establishment {id} was not found");
        
        service.Establishment = establishment;
        
        await _context.Services.AddAsync(service);
        await _context.SaveChangesAsync();
        return service;
    }

    public async Task<Service?> UpdateAsync(int id, Service service, int userId)
    {
        var existingService = await _context.Services.FindAsync(id);
        
        if (existingService == null)
            throw new Exception($"Service {id} was not found");
        
        var establishment = await _context.Establishments.FirstOrDefaultAsync(x => x.UserId == userId);

        if (establishment == null)
            throw new Exception($"Establishment for user {userId} was not found");
        
        existingService.Name = service.Name;
        existingService.Description = service.Description;
        existingService.Icon = service.Icon;
        existingService.Price = service.Price;
        existingService.TimeInMinutes = service.TimeInMinutes;
        existingService.Active = service.Active;
        
        await _context.SaveChangesAsync();
        return existingService;
    }

    public async Task<bool> RemoveAsync(int id, int userId)
    {
        var establishment = await _context.Establishments.FirstOrDefaultAsync(x => x.UserId == userId);

        if (establishment == null)
            throw new Exception($"Establishment for user {userId} was not found");
        
        var existingService = await _context.Services.FindAsync(id);
        
        if (existingService == null)
            throw new Exception($"Service {id} was not found");
        
        _context.Services.Remove(existingService);
        var saveResult = await _context.SaveChangesAsync();
        
        return saveResult > 0;
    }
}