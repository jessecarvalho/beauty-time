
using Core.Entities;
using Infrastructure.Exceptions;
using Infrastructure.Interfaces;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class WorkingDayRepository : IWorkingDayRepository
{
    private readonly ApplicationDbContext _context;
    
    public WorkingDayRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<WorkingDay>?> GetAllAsync()
    {
        var workingDays = await _context.WorkingDays.ToListAsync();
        return workingDays;
    }

    public async Task<WorkingDay> GetByIdAsync(int id)
    {
        var workingDay = await _context.WorkingDays.FindAsync(id);
        
        if (workingDay is null)
            throw new WorkingDayNotFoundException();
        
        return workingDay;
    }

    public async Task<WorkingDay> AddAsync(WorkingDay workingDay, User user)
    {
        var establishment = await _context.Establishments.Where(x => x.UserId == user.Id).FirstOrDefaultAsync();
    
        if (establishment is null)
            throw new EstablishmentNotFoundException();
        
        workingDay.UserId = user.Id;
        workingDay.EstablishmentId = establishment.Id;
        
        var result = _context.WorkingDays.Add(workingDay);
        
        await _context.SaveChangesAsync();

        return result.Entity;
    }

    public async Task<WorkingDay> UpdateAsync(int id, WorkingDay workingDay, User user)
    {
        var establishment = await _context.Establishments.Where(x => x.UserId == user.Id).FirstOrDefaultAsync();
        
        if (establishment is null)
            throw new EstablishmentNotFoundException();
        
        var existingWorkingDay = _context.WorkingDays.Find(id);
        
        if (existingWorkingDay is null)
            throw new WorkingDayNotFoundException();

        existingWorkingDay.Day = workingDay.Day;
        existingWorkingDay.StartHour = workingDay.StartHour;
        existingWorkingDay.EndHour = workingDay.EndHour;
        
        await _context.SaveChangesAsync();
        
        return existingWorkingDay;
    }

    public async Task<bool> DeleteAsync(int id, User user)
    {
        var establishment = await _context.Establishments.Where(x => x.UserId == user.Id).FirstOrDefaultAsync();
        
        if (establishment is null)
            throw new EstablishmentNotFoundException();
        
        var workingDay = await _context.WorkingDays.FindAsync(id);
        
        if (workingDay is null)
            throw new WorkingDayNotFoundException();
        
        _context.WorkingDays.Remove(workingDay);
        
        await _context.SaveChangesAsync();
        
        return true;
    }
}