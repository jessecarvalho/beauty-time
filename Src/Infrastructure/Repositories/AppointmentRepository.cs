using Core.Entities;
using Infrastructure.Exceptions;
using Infrastructure.Interfaces;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class AppointmentRepository : IAppointmentRepository
{
    private readonly ApplicationDbContext _context;

    public AppointmentRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<Appointment>> GetAllAsync(int userId)
    {
        return await _context.Appointments.ToListAsync();
    }
    
    public async Task<Appointment?> GetByIdAsync(int id, int userId)
    {
        var query = _context.Appointments.AsQueryable();

        return await query.FirstOrDefaultAsync(a => a.Id == id);
    }

    public async Task<Appointment> AddAsync(int userId, Appointment appointment)
    {
        
        var existingEstablishment = await _context.Establishments.FindAsync(appointment.EstablishmentId);
        if (existingEstablishment == null)
            throw new EstablishmentNotFoundException($"Establishment {appointment.EstablishmentId} was not found");

        await _context.Appointments.AddAsync(appointment);
        await _context.SaveChangesAsync();

        return appointment;
    }

    public async Task<Appointment> UpdateAsync( int id, int userId, Appointment appointment)
    {
        var existingAppointment = await _context.Appointments.FindAsync(id);
        
        if (existingAppointment == null)
            throw new AppointmentNotFoundException($"Appointment {id} was not found");
        
        var existingEstablishment = await _context.Establishments.FindAsync(appointment.EstablishmentId);
        
        if (existingEstablishment == null)
            throw new EstablishmentNotFoundException($"Establishment {appointment.EstablishmentId} was not found");
        
        existingAppointment.UserId = appointment.UserId;
        existingAppointment.EstablishmentId = appointment.EstablishmentId;
        existingAppointment.Date = appointment.Date;
        
        await _context.SaveChangesAsync();
        
        return existingAppointment;
    }

    public async Task<bool> RemoveAsync(int id, int userId)
    {
        var query = _context.Appointments.AsQueryable();
        
        var existingAppointment = await query.FirstOrDefaultAsync(a => a.Id == id);
        
        if (existingAppointment == null)
            throw new AppointmentNotFoundException($"Appointment {id} was not found");
        
        _context.Appointments.Remove(existingAppointment);
        
        return await _context.SaveChangesAsync() > 0;
    }
}