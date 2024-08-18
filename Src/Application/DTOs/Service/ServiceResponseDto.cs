using System.Numerics;
using Core.Enums;

namespace Application.DTOs;

public record ServiceResponseDto
{
    public int Id { get; init; }
    public required string Name { get; init; }
    public required string Description { get; init; }
    public required string Icon { get; init; }
    public required uint Price { get; init; }
    public required uint TimeInMinutes { get; init; }
    public required ActiveEnum Active { get; init; }
}