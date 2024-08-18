namespace Application.DTOs;

public record AppointmentResponseDto
{
    public int Id { get; init; }

    public DateTime Date { get; init; }

    public int EstablishmentId { get; init; }

    public int UserId { get; init; }
}