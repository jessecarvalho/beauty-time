using System.Numerics;

namespace Application.DTOs;

public record AppointmentResponseDto
{
    public int Id { get; set; }
    public EstablishmentResponseDto EstablishmentId { get; set; }
    public ClientResponseDto ClientId { get; set; }
}