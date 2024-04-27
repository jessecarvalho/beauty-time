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
    
    public async Task<IEnumerable<Service>> GetAllAsync()
    {
        return await _context.Services.ToListAsync();
    }

    public async Task<Service?> GetByIdAsync(int id)
    {
        return await _context.Services.FindAsync(id);
    }

    public async Task<Service?> AddAsync(Service service)
    {
        await _context.Services.AddAsync(service);
        await _context.SaveChangesAsync();
        return service;
    }

    public async Task<Service?> UpdateAsync(int id, Service service)
    {
        var existingService = await _context.Services.FindAsync(id);
        
        if (existingService == null)
            throw new Exception($"Service {id} was not found");
        
        existingService.Name = service.Name;
        existingService.Description = service.Description;
        existingService.Icon = service.Icon;
        existingService.Price = service.Price;
        existingService.TimeInMinutes = service.TimeInMinutes;
        existingService.Active = service.Active;
        
        await _context.SaveChangesAsync();
        return existingService;
    }

    public async Task<bool> RemoveAsync(int id)
    {
        var existingService = await _context.Services.FindAsync(id);
        
        if (existingService == null)
            throw new Exception($"Service {id} was not found");
        
        _context.Services.Remove(existingService);
        var saveResult = await _context.SaveChangesAsync();
        
        return saveResult > 0;
    }
}