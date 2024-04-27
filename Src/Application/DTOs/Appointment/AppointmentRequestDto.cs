namespace Application.DTOs;

public record AppointmentRequestDto
{
    public EstablishmentResponseDto EstablishmentId { get; set; }
    public ClientResponseDto ClientId { get; set; }
}