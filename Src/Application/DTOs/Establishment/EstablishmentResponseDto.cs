namespace Application.DTOs;

public record EstablishmentResponseDto
{
    public int Id { get; init; }
    public required string Name { get; init; }
    public required string Logo { get; init; }
    public required string Cover { get; init; }
    public required string Permalink { get; init; }
    public required string Address { get; init; }
    public required string TelephoneNumber { get; init; }
    public required List<ServiceResponseDto> Services { get; init; }
    public required List<WorkingDayResponseDto> WorkingDays { get; init; }
}