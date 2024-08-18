using Core.Enums;

namespace Application.DTOs;

public record ServiceRequestDto 
{
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required string Icon { get; set; }
    public required uint Price { get; set; }
    public required uint TimeInMinutes { get; set; }
    public required uint EstablishmentId { get; set; }
    public required ActiveEnum Active { get; set; } 
}