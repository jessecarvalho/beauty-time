using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace Core.Entities;

public record User
{
    public int Id { get; set; }
    
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
    
    public int EstablishmentId { get; set; }
    
    public int ClientId { get; set; }
    
    public Establishment Establishment { get; set; }
    
    public Client Client { get; set; }
    
}