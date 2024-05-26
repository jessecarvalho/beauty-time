using Core.Enums;

namespace Application.DTOs;

public class ServiceRequestDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Icon { get; set; }
    public uint Price { get; set; }
    public uint TimeInMinutes { get; set; }
    public uint EstablishmentId { get; set; }
    public ActiveEnum Active { get; set; }
}