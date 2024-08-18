namespace Application.DTOs;

public record AppointmentRequestDto
{
    public DateTime Date { get; init; }

    public int EstablishmentId { get; init; }
}