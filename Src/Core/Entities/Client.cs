using System.Numerics;

namespace Core.Entities;

public record Client
{
    public BigInteger Id { get; set; }
    public string Name { get; set; }
    public string TelephoneNumber { get; set; }
    public List<Appointment> Appointments { get; set; }
}