using Core.Entities;
using Infrastructure.Exceptions;
using Infrastructure.Interfaces;
using Infrastructure.Persistence;
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
        return await _context.Establishments.FindAsync(id);
    }

    public async Task<Establishment?> AddAsync(Establishment establishment)
    {
        await _context.AddAsync(establishment);
        await _context.SaveChangesAsync();
        return establishment;
    }

    public async Task<Establishment?> UpdateAsync(int id, Establishment establishment)
    {
        var existingBarberShop = await _context.Establishments.FindAsync(id);

        if (existingBarberShop == null) 
            throw new EstablishmentNotFoundException($"The BarberShop {id} was not found");
        
        existingBarberShop.Name = establishment.Name;
        existingBarberShop.Logo = establishment.Logo;
        existingBarberShop.Cover = establishment.Cover;
        existingBarberShop.Permalink = establishment.Permalink;
        existingBarberShop.Address = establishment.Address;
        existingBarberShop.Active = establishment.Active;
        existingBarberShop.Appointments = establishment.Appointments;

        await _context.SaveChangesAsync();

        return establishment;
    }

    public async Task<bool> RemoveAsync(int id)
    {
        var existingBarberShop = await _context.Establishments.FindAsync(id);

        if (existingBarberShop == null)
            throw new EstablishmentNotFoundException($"The BarberShop {id} was not found");

        _context.Establishments.Remove(existingBarberShop);

        var result = await _context.SaveChangesAsync();

        return result > 0;
    }
}