using System.Numerics;
using Core.Enums;

namespace Application.DTOs;

public class ServiceResponseDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Icon { get; set; }
    public uint Price { get; set; }
    public uint TimeInMinutes { get; set; }
    public ActiveEnum Active { get; set; }
}