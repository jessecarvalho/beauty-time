using Application.DTOs;
using Application.DTOs.User;
using AutoMapper;
using Core.Entities;

namespace Application.Mappings;

public class ApplicationProfile : Profile
{

    public ApplicationProfile()
    {
        CreateMap<Appointment, AppointmentResponseDto>();
        CreateMap<AppointmentRequestDto, Appointment>();
        CreateMap<Establishment, EstablishmentResponseDto>();
        CreateMap<EstablishmentRequestDto, Establishment>();
        CreateMap<Service, ServiceResponseDto>();
        CreateMap<ServiceRequestDto, Service>();
        CreateMap<UserRequestDto, User>();
        CreateMap<User, UserResponseDto>();
        CreateMap<WorkingDay, WorkingDayResponseDto>();
        CreateMap<WorkingDayRequestDto, WorkingDay>();
    }
    
}