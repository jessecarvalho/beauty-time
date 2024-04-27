using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace Core.Entities;

public record Appointment
{
    public BigInteger Id { get; set; }
    
    [Required]
    public Establishment EstablishmentId { get; set; }
    
    [Required]
    public Client ClientId { get; set; }
    
    [Required]
    public DateTime Date { get; set; }
}