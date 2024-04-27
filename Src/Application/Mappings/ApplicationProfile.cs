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
        CreateMap<EstablishmentSocialMediaRequestDto, EstablishmentSocialMedia>();
        CreateMap<EstablishmentSocialMedia, EstablishmentSocialMediaResponseDto>();
        CreateMap<Client, ClientResponseDto>();
        CreateMap<ClientRequestDto, Client>();
        CreateMap<Service, ServiceResponseDto>();
    }
    
}