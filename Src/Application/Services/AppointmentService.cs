using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Core.Entities;
using Infrastructure.Interfaces;
using Infrastructure.Repositories;

namespace Application.Services;

public class AppointmentService : IAppointmentService
{
    private readonly Mapper _mapper;
    private readonly IAppointmentRepository _appointmentRepository;

    public AppointmentService(IAppointmentRepository appointmentRepository, Mapper mapper)
    {
        _appointmentRepository = appointmentRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<AppointmentResponseDto>> GetAllAsync()
    {
        var appointments = await _appointmentRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<AppointmentResponseDto>>(appointments);
    }

    public async Task<IEnumerable<AppointmentResponseDto>> GetByIdAsync(int id)
    {
        var appointment = await _appointmentRepository.GetByIdAsync(id);
        return _mapper.Map<IEnumerable<AppointmentResponseDto>>(appointment);
    }
    
    public async Task<AppointmentResponseDto> AddAsync(AppointmentRequestDto appointmentRequestDto)
    {
        var appointment = await _appointmentRepository.AddAsync(_mapper.Map<Appointment>(appointmentRequestDto));
        return _mapper.Map<AppointmentResponseDto>(appointment);
    }
    
    public async Task<AppointmentResponseDto> UpdateAsync(int id, AppointmentRequestDto appointmentRequestDto)
    {
        var appointment = await _appointmentRepository.UpdateAsync(id, _mapper.Map<Appointment>(appointmentRequestDto));
        return _mapper.Map<AppointmentResponseDto>(appointment);
    }
    
    public async Task<bool> RemoveAsync(int id)
    {
        return await _appointmentRepository.RemoveAsync(id);
    }
}