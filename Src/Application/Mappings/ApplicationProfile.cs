using Application.DTOs;
using AutoMapper;
using Core.Entities;

namespace Application.Mappings;

public class ApplicationProfile : Profile
{

    public ApplicationProfile()
    {
        CreateMap<AppointmentRequestDto, Appointment>();
        CreateMap<Appointment, AppointmentResponseDto>();
        CreateMap<EstablishmentRequestDto, Establishment>();
        CreateMap<Establishment, EstablishmentResponseDto>();
        CreateMap<Client, ClientResponseDto>();
        CreateMap<ClientRequestDto, Client>();
        CreateMap<Service, ServiceResponseDto>();
    }
    
}