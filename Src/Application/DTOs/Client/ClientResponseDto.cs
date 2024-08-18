using System.Numerics;

namespace Application.DTOs;

public record ClientResponseDto 
{
    public required int Id { get; init; }
    public required List<AppointmentResponseDto> Appointments { get; init; }
    public int UserId { get; set; }
}