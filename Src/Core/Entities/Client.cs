using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace Core.Entities;

public record Client
{
    public BigInteger Id { get; set; }
    
    public List<Appointment> Appointments { get; set; }
    public List<Establishment> Establishments { get; set; }
}