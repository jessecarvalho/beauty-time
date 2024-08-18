using System.Numerics;
using Core.Enums;

namespace Application.DTOs;

public record EstablishmentRequestDto
{
    public required string Name { get; set; }
    public required string Logo { get; set; }
    public required string Cover { get; set; }
    public required string Permalink { get; set; }
    public required string Address { get; set; }
    public required string TelephoneNumber { get; set; }
}