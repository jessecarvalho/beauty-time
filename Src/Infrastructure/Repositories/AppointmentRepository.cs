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
    
    public async Task<IEnumerable<Appointment>> GetAllAsync()
    {
        return await _context.Appointments.ToListAsync();
    }

    public async Task<Appointment?> GetByIdAsync(int id)
    {
        return await _context.Appointments.FindAsync(id);
    }

    public async Task<Appointment> AddAsync(Appointment appointment)
    {
        await _context.Appointments.AddAsync(appointment);
        await _context.SaveChangesAsync();
        return appointment;
    }

    public async Task<Appointment> UpdateAsync(int id, Appointment appointment)
    {
        var existingAppointment = await _context.Appointments.FindAsync(id);

        if (existingAppointment == null)
            throw new AppointmentNotFoundException($"Appointment {id} was not found");

        existingAppointment.ClientId = appointment.ClientId;
        existingAppointment.EstablishmentId = appointment.EstablishmentId;

        await _context.SaveChangesAsync();
        return existingAppointment;
    }

    public async Task<bool> RemoveAsync(int id)
    {
        var existingAppointment = await _context.Appointments.FindAsync(id);

        if (existingAppointment == null)
            throw new AppointmentNotFoundException($"Appointment {id} was not found");

        _context.Appointments.Remove(existingAppointment);
        var saveResult = await _context.SaveChangesAsync();

        return saveResult > 0;
    }
}