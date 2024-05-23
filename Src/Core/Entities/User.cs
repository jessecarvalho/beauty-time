using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace Core.Entities;

public record User
{
    public BigInteger Id { get; set; }
    
    [Required]
    [MaxLength(255)]
    public string Name { get; set; }
    
    [Required]
    [MaxLength(255)]
    public string Email { get; set; }
    
    [Required]
    [MaxLength(255)]
    public string Password { get; set; }
    
    [Required]
    [MaxLength]
    public string TelephoneNumber { get; set; }
    
    public BigInteger EstablishmentId { get; set; }
    
    public BigInteger ClientId { get; set; }
    
    public Establishment Establishment { get; set; }
    
    public Client Client { get; set; }
    
}