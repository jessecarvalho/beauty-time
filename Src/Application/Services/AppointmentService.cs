using System.Text.Json;
using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Interfaces;

namespace Application.Services;

public class AppointmentService : IAppointmentService
{
    private readonly IMapper _mapper;
    private readonly IAppointmentRepository _appointmentRepository;
    private readonly IRedisService _redisService;
    private readonly IEstablishmentRepository _establishmentRepository;

    public AppointmentService(IAppointmentRepository appointmentRepository, IMapper mapper, IRedisService redisService, IEstablishmentRepository establishmentRepository)
    {
        _appointmentRepository = appointmentRepository;
        _mapper = mapper;
        _redisService = redisService;
        _establishmentRepository = establishmentRepository;
    }

    public async Task<IEnumerable<AppointmentResponseDto>> GetAllAsync(int userId, string cacheKey)
    {
        var appointmentsInCache = await _redisService.GetValueAsync(cacheKey);
    
        if (appointmentsInCache is not null)
        {
            var cachedAppointments = JsonSerializer.Deserialize<IEnumerable<AppointmentResponseDto>>(appointmentsInCache);
            if (cachedAppointments is not null)
                return cachedAppointments;
        }

        var appointments = await _appointmentRepository.GetAllAsync(userId);
    
        await _redisService.SetValueAsync(cacheKey, JsonSerializer.Serialize(appointments), TimeSpan.FromMinutes(1));
    
        return _mapper.Map<IEnumerable<AppointmentResponseDto>>(appointments);
    }

    public async Task<IEnumerable<AppointmentResponseDto>> GetByIdAsync(int id, int userId, string cacheKey)
    {
        var appointmentInCache = await _redisService.GetValueAsync(cacheKey);
        
        if (appointmentInCache is not null)
        {
            var cachedAppointment = JsonSerializer.Deserialize<AppointmentResponseDto>(appointmentInCache);
            if (cachedAppointment is not null)
                return new List<AppointmentResponseDto> { cachedAppointment };
        }
        
        var appointment = await _appointmentRepository.GetByIdAsync( id, userId);
        
        await _redisService.SetValueAsync(cacheKey, JsonSerializer.Serialize(appointment), TimeSpan.FromMinutes(1));
        
        return _mapper.Map<IEnumerable<AppointmentResponseDto>>(appointment);
        
    }
    
    public async Task<AppointmentResponseDto> AddAsync(int userId, AppointmentRequestDto appointmentRequestDto, string cacheKey)
    {
        var appointmentInCache = await _redisService.GetValueAsync(cacheKey);
        
        if (appointmentInCache is not null)
        {
            var cachedAppointment = JsonSerializer.Deserialize<AppointmentResponseDto>(appointmentInCache);
            if (cachedAppointment is not null)
                return cachedAppointment;
        }

        var appointmentObj = _mapper.Map<Appointment>(appointmentRequestDto);
        appointmentObj.UserId = userId;

        var appointment = await _appointmentRepository.AddAsync(userId, appointmentObj);
        await _redisService.SetValueAsync(cacheKey, JsonSerializer.Serialize(appointment), TimeSpan.FromMinutes(1));
        
        return _mapper.Map<AppointmentResponseDto>(appointment);
    }
    
    public async Task<AppointmentResponseDto> UpdateAsync(int id, int userId, AppointmentRequestDto appointmentRequestDto, string cacheKey)
    {
        var appointmentInCache = await _redisService.GetValueAsync(cacheKey);
        
        if (appointmentInCache is not null)
        {
            var cachedAppointment = JsonSerializer.Deserialize<AppointmentResponseDto>(appointmentInCache);
            if (cachedAppointment is not null)
                return cachedAppointment;
        }
        
        var appointmentObj = _mapper.Map<Appointment>(appointmentRequestDto);
        appointmentObj.UserId = userId;
        
        var appointment = await _appointmentRepository.UpdateAsync(userId, id, appointmentObj);
        await _redisService.SetValueAsync(cacheKey, JsonSerializer.Serialize(appointment), TimeSpan.FromMinutes(1));
        
        return _mapper.Map<AppointmentResponseDto>(appointment);
    }
    
    public async Task<bool> RemoveAsync(int id, int userId)
    {
        return await _appointmentRepository.RemoveAsync(id, userId);
    }
}