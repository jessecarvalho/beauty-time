using Core.Entities;
using Infrastructure.Exceptions;
using Infrastructure.Interfaces;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class EstablishmentSocialMediaRepository : IEstablishmentSocialMediaRepository
{
    private readonly ApplicationDbContext _context;

    public EstablishmentSocialMediaRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<EstablishmentSocialMedia>> GetAllAsync()
    {
        return await _context.BarberShopSocialMedias.ToListAsync();
    }

    public async Task<EstablishmentSocialMedia?> GetByIdAsync(int id)
    {
        return await _context.BarberShopSocialMedias.FindAsync(id);
    }

    public async Task<EstablishmentSocialMedia?> AddAsync(EstablishmentSocialMedia establishment)
    {
        await _context.BarberShopSocialMedias.AddAsync(establishment);
        await _context.SaveChangesAsync();
        return establishment;
    }

    public async Task<EstablishmentSocialMedia?> UpdateAsync(int id, EstablishmentSocialMedia establishment)
    {
        var existingBarberShop = await _context.BarberShopSocialMedias.FindAsync(id);

        if (existingBarberShop == null) throw new EstablishmentNotFoundException($"The BarberShop {id} was not found");
        
        existingBarberShop.EstablishmentId = establishment.EstablishmentId;
        existingBarberShop.SocialMedia = establishment.SocialMedia;
        existingBarberShop.Link = establishment.Link;
        
        await _context.SaveChangesAsync();
        return existingBarberShop;
    }

    public async Task<bool> RemoveAsync(int id)
    {
        var existingBarberShop = await _context.BarberShopSocialMedias.FindAsync(id);
        if (existingBarberShop == null)
            throw new EstablishmentNotFoundException($"The BarberShop {id} was not found");
        
        _context.BarberShopSocialMedias.Remove(existingBarberShop);
        var result =  await _context.SaveChangesAsync();
        return result > 0;
    }
}