using System.Numerics;

namespace Application.DTOs;

public class ClientResponseDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string TelephoneNumber { get; set; }
    public List<AppointmentResponseDto> Appointments { get; set; }
}