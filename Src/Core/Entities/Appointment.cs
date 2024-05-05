using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace Core.Entities;

public record Appointment
{
    public BigInteger Id { get; set; }
    
    [Required]
    public BigInteger EstablishmentId { get; set; }
    
    [Required]
    public BigInteger ClientId { get; set; }
    
    [Required]
    public DateTime Date { get; set; }
    
    public Establishment Establishment { get; set; }
    
    public Client Client { get; set; }
}