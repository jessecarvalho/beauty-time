using Core.Entities;
using Infrastructure.Exceptions;
using Infrastructure.Interfaces;
using Infrastructure.Persistence;
using System.Linq;
using Core.Enums;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class EstablishmentRepository : IEstablishmentRepository
{
    private readonly ApplicationDbContext _context;

    public EstablishmentRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<Establishment>> GetAllAsync()
    {
        return await _context.Establishments.ToListAsync();
    }

    public async Task<Establishment?> GetByIdAsync(int id)
    {
        return await _context.Establishments
            .Include(e => e.Services)
            .Include(e => e.WorkingDays)
            .FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task<Establishment> GetByUserIdAsync(int id)
    {
        return await _context.Establishments.FirstOrDefaultAsync(e => e.UserId == id) ?? throw new EstablishmentNotFoundException($"The Establishment {id} was not found");
    }
    
    public async Task<List<User>> GetClientsByEstablishmentIdAsync(int id)
    {
        var establishment = await _context.Establishments.FindAsync(id);

        if (establishment == null)
            throw new EstablishmentNotFoundException($"The Establishment {id} was not found");

        return await _context.Users
            .AsQueryable()
            .Where(u => u.Id == id)
            .ToListAsync();
    }

    public async Task<Establishment?> AddAsync(Establishment establishment)
    {
        var existingEstablishment =
            await _context.Establishments.FirstOrDefaultAsync(e => e.UserId == establishment.UserId);
        
        if (existingEstablishment != null)
            throw new EstablishmentAlreadyExistsException($"The Establishment for user {establishment.UserId} already exists");
        
        await _context.AddAsync(establishment);
        await _context.SaveChangesAsync();
        return establishment;
    }

    public async Task<Establishment?> UpdateAsync(int id, Establishment establishment)
    {
        var existingBarberShop = await _context.Establishments.FindAsync(id);

        if (existingBarberShop == null) 
            throw new EstablishmentNotFoundException($"The BarberShop {id} was not found");
        
        if (existingBarberShop.UserId != establishment.UserId)
            throw new EstablishmentNotFoundException($"The BarberShop {id} was not found");
        
        existingBarberShop.Name = establishment.Name;
        existingBarberShop.Logo = establishment.Logo;
        existingBarberShop.Cover = establishment.Cover;
        existingBarberShop.Permalink = establishment.Permalink;
        existingBarberShop.Address = establishment.Address;
        existingBarberShop.Active = establishment.Active;

        await _context.SaveChangesAsync();

        return establishment;
    }

    public async Task<bool> RemoveAsync(int id, int userId)
    {
        var existingBarberShop = await _context.Establishments.FindAsync(id);

        if (existingBarberShop == null)
            throw new EstablishmentNotFoundException($"The BarberShop {id} was not found");
        
        if (existingBarberShop.UserId != userId)
            throw new EstablishmentNotFoundException($"The BarberShop {id} was not found");

        _context.Establishments.Remove(existingBarberShop);

        var result = await _context.SaveChangesAsync();

        return result > 0;
    }

    public async Task<bool> EnableAsync(int id, int userId)
    {
        var establishment = await _context.Establishments.FindAsync(id);
        
        if (establishment is null)
            throw new EstablishmentNotFoundException($"The Establishment {id} was not found");

        if (establishment.UserId != userId)
            throw new UnauthorizedAccessException("You are not allowed to enable this establishment");
        
        if (establishment.Active == ActiveEnum.Active)
            throw new EstablishmentAlreadyEnabledException($"The Establishment {id} is already enabled");
        
        establishment.Active = ActiveEnum.Active;
        await _context.SaveChangesAsync();
        
        return true;
    }

    public async Task<bool> DisableAsync(int id, int userId)
    {
        var establishment = await _context.Establishments.FindAsync(id);
        
        if (establishment is null)
            throw new EstablishmentNotFoundException($"The Establishment {id} was not found");
        
        if (establishment.UserId != userId)
            throw new UnauthorizedAccessException("You are not allowed to disable this establishment");
        
        if (establishment.Active == ActiveEnum.Disabled)
            throw new EstablishmentAlreadyDisabledException($"The Establishment {id} is already disabled");
        
        establishment.Active = ActiveEnum.Disabled;
        await _context.SaveChangesAsync();
        
        return true;
    }
}