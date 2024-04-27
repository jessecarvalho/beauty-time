using System.Numerics;

namespace Core.Entities;

public record Appointment
{
    public BigInteger Id { get; set; }
    public Establishment EstablishmentId { get; set; }
    public Client ClientId { get; set; }
}