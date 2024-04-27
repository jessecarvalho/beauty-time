using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace Core.Entities;

public record Client
{
    public BigInteger Id { get; set; }
    
    [Required]
    [MaxLength(255)]
    public string Name { get; set; }
    
    [Required]
    [MaxLength(255)]
    public string TelephoneNumber { get; set; }
    
    [Required]
    [MaxLength(255)]
    public List<Appointment> Appointments { get; set; }
}